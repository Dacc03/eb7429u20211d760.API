using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Toggl.Platform.u20211d760.Projects.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Toggl.Platform.u20211d760.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Toggl.Platform.u20211d760.TimeEntries.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Toggl.Platform.u20211d760.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
/// The application's database context using Entity Framework Core.
/// </summary>
/// <remarks>
/// Author: July Zelmira Paico Calderon
/// </remarks>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    /// <summary>
    /// Configures the database context options.
    /// </summary>
    /// <param name="builder">The options' builder.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Automatically set CreatedAt and UpdatedAt for entities
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    /// <summary>
    /// Configures the model for the database context.
    /// </summary>
    /// <param name="builder">The model builder.</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Apply TimeEntries context configurations
        builder.ApplyTimeEntriesConfiguration();

        // Apply Projects context configurations
        builder.ApplyProjectsConfiguration();

        // Apply naming convention to use snake_case for database objects
        builder.UseSnakeCaseNamingConvention();
    }
}
