using Toggl.Platform.u20211d760.Projects.Domain.Model.Aggregates;
using Toggl.Platform.u20211d760.Projects.Domain.Repositories;
using Toggl.Platform.u20211d760.Shared.Infrastructure.Persistence.EFC.Configuration;
using Toggl.Platform.u20211d760.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Toggl.Platform.u20211d760.Projects.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Repository implementation for pots.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public class PotRepository(AppDbContext context) : BaseRepository<Pot>(context), IPotRepository
{
    public async Task<Pot?> FindByMacAddressAsync(string macAddress)
    {
        return await Context.Set<Pot>()
            .FirstOrDefaultAsync(p => p.MacAddress.Address == macAddress);
    }
}
