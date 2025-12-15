using Toggl.Platform.u20211d760.Projects.Domain.Model.Aggregates;
using Toggl.Platform.u20211d760.Projects.Domain.Model.Queries;

namespace Toggl.Platform.u20211d760.Projects.Domain.Services;

/// <summary>
/// Service interface for pot queries.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public interface IPotQueryService
{
    /// <summary>
    /// Handles the get all pots query.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <returns>The list of pots.</returns>
    Task<IEnumerable<Pot>> Handle(GetAllPotsQuery query);

    /// <summary>
    /// Handles the get pot by MAC address query.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <returns>The pot or null if not found.</returns>
    Task<Pot?> Handle(GetPotByMacAddressQuery query);
}
