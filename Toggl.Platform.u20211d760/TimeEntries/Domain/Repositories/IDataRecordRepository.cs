using Toggl.Platform.u20211d760.Shared.Domain.Repositories;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Aggregates;

namespace Toggl.Platform.u20211d760.TimeEntries.Domain.Repositories;

/// <summary>
/// Repository interface for data records.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public interface IDataRecordRepository : IBaseRepository<DataRecord>
{
}
