using Microsoft.OpenApi.Models;

namespace Toggl.Platform.u20211d760.Shared.Infrastructure.Documentation.OpenApi.Configuration.Extensions;

/// <summary>
/// Extension methods for configuring OpenAPI documentation services.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public static class WebApplicationBuilderExtensions
{
    /// <summary>
    /// Adds OpenAPI documentation services to the application.
    /// </summary>
    /// <param name="builder">The web application builder.</param>
    /// <returns>The web application builder.</returns>
    public static WebApplicationBuilder AddOpenApiDocumentationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Toggl Platform API",
                Version = "v1",
                Description = "RESTful API for LetPot Smart Self-Watering Planter operations",
                Contact = new OpenApiContact
                {
                    Name = "Antonio Rodrigo Duran Diaz",
                    Email = "u20211d760@upc.edu.pe"
                }
            });
            c.EnableAnnotations();
        });
        
        return builder;
    }
}