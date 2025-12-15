using Toggl.Platform.u20211d760.Shared.Domain.Repositories;
using Toggl.Platform.u20211d760.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace Toggl.Platform.u20211d760.Shared.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Implementation of the unit of work pattern.
/// </summary>
/// <remarks>
/// Author: July Zelmira Paico Calderon
/// </remarks>
public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task<int> CompleteAsync() => await context.SaveChangesAsync();
}
