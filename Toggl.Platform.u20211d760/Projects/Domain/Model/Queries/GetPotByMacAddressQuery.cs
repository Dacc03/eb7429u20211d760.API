namespace Toggl.Platform.u20211d760.Projects.Domain.Model.Queries;

/// <summary>
/// Query to retrieve a pot by MAC address.
/// </summary>
/// <param name="MacAddress">The MAC address.</param>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public record GetPotByMacAddressQuery(string MacAddress);
