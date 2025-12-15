using Cortex.Mediator;

namespace Toggl.Platform.u20211d760.Shared.Domain.Model.Events;

/// <summary>
/// Integration event emitted when a time entry is registered.
/// </summary>
/// <remarks>
/// Author: Rafael Oswaldo Castro Veramendi
/// </remarks>
public record TimeEntryRegisteredEvent(int ProjectId, int DurationMinutes) : IEvent;
