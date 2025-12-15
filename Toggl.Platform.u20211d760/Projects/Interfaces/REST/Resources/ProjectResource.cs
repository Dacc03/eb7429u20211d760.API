namespace Toggl.Platform.u20211d760.Projects.Interfaces.REST.Resources;

/// <summary>
/// Represents a project response resource.
/// </summary>
/// <remarks>
/// Author: Rafael Oswaldo Castro Veramendi
/// </remarks>
public record ProjectResource(
    int Id,
    int WorkSpaceId,
    string Name,
    bool Billable,
    string Status,
    string CreatedBy);
