using Cortex.Mediator.Notifications;
using Toggl.Platform.u20211d760.Shared.Domain.Model.Events;

namespace Toggl.Platform.u20211d760.Shared.Application.Internal.EventHandlers;

/// <summary>
/// Base interface for event handlers.
/// </summary>
/// <typeparam name="TEvent">The type of event to handle.</typeparam>
/// <remarks>
/// Author: July Zelmira Paico Calderon
/// </remarks>
public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent, INotification
{
}