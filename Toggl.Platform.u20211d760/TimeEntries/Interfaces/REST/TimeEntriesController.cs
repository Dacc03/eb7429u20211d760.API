using System.Globalization;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Commands;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.ValueObjects;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Services;
using Toggl.Platform.u20211d760.TimeEntries.Interfaces.REST.Resources;
using Toggl.Platform.u20211d760.TimeEntries.Interfaces.REST.Transform;

namespace Toggl.Platform.u20211d760.TimeEntries.Interfaces.REST;

/// <summary>
/// Controller for time entry operations.
/// </summary>
/// <remarks>
/// Author: Rafael Oswaldo Castro Veramendi
/// </remarks>
[ApiController]
[Route("api/v1/time-entries")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Operations for managing time entries")]
public class TimeEntriesController(ITimeEntryCommandService timeEntryCommandService) : ControllerBase
{
    /// <summary>
    /// Registers a new time entry.
    /// </summary>
    /// <param name="resource">The time entry payload.</param>
    /// <returns>The created time entry resource.</returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Register a time entry",
        Description = "Creates a time entry and emits an integration event",
        OperationId = "CreateTimeEntry")]
    [SwaggerResponse(201, "The time entry was created", typeof(TimeEntryResource))]
    [SwaggerResponse(400, "Invalid data supplied")]
    [SwaggerResponse(500, "Internal server error")]
    public async Task<IActionResult> CreateTimeEntry([FromBody] CreateTimeEntryResource resource)
    {
        try
        {
            if (!DateTime.TryParseExact(resource.StartedAt, "yyyy-MM-dd HH:mm:ss",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out var startedAt))
            {
                return BadRequest(new { message = GetLocalizedMessage("InvalidDateFormat") });
            }

            if (!Enum.TryParse(resource.EntryStatus, true, out EEntryStatus entryStatus))
            {
                return BadRequest(new { message = GetLocalizedMessage("InvalidEntryStatus") });
            }

            var command = new CreateTimeEntryCommand(
                resource.ProjectId,
                resource.UserId,
                resource.Description,
                resource.DurationMinutes,
                entryStatus,
                startedAt);

            var entity = await timeEntryCommandService.Handle(command);
            var response = TimeEntryResourceFromEntityAssembler.ToResourceFromEntity(entity);
            return StatusCode(201, response);
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
            "InvalidEntryStatus" => isSpanish
                ? "Estado de entrada inválido. Use RUNNING o STOPPED"
                : "Invalid entry status. Use RUNNING or STOPPED",
            "InternalError" => isSpanish
                ? "Error interno del servidor"
                : "Internal server error",
            _ => isSpanish ? "Error desconocido" : "Unknown error",
        };
    }
}
