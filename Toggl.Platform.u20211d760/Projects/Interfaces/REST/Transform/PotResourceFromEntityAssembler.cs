using Toggl.Platform.u20211d760.Projects.Domain.Model.Aggregates;
using Toggl.Platform.u20211d760.Projects.Interfaces.REST.Resources;

namespace Toggl.Platform.u20211d760.Projects.Interfaces.REST.Transform;

/// <summary>
/// Assembler to transform Pot entity to PotResource.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public static class PotResourceFromEntityAssembler
{
    /// <summary>
    /// Transforms a Pot entity to a PotResource.
    /// </summary>
    /// <param name="entity">The Pot entity.</param>
    /// <returns>The PotResource.</returns>
    public static PotResource ToResourceFromEntity(Pot entity)
    {
        return new PotResource(
            entity.Id,
            entity.MacAddress.Address,
            entity.CustomerId,
            entity.PreferredHumidityLevel);
    }
}
