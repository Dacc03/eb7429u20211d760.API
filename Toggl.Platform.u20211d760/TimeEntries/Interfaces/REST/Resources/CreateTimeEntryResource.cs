namespace Toggl.Platform.u20211d760.TimeEntries.Interfaces.REST.Resources;

/// <summary>
/// Represents the payload required to create a time entry.
/// </summary>
/// <remarks>
/// Author: Rafael Oswaldo Castro Veramendi
/// </remarks>
public record CreateTimeEntryResource(
    int ProjectId,
    int UserId,
    string Description,
    int DurationMinutes,
    string EntryStatus,
    string StartedAt);
