using Cortex.Mediator;
using Toggl.Platform.u20211d760.Projects.Interfaces.ACL;
using Toggl.Platform.u20211d760.Shared.Domain.Model.Events;
using Toggl.Platform.u20211d760.Shared.Domain.Repositories;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Aggregates;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Commands;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Repositories;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Services;

namespace Toggl.Platform.u20211d760.TimeEntries.Application.Internal.CommandServices;

/// <summary>
/// Handles commands related to time entries.
/// </summary>
/// <remarks>
/// Author: Rafael Oswaldo Castro Veramendi
/// </remarks>
public class TimeEntryCommandService(
    ITimeEntryRepository timeEntryRepository,
    IProjectsContextFacade projectsContextFacade,
    IUnitOfWork unitOfWork,
    IMediator mediator) : ITimeEntryCommandService
{
    /// <inheritdoc />
    public async Task<TimeEntry> Handle(CreateTimeEntryCommand command)
    {
        if (command.ProjectId <= 0)
            throw new ArgumentException("ProjectId must be positive", nameof(command.ProjectId));

        if (command.UserId <= 0)
            throw new ArgumentException("UserId must be positive", nameof(command.UserId));

        if (string.IsNullOrWhiteSpace(command.Description))
            throw new ArgumentException("Description is required", nameof(command.Description));

        if (command.DurationMinutes <= 0)
            throw new ArgumentException("DurationMinutes must be greater than zero", nameof(command.DurationMinutes));

        if (command.StartedAt > DateTime.Now)
            throw new ArgumentException("StartedAt cannot be in the future", nameof(command.StartedAt));

        var projectExists = await projectsContextFacade.ExistsProjectAsync(command.ProjectId);
        if (!projectExists)
            throw new InvalidOperationException("Project does not exist");

        var timeEntry = new TimeEntry(command);
        await timeEntryRepository.AddAsync(timeEntry);
        await unitOfWork.CompleteAsync();

        var integrationEvent = new TimeEntryRegisteredEvent(command.ProjectId, command.DurationMinutes);
        await mediator.PublishAsync(integrationEvent);

        return timeEntry;
    }
}
