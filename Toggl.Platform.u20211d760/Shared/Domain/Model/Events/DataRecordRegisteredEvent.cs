using Cortex.Mediator.Notifications;

namespace Toggl.Platform.u20211d760.Shared.Domain.Model.Events;

/// <summary>
/// Integration event emitted when a data record is registered.
/// </summary>
/// <param name="PotMacAddress">The MAC address of the pot.</param>
/// <param name="TargetHumidityLevel">The target humidity level.</param>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public record DataRecordRegisteredEvent(string PotMacAddress, decimal TargetHumidityLevel) : IEvent, INotification;
