using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Aggregates;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Queries;

namespace Toggl.Platform.u20211d760.TimeEntries.Domain.Services;

/// <summary>
/// Service for time entry queries.
/// </summary>
/// <remarks>
/// Author: July Zelmira Paico Calderon
/// </remarks>
public interface ITimeEntryQueryService
{
    Task<IEnumerable<TimeEntry>> Handle(GetTimeEntriesByProjectIdQuery query);
    Task<int> CalculateTotalDurationAsync(int projectId);
}
