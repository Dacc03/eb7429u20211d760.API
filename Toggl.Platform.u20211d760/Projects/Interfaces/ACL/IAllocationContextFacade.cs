namespace Toggl.Platform.u20211d760.Projects.Interfaces.ACL;

/// <summary>
/// Public interface for the Projects context facade.
/// </summary>
/// <remarks>
/// Author: Rafael Oswaldo Castro Veramendi
/// </remarks>
public interface IProjectsContextFacade
{
    Task<bool> ExistsProjectAsync(int projectId);
}
