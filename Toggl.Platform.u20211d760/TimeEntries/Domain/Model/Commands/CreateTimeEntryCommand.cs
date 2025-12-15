using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.ValueObjects;

namespace Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Commands;

/// <summary>
/// Command for creating a time entry.
/// </summary>
/// <remarks>
/// Author: Rafael Oswaldo Castro Veramendi
/// </remarks>
public record CreateTimeEntryCommand(
    int ProjectId,
    int UserId,
    string Description,
    int DurationMinutes,
    EEntryStatus EntryStatus,
    DateTime StartedAt);
