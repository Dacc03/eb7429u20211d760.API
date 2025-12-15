using System.Text.RegularExpressions;

namespace Toggl.Platform.u20211d760.Projects.Domain.Model.ValueObjects;

/// <summary>
/// Represents the creator identifier for a project.
/// </summary>
/// <remarks>
/// Author: July Zelmira Paico Calderon
/// </remarks>
public record CreatedBy
{
    private static readonly Regex GuidPattern =
        new("^[{(]?[0-9A-Fa-f]{8}(-[0-9A-Fa-f]{4}){3}-[0-9A-Fa-f]{12}[)}]?$", RegexOptions.Compiled);

    /// <summary>
    /// Initializes a new instance of the <see cref="CreatedBy"/> record.
    /// </summary>
    public CreatedBy() : this(Guid.Empty.ToString())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CreatedBy"/> record.
    /// </summary>
    /// <param name="value">The creator identifier string.</param>
    /// <exception cref="ArgumentException">Thrown when the value is not a valid GUID.</exception>
    public CreatedBy(string value)
    {
        if (!IsValid(value))
            throw new ArgumentException("CreatedBy must be a valid GUID", nameof(value));

        Value = value;
    }

    /// <summary>
    /// Gets the underlying string value.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Determines whether the supplied value is a valid GUID string.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <returns>true when the value matches the GUID format; otherwise, false.</returns>
    public static bool IsValid(string value) => GuidPattern.IsMatch(value);
}
