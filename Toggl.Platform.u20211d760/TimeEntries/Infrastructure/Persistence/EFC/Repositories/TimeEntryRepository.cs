using Microsoft.EntityFrameworkCore;
using Toggl.Platform.u20211d760.Shared.Infrastructure.Persistence.EFC.Repositories;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Aggregates;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Repositories;

namespace Toggl.Platform.u20211d760.TimeEntries.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Entity Framework Core repository for time entries.
/// </summary>
/// <remarks>
/// Author: Rafael Oswaldo Castro Veramendi
/// </remarks>
public class TimeEntryRepository(AppDbContext context) : BaseRepository<TimeEntry>(context), ITimeEntryRepository
{
    /// <inheritdoc />
    public async Task AddAsync(TimeEntry timeEntry)
    {
        await Context.Set<TimeEntry>().AddAsync(timeEntry);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<TimeEntry>> ListByProjectIdAsync(int projectId)
    {
        return await Context.Set<TimeEntry>().Where(entry => entry.ProjectId == projectId).ToListAsync();
    }
}
