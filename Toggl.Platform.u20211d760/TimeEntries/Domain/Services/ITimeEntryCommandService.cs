using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Aggregates;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Commands;

namespace Toggl.Platform.u20211d760.TimeEntries.Domain.Services;

/// <summary>
/// Service for time entry commands.
/// </summary>
/// <remarks>
/// Author: July Zelmira Paico Calderon
/// </remarks>
public interface ITimeEntryCommandService
{
    Task<TimeEntry> Handle(CreateTimeEntryCommand command);
}
