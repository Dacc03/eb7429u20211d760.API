using Microsoft.EntityFrameworkCore;
using Toggl.Platform.u20211d760.Projects.Domain.Model.Aggregates;
using Toggl.Platform.u20211d760.Projects.Domain.Repositories;
using Toggl.Platform.u20211d760.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Toggl.Platform.u20211d760.Projects.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Entity Framework Core repository for projects.
/// </summary>
/// <remarks>
/// Author: Rafael Oswaldo Castro Veramendi
/// </remarks>
public class ProjectRepository(AppDbContext context) : BaseRepository<Project>(context), IProjectRepository
{
    /// <inheritdoc />
    public async Task AddAsync(Project project)
    {
        await Context.Set<Project>().AddAsync(project);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Project>> ListAsync()
    {
        return await Context.Set<Project>().ToListAsync();
    }

    /// <inheritdoc />
    public async Task<Project?> FindByIdAsync(int id)
    {
        return await Context.Set<Project>().FirstOrDefaultAsync(p => p.Id == id);
    }

    /// <inheritdoc />
    public void Update(Project project)
    {
        Context.Set<Project>().Update(project);
    }
}
