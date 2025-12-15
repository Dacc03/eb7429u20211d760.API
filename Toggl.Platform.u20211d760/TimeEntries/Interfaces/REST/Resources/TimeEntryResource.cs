namespace Toggl.Platform.u20211d760.TimeEntries.Interfaces.REST.Resources;

/// <summary>
/// Represents a time entry response resource.
/// </summary>
/// <remarks>
/// Author: Rafael Oswaldo Castro Veramendi
/// </remarks>
public record TimeEntryResource(
    int Id,
    int ProjectId,
    int UserId,
    string Description,
    int DurationMinutes,
    string EntryStatus,
    string StartedAt);
