using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.CreatedUpdatedDate.Contracts;

/// <summary>
/// Interface for entities that track creation and update timestamps.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public interface IHasCreatedUpdatedDate
{
    [Column("created_at")]
    DateTimeOffset? CreatedDate { get; set; }
    
    [Column("updated_at")]
    DateTimeOffset? UpdatedDate { get; set; }
}