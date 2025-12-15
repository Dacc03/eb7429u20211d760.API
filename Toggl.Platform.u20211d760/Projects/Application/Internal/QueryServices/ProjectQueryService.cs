using Toggl.Platform.u20211d760.Projects.Domain.Model.Aggregates;
using Toggl.Platform.u20211d760.Projects.Domain.Model.Queries;
using Toggl.Platform.u20211d760.Projects.Domain.Repositories;
using Toggl.Platform.u20211d760.Projects.Domain.Services;

namespace Toggl.Platform.u20211d760.Projects.Application.Internal.QueryServices;

/// <summary>
/// Provides project query capabilities.
/// </summary>
/// <remarks>
/// Author: July Zelmira Paico Calderon
/// </remarks>
public class ProjectQueryService(IProjectRepository projectRepository) : IProjectQueryService
{
    /// <inheritdoc />
    public async Task<IEnumerable<Project>> Handle(GetAllProjectsQuery query)
    {
        return await projectRepository.ListAsync();
    }

    /// <inheritdoc />
    public async Task<Project?> FindByIdAsync(int id)
    {
        return await projectRepository.FindByIdAsync(id);
    }
}
