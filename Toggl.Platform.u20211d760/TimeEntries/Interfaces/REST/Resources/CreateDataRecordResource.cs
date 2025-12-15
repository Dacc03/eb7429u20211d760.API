namespace Toggl.Platform.u20211d760.TimeEntries.Interfaces.REST.Resources;

/// <summary>
/// Resource for creating a data record.
/// </summary>
/// <param name="PotMacAddress">The MAC address of the pot.</param>
/// <param name="OperationMode">The operation mode (STAND_BY or OPERATING).</param>
/// <param name="TargetHumidityLevel">The target humidity level (40.0-90.0).</param>
/// <param name="CurrentHumidityLevel">The current humidity level.</param>
/// <param name="OperationPhase">The operation phase (WAITING or WATERING).</param>
/// <param name="EmittedAt">The emission date and time (format: yyyy-MM-dd HH:mm:ss).</param>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public record CreateDataRecordResource(
    string PotMacAddress,
    string OperationMode,
    decimal TargetHumidityLevel,
    decimal CurrentHumidityLevel,
    string OperationPhase,
    string EmittedAt);
