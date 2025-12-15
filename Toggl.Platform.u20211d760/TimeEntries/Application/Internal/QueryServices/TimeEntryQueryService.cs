using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Aggregates;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Queries;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Repositories;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Services;

namespace Toggl.Platform.u20211d760.TimeEntries.Application.Internal.QueryServices;

/// <summary>
/// Provides query capabilities for time entries.
/// </summary>
/// <remarks>
/// Author: Rafael Oswaldo Castro Veramendi
/// </remarks>
public class TimeEntryQueryService(ITimeEntryRepository timeEntryRepository) : ITimeEntryQueryService
{
    /// <inheritdoc />
    public async Task<IEnumerable<TimeEntry>> Handle(GetTimeEntriesByProjectIdQuery query)
    {
        return await timeEntryRepository.ListByProjectIdAsync(query.ProjectId);
    }

    /// <inheritdoc />
    public async Task<int> CalculateTotalDurationAsync(int projectId)
    {
        var entries = await timeEntryRepository.ListByProjectIdAsync(projectId);
        return entries.Sum(entry => entry.DurationMinutes);
    }
}
