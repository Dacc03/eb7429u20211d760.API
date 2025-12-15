using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Aggregates;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Queries;

namespace Toggl.Platform.u20211d760.TimeEntries.Domain.Services;

/// <summary>
/// Service interface for data record queries.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public interface IDataRecordQueryService
{
    /// <summary>
    /// Handles the get data record by identifier query.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <returns>The data record or null if not found.</returns>
    Task<DataRecord?> Handle(GetDataRecordByIdQuery query);

    /// <summary>
    /// Handles the get all data records query.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <returns>The list of data records.</returns>
    Task<IEnumerable<DataRecord>> Handle(GetAllDataRecordsQuery query);
}
