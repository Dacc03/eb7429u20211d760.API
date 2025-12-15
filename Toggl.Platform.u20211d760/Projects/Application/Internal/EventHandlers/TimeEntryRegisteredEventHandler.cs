using Toggl.Platform.u20211d760.Projects.Domain.Repositories;
using Toggl.Platform.u20211d760.Shared.Application.Internal.EventHandlers;
using Toggl.Platform.u20211d760.Shared.Domain.Model.Events;
using Toggl.Platform.u20211d760.Shared.Domain.Repositories;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Services;
using Toggl.Platform.u20211d760.Projects.Domain.Model.ValueObjects;

namespace Toggl.Platform.u20211d760.Projects.Application.Internal.EventHandlers;

/// <summary>
/// Handles the <see cref="TimeEntryRegisteredEvent"/> to update project progress.
/// </summary>
/// <remarks>
/// Author: Rafael Oswaldo Castro Veramendi
/// </remarks>
public class TimeEntryRegisteredEventHandler(
    IProjectRepository projectRepository,
    ITimeEntryQueryService timeEntryQueryService,
    IUnitOfWork unitOfWork) : IEventHandler<TimeEntryRegisteredEvent>
{
    /// <inheritdoc />
    public async Task Handle(TimeEntryRegisteredEvent notification, CancellationToken cancellationToken = default)
    {
        var project = await projectRepository.FindByIdAsync(notification.ProjectId);
        if (project == null) return;

        var totalMinutes = await timeEntryQueryService.CalculateTotalDurationAsync(notification.ProjectId);
        if (totalMinutes > 480 && project.Status != EProjectStatus.SUCCESS)
        {
            project.UpdateStatus(EProjectStatus.SUCCESS);
            projectRepository.Update(project);
            await unitOfWork.CompleteAsync();
        }
    }
}
