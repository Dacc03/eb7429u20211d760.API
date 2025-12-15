using Toggl.Platform.u20211d760.Projects.Domain.Model.Queries;
using Toggl.Platform.u20211d760.Projects.Domain.Services;
using Toggl.Platform.u20211d760.Projects.Interfaces.ACL;

namespace Toggl.Platform.u20211d760.Projects.Application.ACL.Services;

/// <summary>
/// Facade for the Projects context.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public class ProjectsContextFacade(IPotQueryService potQueryService) : IProjectsContextFacade
{
    public async Task<bool> ExistsPotByMacAddress(string macAddress)
    {
        var pot = await potQueryService.Handle(new GetPotByMacAddressQuery(macAddress));
        return pot != null;
    }

    public async Task<int> FetchPotIdByMacAddress(string macAddress)
    {
        var pot = await potQueryService.Handle(new GetPotByMacAddressQuery(macAddress));
        return pot?.Id ?? 0;
    }
}
