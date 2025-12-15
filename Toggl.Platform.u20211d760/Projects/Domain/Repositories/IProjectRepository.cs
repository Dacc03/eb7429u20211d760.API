using Toggl.Platform.u20211d760.Projects.Domain.Model.Aggregates;

namespace Toggl.Platform.u20211d760.Projects.Domain.Repositories;

/// <summary>
/// Contract for project persistence operations.
/// </summary>
/// <remarks>
/// Author: July Zelmira Paico Calderon
/// </remarks>
public interface IProjectRepository
{
    Task AddAsync(Project project);
    Task<IEnumerable<Project>> ListAsync();
    Task<Project?> FindByIdAsync(int id);
    void Update(Project project);
}
