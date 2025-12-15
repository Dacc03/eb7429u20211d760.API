using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Toggl.Platform.u20211d760.Projects.Domain.Model.Queries;
using Toggl.Platform.u20211d760.Projects.Domain.Services;
using Toggl.Platform.u20211d760.Projects.Interfaces.REST.Resources;
using Toggl.Platform.u20211d760.Projects.Interfaces.REST.Transform;

namespace Toggl.Platform.u20211d760.Projects.Interfaces.REST;

/// <summary>
/// Controller for project operations.
/// </summary>
/// <remarks>
/// Author: Rafael Oswaldo Castro Veramendi
/// </remarks>
[ApiController]
[Route("api/v1/projects")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Operations for managing projects")]
public class ProjectsController(IProjectQueryService projectQueryService) : ControllerBase
{
    /// <summary>
    /// Retrieves all projects.
    /// </summary>
    /// <returns>The list of projects.</returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "List projects",
        Description = "Returns all projects currently stored",
        OperationId = "GetProjects")]
    [SwaggerResponse(200, "Projects retrieved successfully", typeof(IEnumerable<ProjectResource>))]
    [SwaggerResponse(500, "Internal server error")]
    public async Task<IActionResult> GetProjects()
    {
        try
        {
            var projects = await projectQueryService.Handle(new GetAllProjectsQuery());
            var resources = projects.Select(ProjectResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal server error", details = ex.Message });
        }
    }
}
