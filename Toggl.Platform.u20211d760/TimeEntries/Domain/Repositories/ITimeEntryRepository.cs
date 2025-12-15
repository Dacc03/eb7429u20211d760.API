using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Aggregates;

namespace Toggl.Platform.u20211d760.TimeEntries.Domain.Repositories;

/// <summary>
/// Contract for time entry persistence operations.
/// </summary>
/// <remarks>
/// Author: July Zelmira Paico Calderon
/// </remarks>
public interface ITimeEntryRepository
{
    Task AddAsync(TimeEntry timeEntry);
    Task<IEnumerable<TimeEntry>> ListByProjectIdAsync(int projectId);
}
