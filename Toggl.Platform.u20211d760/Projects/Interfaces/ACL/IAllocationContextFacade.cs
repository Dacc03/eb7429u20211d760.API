namespace Toggl.Platform.u20211d760.Projects.Interfaces.ACL;

/// <summary>
/// Public interface for the Projects context facade.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public interface IProjectsContextFacade
{
    Task<bool> ExistsPotByMacAddress(string macAddress);
    Task<int> FetchPotIdByMacAddress(string macAddress);
}
