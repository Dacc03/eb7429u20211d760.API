using Cortex.Mediator;
using Toggl.Platform.u20211d760.Projects.Interfaces.ACL;
using Toggl.Platform.u20211d760.Shared.Domain.Model.Events;
using Toggl.Platform.u20211d760.Shared.Domain.Repositories;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Aggregates;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Commands;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.ValueObjects;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Repositories;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Services;

namespace Toggl.Platform.u20211d760.TimeEntries.Application.Internal.CommandServices;

/// <summary>
/// Service implementation for data record commands.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public class DataRecordCommandService(
    IDataRecordRepository dataRecordRepository,
    IProjectsContextFacade allocationContextFacade,
    IUnitOfWork unitOfWork,
    IMediator mediator) : IDataRecordCommandService
{
    /// <inheritdoc />
    public async Task<DataRecord?> Handle(CreateDataRecordCommand command)
    {
        // Validate MAC Address format
        if (!MacAddress.IsValid(command.PotMacAddress))
            throw new ArgumentException("Invalid MAC Address format", nameof(command.PotMacAddress));

        // Validate target humidity level range
        if (command.TargetHumidityLevel < 40.0m || command.TargetHumidityLevel > 90.0m)
            throw new ArgumentException("Target humidity level must be between 40.0 and 90.0", 
                nameof(command.TargetHumidityLevel));

        // Validate humidity levels are positive
        if (command.TargetHumidityLevel <= 0 || command.CurrentHumidityLevel <= 0)
            throw new ArgumentException("Humidity levels must be positive");

        // Validate emittedAt is not in the future
        if (command.EmittedAt > DateTime.Now)
            throw new ArgumentException("EmittedAt cannot be in the future", nameof(command.EmittedAt));

        // Verify pot exists via ACL
        var potExists = await allocationContextFacade.ExistsPotByMacAddress(command.PotMacAddress);
        if (!potExists)
            throw new InvalidOperationException("Pot with specified MAC Address does not exist");

        // Create and persist data record
        var dataRecord = new DataRecord(command);
        await dataRecordRepository.AddAsync(dataRecord);
        await unitOfWork.CompleteAsync();

        // Emit integration event
        var dataRecordRegisteredEvent = new DataRecordRegisteredEvent(
            command.PotMacAddress,
            command.TargetHumidityLevel);
        
        await mediator.PublishAsync(dataRecordRegisteredEvent);

        return dataRecord;
    }
}
