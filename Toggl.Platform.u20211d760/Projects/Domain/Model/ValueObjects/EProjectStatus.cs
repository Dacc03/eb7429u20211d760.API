namespace Toggl.Platform.u20211d760.Projects.Domain.Model.ValueObjects;

/// <summary>
/// Represents the lifecycle status of a project.
/// </summary>
/// <remarks>
/// Author: Rafael Oswaldo Castro Veramendi
/// </remarks>
public enum EProjectStatus
{
    CREATED = 0,
    VALIDATED = 1,
    PROCESSING = 2,
    SUCCESS = 3
}
