using Toggl.Platform.u20211d760.Shared.Domain.Repositories;
using Toggl.Platform.u20211d760.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Toggl.Platform.u20211d760.Shared.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Base implementation of the repository pattern for entity types.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <remarks>
/// Author: July Zelmira Paico Calderon
/// </remarks>
public abstract class BaseRepository<TEntity>(AppDbContext context) : IBaseRepository<TEntity>
    where TEntity : class
{
    protected readonly AppDbContext Context = context;

    public async Task AddAsync(TEntity entity) => await Context.Set<TEntity>().AddAsync(entity);

    public async Task<TEntity?> FindByIdAsync(int id) => await Context.Set<TEntity>().FindAsync(id);

    public async Task<IEnumerable<TEntity>> ListAsync() => await Context.Set<TEntity>().ToListAsync();

    public void Update(TEntity entity) => Context.Set<TEntity>().Update(entity);

    public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);
}
