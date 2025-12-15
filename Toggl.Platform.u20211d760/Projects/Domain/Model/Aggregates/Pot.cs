using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;
using Toggl.Platform.u20211d760.Projects.Domain.Model.ValueObjects;

namespace Toggl.Platform.u20211d760.Projects.Domain.Model.Aggregates;

/// <summary>
/// Represents a pot in the allocation context.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public class Pot : IHasCreatedUpdatedDate
{
    /// <summary>
    /// Default constructor for EF Core.
    /// </summary>
    public Pot()
    {
        MacAddress = new MacAddress();
    }

    /// <summary>
    /// Constructor with parameters.
    /// </summary>
    /// <param name="macAddress">The MAC address.</param>
    /// <param name="customerId">The customer identifier.</param>
    /// <param name="preferredHumidityLevel">The preferred humidity level.</param>
    public Pot(MacAddress macAddress, int customerId, decimal preferredHumidityLevel)
    {
        if (customerId <= 0)
            throw new ArgumentException("CustomerId must be positive", nameof(customerId));

        if (preferredHumidityLevel <= 0)
            throw new ArgumentException("Preferred humidity level must be positive", nameof(preferredHumidityLevel));
        MacAddress = macAddress;
        CustomerId = customerId;
        PreferredHumidityLevel = preferredHumidityLevel;
    }

    /// <summary>
    /// Constructor with string MAC address.
    /// </summary>
    /// <param name="macAddress">The MAC address string.</param>
    /// <param name="customerId">The customer identifier.</param>
    /// <param name="preferredHumidityLevel">The preferred humidity level.</param>
    public Pot(string macAddress, int customerId, decimal preferredHumidityLevel)
        : this(new MacAddress(macAddress), customerId, preferredHumidityLevel)
    {
    }

    /// <summary>
    /// Gets the identifier.
    /// </summary>
    public int Id { get; private set; }
    
    /// <summary>
    /// Gets the MAC address.
    /// </summary>
    public MacAddress MacAddress { get; private set; }

    /// <summary>
    /// Gets the customer identifier.
    /// </summary>
    public int CustomerId { get; private set; }

    /// <summary>
    /// Gets or sets the preferred humidity level.
    /// </summary>
    public decimal PreferredHumidityLevel { get; set; }

    /// <summary>
    /// Gets or sets the creation date and time.
    /// </summary>
    [Column("created_at")]
    public DateTimeOffset? CreatedDate { get; set; }

    /// <summary>
    /// Gets or sets the last update date and time.
    /// </summary>
    [Column("updated_at")]
    public DateTimeOffset? UpdatedDate { get; set; }

    /// <summary>
    /// Updates the preferred humidity level.
    /// </summary>
    /// <param name="newLevel">The new humidity level.</param>
    public void UpdatePreferredHumidityLevel(decimal newLevel)
    {
        PreferredHumidityLevel = newLevel;
    }
}
