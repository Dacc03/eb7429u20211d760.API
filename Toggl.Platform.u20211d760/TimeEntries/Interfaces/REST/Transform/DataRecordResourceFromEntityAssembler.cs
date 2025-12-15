using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Aggregates;
using Toggl.Platform.u20211d760.TimeEntries.Interfaces.REST.Resources;

namespace Toggl.Platform.u20211d760.TimeEntries.Interfaces.REST.Transform;

/// <summary>
/// Assembler to transform DataRecord entity to DataRecordResource.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public static class DataRecordResourceFromEntityAssembler
{
    /// <summary>
    /// Transforms a DataRecord entity to a DataRecordResource.
    /// </summary>
    /// <param name="entity">The DataRecord entity.</param>
    /// <returns>The DataRecordResource.</returns>
    public static DataRecordResource ToResourceFromEntity(DataRecord entity)
    {
        return new DataRecordResource(
            entity.Id,
            entity.PotMacAddress.Address,
            entity.OperationMode.ToString(),
            entity.TargetHumidityLevel,
            entity.CurrentHumidityLevel,
            entity.OperationPhase.ToString(),
            entity.EmittedAt.ToString("yyyy-MM-dd HH:mm:ss"));
    }
}
