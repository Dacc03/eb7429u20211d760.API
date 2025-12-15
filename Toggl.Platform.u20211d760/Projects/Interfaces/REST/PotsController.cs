using System.Net.Mime;
using Toggl.Platform.u20211d760.Projects.Domain.Model.Queries;
using Toggl.Platform.u20211d760.Projects.Domain.Services;
using Toggl.Platform.u20211d760.Projects.Interfaces.REST.Resources;
using Toggl.Platform.u20211d760.Projects.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Toggl.Platform.u20211d760.Projects.Interfaces.REST;

/// <summary>
/// Controller for pot operations.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
[ApiController]
[Route("api/v1/pots")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Operations for managing pots")]
public class PotsController(IPotQueryService potQueryService) : ControllerBase
{
    /// <summary>
    /// Retrieves all pots.
    /// </summary>
    /// <returns>The list of pots.</returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all pots",
        Description = "Retrieves all registered pots in the system",
        OperationId = "GetAllPots")]
    [SwaggerResponse(200, "Pots retrieved successfully", typeof(IEnumerable<PotResource>))]
    [SwaggerResponse(500, "Internal server error")]
    public async Task<IActionResult> GetAllPots()
    {
        try
        {
            var pots = await potQueryService.Handle(new GetAllPotsQuery());
            var potResources = pots.Select(PotResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(potResources);
        }
        catch (Exception ex)
        {
            var culture = HttpContext.Request.Headers["Accept-Language"].ToString();
            var isSpanish = culture.StartsWith("es", StringComparison.OrdinalIgnoreCase);
            var message = isSpanish ? "Error interno del servidor" : "Internal server error";
            return StatusCode(500, new { message, details = ex.Message });
        }
    }
}
