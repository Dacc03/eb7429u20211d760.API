using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;
using Toggl.Platform.u20211d760.Projects.Domain.Model.ValueObjects;

namespace Toggl.Platform.u20211d760.Projects.Domain.Model.Aggregates;

/// <summary>
/// Represents a Toggl project aggregate root.
/// </summary>
/// <remarks>
/// Author: Rafael Oswaldo Castro Veramendi
/// </remarks>
public class Project : IHasCreatedUpdatedDate
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Project"/> class for EF Core.
    /// </summary>
    public Project()
    {
        CreatedBy = new CreatedBy(Guid.Empty.ToString());
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Project"/> class.
    /// </summary>
    /// <param name="workSpaceId">The workspace identifier.</param>
    /// <param name="name">The project name.</param>
    /// <param name="billable">Indicates whether the project is billable.</param>
    /// <param name="status">The project status.</param>
    /// <param name="createdBy">The creator identifier.</param>
    public Project(int workSpaceId, string name, bool billable, EProjectStatus status, CreatedBy createdBy)
    {
        if (workSpaceId <= 0)
            throw new ArgumentException("WorkspaceId must be positive", nameof(workSpaceId));

        if (string.IsNullOrWhiteSpace(name) || name.Length > 60)
            throw new ArgumentException("Name is required and must be at most 60 characters", nameof(name));

        WorkSpaceId = workSpaceId;
        Name = name;
        Billable = billable;
        Status = status;
        CreatedBy = createdBy;
    }

    /// <summary>
    /// Gets the project identifier.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Gets the workspace identifier.
    /// </summary>
    public int WorkSpaceId { get; private set; }

    /// <summary>
    /// Gets the project name.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Gets a value indicating whether the project is billable.
    /// </summary>
    public bool Billable { get; private set; }

    /// <summary>
    /// Gets the project status.
    /// </summary>
    public EProjectStatus Status { get; private set; }

    /// <summary>
    /// Gets the creator identifier.
    /// </summary>
    public CreatedBy CreatedBy { get; private set; }

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

    /// <summary>
    /// Updates the project status when business rules require.
    /// </summary>
    /// <param name="status">The new status.</param>
    public void UpdateStatus(EProjectStatus status)
    {
        Status = status;
    }
}
