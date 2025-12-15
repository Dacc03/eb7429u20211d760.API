using Toggl.Platform.u20211d760.Projects.Domain.Model.Aggregates;
using Toggl.Platform.u20211d760.Projects.Interfaces.REST.Resources;

namespace Toggl.Platform.u20211d760.Projects.Interfaces.REST.Transform;

/// <summary>
/// Assembles project entities into resources.
/// </summary>
/// <remarks>
/// Author: July Zelmira Paico Calderon
/// </remarks>
public static class ProjectResourceFromEntityAssembler
{
    /// <summary>
    /// Maps a <see cref="Project"/> to a <see cref="ProjectResource"/>.
    /// </summary>
    /// <param name="entity">The project entity.</param>
    /// <returns>The corresponding resource.</returns>
    public static ProjectResource ToResourceFromEntity(Project entity)
    {
        return new ProjectResource(
            entity.Id,
            entity.WorkSpaceId,
            entity.Name,
            entity.Billable,
            entity.Status.ToString(),
            entity.CreatedBy.Value);
    }
}
