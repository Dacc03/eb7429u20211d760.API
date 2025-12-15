using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Commands;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.ValueObjects;

namespace Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Aggregates;

/// <summary>
/// Represents a registered time entry.
/// </summary>
/// <remarks>
/// Author: Rafael Oswaldo Castro Veramendi
/// </remarks>
public class TimeEntry : IHasCreatedUpdatedDate
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TimeEntry"/> class for EF Core.
    /// </summary>
    public TimeEntry()
    {
        EntryStatus = EEntryStatus.RUNNING;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TimeEntry"/> class.
    /// </summary>
    /// <param name="command">The create command.</param>
    public TimeEntry(CreateTimeEntryCommand command)
    {
        ProjectId = command.ProjectId;
        UserId = command.UserId;
        Description = command.Description;
        DurationMinutes = command.DurationMinutes;
        EntryStatus = command.EntryStatus;
        StartedAt = command.StartedAt;
    }

    /// <summary>
    /// Gets the identifier.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Gets the project identifier.
    /// </summary>
    public int ProjectId { get; private set; }

    /// <summary>
    /// Gets the user identifier.
    /// </summary>
    public int UserId { get; private set; }

    /// <summary>
    /// Gets the description.
    /// </summary>
    public string Description { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the duration in minutes.
    /// </summary>
    public int DurationMinutes { get; private set; }

    /// <summary>
    /// Gets the entry status.
    /// </summary>
    public EEntryStatus EntryStatus { get; private set; }

    /// <summary>
    /// Gets the starting timestamp.
    /// </summary>
    public DateTime StartedAt { get; private set; }

    /// <summary>
    /// Gets or sets the record creation timestamp.
    /// </summary>
    [Column("created_at")]
    public DateTimeOffset? CreatedDate { get; set; }

    /// <summary>
    /// Gets or sets the record update timestamp.
    /// </summary>
    [Column("updated_at")]
    public DateTimeOffset? UpdatedDate { get; set; }
}
