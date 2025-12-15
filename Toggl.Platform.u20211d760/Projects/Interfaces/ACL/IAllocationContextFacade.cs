namespace Toggl.Platform.u20211d760.Projects.Interfaces.ACL;

/// <summary>
/// Public interface for the Projects context facade.
/// </summary>
/// <remarks>
/// Author: July Zelmira Paico Calderon
/// </remarks>
public interface IProjectsContextFacade
{
    Task<bool> ExistsProjectAsync(int projectId);
}
