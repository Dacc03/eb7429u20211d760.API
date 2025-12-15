namespace Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Queries;

/// <summary>
/// Query to retrieve a data record by identifier.
/// </summary>
/// <param name="DataRecordId">The data record identifier.</param>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public record GetDataRecordByIdQuery(int DataRecordId);
