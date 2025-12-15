namespace Toggl.Platform.u20211d760.TimeEntries.Interfaces.REST.Resources;

/// <summary>
/// Resource representing a data record.
/// </summary>
/// <param name="Id">The data record identifier.</param>
/// <param name="PotMacAddress">The MAC address of the pot.</param>
/// <param name="OperationMode">The operation mode.</param>
/// <param name="TargetHumidityLevel">The target humidity level.</param>
/// <param name="CurrentHumidityLevel">The current humidity level.</param>
/// <param name="OperationPhase">The operation phase.</param>
/// <param name="EmittedAt">The emission date and time.</param>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public record DataRecordResource(
    int Id,
    string PotMacAddress,
    string OperationMode,
    decimal TargetHumidityLevel,
    decimal CurrentHumidityLevel,
    string OperationPhase,
    string EmittedAt);
