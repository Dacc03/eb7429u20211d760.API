using System.Text.RegularExpressions;

namespace Toggl.Platform.u20211d760.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
/// Extension methods for string operations.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public static partial class StringExtensions
{
    /// <summary>
    /// Converts a string to snake_case format.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>The string in snake_case format.</returns>
    public static string ToSnakeCase(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        var startUnderscores = SnakeCaseRegex1().Match(input);
        return startUnderscores + SnakeCaseRegex2().Replace(input, "$1_$2").ToLower();
    }

    [GeneratedRegex("^_+")]
    private static partial Regex SnakeCaseRegex1();

    [GeneratedRegex("([a-z0-9])([A-Z])")]
    private static partial Regex SnakeCaseRegex2();
}
