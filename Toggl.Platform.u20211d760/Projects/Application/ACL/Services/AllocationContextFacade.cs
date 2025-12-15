using Toggl.Platform.u20211d760.Projects.Domain.Services;
using Toggl.Platform.u20211d760.Projects.Interfaces.ACL;

namespace Toggl.Platform.u20211d760.Projects.Application.ACL.Services;

/// <summary>
/// Facade for exposing project capabilities to other bounded contexts.
/// </summary>
/// <remarks>
/// Author: Rafael Oswaldo Castro Veramendi
/// </remarks>
public class ProjectsContextFacade(IProjectQueryService projectQueryService) : IProjectsContextFacade
{
    /// <inheritdoc />
    public async Task<bool> ExistsProjectAsync(int projectId)
    {
        var project = await projectQueryService.FindByIdAsync(projectId);
        return project != null;
    }
}
