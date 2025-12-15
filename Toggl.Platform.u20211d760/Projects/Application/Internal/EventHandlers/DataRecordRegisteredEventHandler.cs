using Toggl.Platform.u20211d760.Projects.Domain.Repositories;
using Toggl.Platform.u20211d760.Shared.Application.Internal.EventHandlers;
using Toggl.Platform.u20211d760.Shared.Domain.Model.Events;
using Toggl.Platform.u20211d760.Shared.Domain.Repositories;

namespace Toggl.Platform.u20211d760.Projects.Application.Internal.EventHandlers;

/// <summary>
/// Event handler for DataRecordRegisteredEvent.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public class DataRecordRegisteredEventHandler(
    IPotRepository potRepository,
    IUnitOfWork unitOfWork) : IEventHandler<DataRecordRegisteredEvent>
{
    public async Task Handle(DataRecordRegisteredEvent notification, CancellationToken cancellationToken = default)
    {
        var pot = await potRepository.FindByMacAddressAsync(notification.PotMacAddress);
        
        if (pot == null) return;

        if (pot.PreferredHumidityLevel != notification.TargetHumidityLevel)
        {
            pot.UpdatePreferredHumidityLevel(notification.TargetHumidityLevel);
            potRepository.Update(pot);
            await unitOfWork.CompleteAsync();
        }
    }
}