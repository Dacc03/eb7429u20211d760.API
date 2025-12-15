using Toggl.Platform.u20211d760.Shared.Domain.Repositories;
using Toggl.Platform.u20211d760.Shared.Infrastructure.Persistence.EFC.Configuration;
using Toggl.Platform.u20211d760.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Toggl.Platform.u20211d760.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
/// Extension methods for configuring database services.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public static class WebApplicationBuilderExtensions
{
    /// <summary>
    /// Adds database services to the application.
    /// </summary>
    /// <param name="builder">The web application builder.</param>
    /// <returns>The web application builder.</returns>
    public static WebApplicationBuilder AddDatabaseServices(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseMySQL(connectionString!);
        });

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        return builder;
    }
}
