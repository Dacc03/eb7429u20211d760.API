using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Commands;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.ValueObjects;

namespace Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Aggregates;

/// <summary>
/// Represents a data record from a pot.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public class DataRecord : IHasCreatedUpdatedDate
{
    /// <summary>
    /// Default constructor for EF Core.
    /// </summary>
    public DataRecord()
    {
        PotMacAddress = new MacAddress();
        OperationMode = EOperationMode.STAND_BY;
        OperationPhase = EOperationPhase.WAITING;
    }

    /// <summary>
    /// Constructor with parameters.
    /// </summary>
    /// <param name="potMacAddress">The MAC address of the pot.</param>
    /// <param name="operationMode">The operation mode.</param>
    /// <param name="targetHumidityLevel">The target humidity level.</param>
    /// <param name="currentHumidityLevel">The current humidity level.</param>
    /// <param name="operationPhase">The operation phase.</param>
    /// <param name="emittedAt">The emission date and time.</param>
    public DataRecord(MacAddress potMacAddress, EOperationMode operationMode, decimal targetHumidityLevel,
        decimal currentHumidityLevel, EOperationPhase operationPhase, DateTime emittedAt)
    {
        PotMacAddress = potMacAddress;
        OperationMode = operationMode;
        TargetHumidityLevel = targetHumidityLevel;
        CurrentHumidityLevel = currentHumidityLevel;
        OperationPhase = operationPhase;
        EmittedAt = emittedAt;
    }

    /// <summary>
    /// Constructor from command.
    /// </summary>
    /// <param name="command">The create data record command.</param>
    public DataRecord(CreateDataRecordCommand command) : this(
        new MacAddress(command.PotMacAddress),
        command.OperationMode,
        command.TargetHumidityLevel,
        command.CurrentHumidityLevel,
        command.OperationPhase,
        command.EmittedAt)
    {
    }

    /// <summary>
    /// Gets the identifier.
    /// </summary>
    public int Id { get; private set; }
    /// <summary>
    /// Gets the MAC address of the pot.
    /// </summary>
    public MacAddress PotMacAddress { get; private set; }

    /// <summary>
    /// Gets the operation mode.
    /// </summary>
    public EOperationMode OperationMode { get; private set; }

    /// <summary>
    /// Gets the target humidity level.
    /// </summary>
    public decimal TargetHumidityLevel { get; private set; }

    /// <summary>
    /// Gets the current humidity level.
    /// </summary>
    public decimal CurrentHumidityLevel { get; private set; }

    /// <summary>
    /// Gets the operation phase.
    /// </summary>
    public EOperationPhase OperationPhase { get; private set; }

    /// <summary>
    /// Gets the emission date and time.
    /// </summary>
    public DateTime EmittedAt { get; private set; }

    /// <summary>
    /// Gets or sets the creation date and time.
    /// </summary>
    [Column("created_at")]
    public DateTimeOffset? CreatedDate { get; set; }

    /// <summary>
    /// Gets or sets the last update date and time.
    /// </summary>
    [Column("updated_at")]
    public DateTimeOffset? UpdatedDate { get; set; }
}
