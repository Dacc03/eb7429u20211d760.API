using System.Globalization;
using System.Net.Mime;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Commands;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Services;
using Toggl.Platform.u20211d760.TimeEntries.Interfaces.REST.Resources;
using Toggl.Platform.u20211d760.TimeEntries.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Toggl.Platform.u20211d760.TimeEntries.Interfaces.REST;

/// <summary>
/// Controller for data records operations.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
[ApiController]
[Route("api/v1/data-records")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Operations for managing pot data records")]
public class DataRecordsController(
    IDataRecordCommandService dataRecordCommandService) : ControllerBase
{
    /// <summary>
    /// Creates a new data record.
    /// </summary>
    /// <param name="resource">The data record information.</param>
    /// <returns>The created data record.</returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new data record",
        Description = "Creates a new data record with the provided information",
        OperationId = "CreateDataRecord")]
    [SwaggerResponse(201, "The data record was created successfully", typeof(DataRecordResource))]
    [SwaggerResponse(400, "Invalid data provided")]
    [SwaggerResponse(500, "Internal server error")]
    public async Task<IActionResult> CreateDataRecord([FromBody] CreateDataRecordResource resource)
    {
        try
        {
            // Parse EmittedAt from string
            if (!DateTime.TryParseExact(resource.EmittedAt, "yyyy-MM-dd HH:mm:ss",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out var emittedAt))
            {
                return BadRequest(new { message = GetLocalizedMessage("InvalidDateFormat") });
            }

            // Parse OperationMode
            if (!Enum.TryParse<TimeEntries.Domain.Model.ValueObjects.EOperationMode>(
                    resource.OperationMode, true, out var operationMode))
            {
                return BadRequest(new { message = GetLocalizedMessage("InvalidOperationMode") });
            }

            // Parse OperationPhase
            if (!Enum.TryParse<TimeEntries.Domain.Model.ValueObjects.EOperationPhase>(
                    resource.OperationPhase, true, out var operationPhase))
            {
                return BadRequest(new { message = GetLocalizedMessage("InvalidOperationPhase") });
            }

            var command = new CreateDataRecordCommand(
                resource.PotMacAddress,
                operationMode,
                resource.TargetHumidityLevel,
                resource.CurrentHumidityLevel,
                operationPhase,
                emittedAt);

            var dataRecord = await dataRecordCommandService.Handle(command);

            if (dataRecord == null)
                return BadRequest(new { message = GetLocalizedMessage("DataRecordCreationFailed") });

            var dataRecordResource = DataRecordResourceFromEntityAssembler.ToResourceFromEntity(dataRecord);
            return StatusCode(201, dataRecordResource);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = GetLocalizedMessage("InternalError"), details = ex.Message });
        }
    }

    private string GetLocalizedMessage(string key)
    {
        var culture = HttpContext.Request.Headers["Accept-Language"].ToString();
        var isSpanish = culture.StartsWith("es", StringComparison.OrdinalIgnoreCase);

        return key switch
        {
            "InvalidDateFormat" => isSpanish
                ? "Formato de fecha inválido. Use yyyy-MM-dd HH:mm:ss"
                : "Invalid date format. Use yyyy-MM-dd HH:mm:ss",
            "InvalidOperationMode" => isSpanish
                ? "Modo de operación inválido. Use STAND_BY u OPERATING"
                : "Invalid operation mode. Use STAND_BY or OPERATING",
            "InvalidOperationPhase" => isSpanish
                ? "Fase de operación inválida. Use WAITING o WATERING"
                : "Invalid operation phase. Use WAITING or WATERING",
            "DataRecordCreationFailed" => isSpanish
                ? "No se pudo crear el registro de datos"
                : "Failed to create data record",
            "InternalError" => isSpanish
                ? "Error interno del servidor"
                : "Internal server error",
            _ => isSpanish ? "Error desconocido" : "Unknown error"
        };
    }
}
