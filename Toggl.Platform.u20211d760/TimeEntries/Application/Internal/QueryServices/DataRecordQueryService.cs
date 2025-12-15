using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Aggregates;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Queries;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Repositories;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Services;

namespace Toggl.Platform.u20211d760.TimeEntries.Application.Internal.QueryServices;

/// <summary>
/// Service implementation for data record queries.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public class DataRecordQueryService(IDataRecordRepository dataRecordRepository) : IDataRecordQueryService
{
    /// <inheritdoc />
    public async Task<DataRecord?> Handle(GetDataRecordByIdQuery query)
    {
        return await dataRecordRepository.FindByIdAsync(query.DataRecordId);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<DataRecord>> Handle(GetAllDataRecordsQuery query)
    {
        return await dataRecordRepository.ListAsync();
    }
}
