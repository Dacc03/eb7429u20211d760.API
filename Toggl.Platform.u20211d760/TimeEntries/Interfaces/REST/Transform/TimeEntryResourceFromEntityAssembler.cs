using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Aggregates;
using Toggl.Platform.u20211d760.TimeEntries.Interfaces.REST.Resources;

namespace Toggl.Platform.u20211d760.TimeEntries.Interfaces.REST.Transform;

/// <summary>
/// Assembles time entry entities into resources.
/// </summary>
/// <remarks>
/// Author: July Zelmira Paico Calderon
/// </remarks>
public static class TimeEntryResourceFromEntityAssembler
{
    /// <summary>
    /// Maps a <see cref="TimeEntry"/> to a <see cref="TimeEntryResource"/>.
    /// </summary>
    /// <param name="entity">The time entry entity.</param>
    /// <returns>The corresponding resource.</returns>
    public static TimeEntryResource ToResourceFromEntity(TimeEntry entity)
    {
        return new TimeEntryResource(
            entity.Id,
            entity.ProjectId,
            entity.UserId,
            entity.Description,
            entity.DurationMinutes,
            entity.EntryStatus.ToString(),
            entity.StartedAt.ToString("yyyy-MM-dd HH:mm:ss"));
    }
}
