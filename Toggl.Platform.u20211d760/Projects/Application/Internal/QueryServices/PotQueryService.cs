using Toggl.Platform.u20211d760.Projects.Domain.Model.Aggregates;
using Toggl.Platform.u20211d760.Projects.Domain.Model.Queries;
using Toggl.Platform.u20211d760.Projects.Domain.Repositories;
using Toggl.Platform.u20211d760.Projects.Domain.Services;

namespace Toggl.Platform.u20211d760.Projects.Application.Internal.QueryServices;

/// <summary>
/// Service implementation for pot queries.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public class PotQueryService(IPotRepository potRepository) : IPotQueryService
{
    /// <inheritdoc />
    public async Task<IEnumerable<Pot>> Handle(GetAllPotsQuery query)
    {
        return await potRepository.ListAsync();
    }

    /// <inheritdoc />
    public async Task<Pot?> Handle(GetPotByMacAddressQuery query)
    {
        return await potRepository.FindByMacAddressAsync(query.MacAddress);
    }
}
