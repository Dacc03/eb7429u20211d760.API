using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.ValueObjects;

namespace Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Commands;

/// <summary>
/// Command to create a data record.
/// </summary>
/// <param name="PotMacAddress">The MAC address of the pot.</param>
/// <param name="OperationMode">The operation mode.</param>
/// <param name="TargetHumidityLevel">The target humidity level.</param>
/// <param name="CurrentHumidityLevel">The current humidity level.</param>
/// <param name="OperationPhase">The operation phase.</param>
/// <param name="EmittedAt">The emission date and time.</param>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public record CreateDataRecordCommand(
    string PotMacAddress,
    EOperationMode OperationMode,
    decimal TargetHumidityLevel,
    decimal CurrentHumidityLevel,
    EOperationPhase OperationPhase,
    DateTime EmittedAt);
