using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.ValueObjects;

namespace Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Commands;

/// <summary>
/// Command for creating a time entry.
/// </summary>
/// <remarks>
/// Author: July Zelmira Paico Calderon
/// </remarks>
public record CreateTimeEntryCommand(
    int ProjectId,
    int UserId,
    string Description,
    int DurationMinutes,
    EEntryStatus EntryStatus,
    DateTime StartedAt);
