using Toggl.Platform.u20211d760.Projects.Domain.Model.Aggregates;
using Toggl.Platform.u20211d760.Shared.Domain.Repositories;

namespace Toggl.Platform.u20211d760.Projects.Domain.Repositories;

/// <summary>
/// Repository interface for pots.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public interface IPotRepository : IBaseRepository<Pot>
{
    /// <summary>
    /// Finds a pot by its MAC address.
    /// </summary>
    /// <param name="macAddress">The MAC address.</param>
    /// <returns>The pot or null if not found.</returns>
    Task<Pot?> FindByMacAddressAsync(string macAddress);
}
