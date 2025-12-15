namespace Toggl.Platform.u20211d760.Projects.Interfaces.REST.Resources;

/// <summary>
/// Resource representing a pot.
/// </summary>
/// <param name="Id">The pot identifier.</param>
/// <param name="MacAddress">The MAC address.</param>
/// <param name="CustomerId">The customer identifier.</param>
/// <param name="PreferredHumidityLevel">The preferred humidity level.</param>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public record PotResource(
    int Id,
    string MacAddress,
    int CustomerId,
    decimal PreferredHumidityLevel);
