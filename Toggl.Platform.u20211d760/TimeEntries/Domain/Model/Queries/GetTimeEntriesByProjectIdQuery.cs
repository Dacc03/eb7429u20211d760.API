namespace Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Queries;

/// <summary>
/// Query for retrieving time entries by project identifier.
/// </summary>
/// <remarks>
/// Author: Rafael Oswaldo Castro Veramendi
/// </remarks>
public record GetTimeEntriesByProjectIdQuery(int ProjectId);
