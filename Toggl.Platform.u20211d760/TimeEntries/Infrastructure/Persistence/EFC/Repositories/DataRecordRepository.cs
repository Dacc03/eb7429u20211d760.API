using Toggl.Platform.u20211d760.Shared.Infrastructure.Persistence.EFC.Configuration;
using Toggl.Platform.u20211d760.Shared.Infrastructure.Persistence.EFC.Repositories;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Aggregates;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Repositories;

namespace Toggl.Platform.u20211d760.TimeEntries.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Repository implementation for data records.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public class DataRecordRepository(AppDbContext context) : BaseRepository<DataRecord>(context), IDataRecordRepository
{
}
