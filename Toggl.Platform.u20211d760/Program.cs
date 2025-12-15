using Cortex.Mediator.DependencyInjection;
using Toggl.Platform.u20211d760.Projects.Application.ACL.Services;
using Toggl.Platform.u20211d760.Projects.Application.Internal.EventHandlers;
using Toggl.Platform.u20211d760.Projects.Application.Internal.QueryServices;
using Toggl.Platform.u20211d760.Projects.Domain.Repositories;
using Toggl.Platform.u20211d760.Projects.Domain.Services;
using Toggl.Platform.u20211d760.Projects.Infrastructure.Persistence.EFC.Repositories;
using Toggl.Platform.u20211d760.Projects.Interfaces.ACL;
using Toggl.Platform.u20211d760.Shared.Application.Internal.EventHandlers;
using Toggl.Platform.u20211d760.Shared.Domain.Model.Events;
using Toggl.Platform.u20211d760.Shared.Infrastructure.Documentation.OpenApi.Configuration.Extensions;
using Toggl.Platform.u20211d760.Shared.Infrastructure.Interfaces.ASP.Configuration;
using Toggl.Platform.u20211d760.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Toggl.Platform.u20211d760.TimeEntries.Application.Internal.CommandServices;
using Toggl.Platform.u20211d760.TimeEntries.Application.Internal.QueryServices;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Repositories;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Services;
using Toggl.Platform.u20211d760.TimeEntries.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});

// Add Database Services
builder.AddDatabaseServices();

// Register repositories
builder.Services.AddScoped<ITimeEntryRepository, TimeEntryRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

// Register services
builder.Services.AddScoped<ITimeEntryCommandService, TimeEntryCommandService>();
builder.Services.AddScoped<ITimeEntryQueryService, TimeEntryQueryService>();
builder.Services.AddScoped<IProjectQueryService, ProjectQueryService>();

// Register ACL
builder.Services.AddScoped<IProjectsContextFacade, ProjectsContextFacade>();

// Register Event Handlers
builder.Services.AddScoped<IEventHandler<TimeEntryRegisteredEvent>, TimeEntryRegisteredEventHandler>();

// Add Cortex Mediator
builder.Services.AddCortexMediator(builder.Configuration, new[] { typeof(Program) });

// Add Localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// Configure OpenAPI/Swagger
builder.AddOpenApiDocumentationServices();

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseDatabaseCreationAssurance();

// Configure supported cultures for localization
var supportedCultures = new[] { "en", "en-US", "es", "es-PE" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("en")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.UseOpenApiDocumentation();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();