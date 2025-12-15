using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Toggl.Platform.u20211d760.Shared.Infrastructure.Interfaces.ASP.Configuration;

/// <summary>
/// Convention to apply kebab-case naming to routes.
/// </summary>
/// <remarks>
/// Author: July Zelmira Paico Calderon
/// </remarks>
public partial class KebabCaseRouteNamingConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        foreach (var selector in controller.Selectors)
        {
            if (selector.AttributeRouteModel != null)
            {
                selector.AttributeRouteModel.Template = ToKebabCase(selector.AttributeRouteModel.Template);
            }
        }

        foreach (var action in controller.Actions)
        {
            foreach (var selector in action.Selectors)
            {
                if (selector.AttributeRouteModel != null)
                {
                    selector.AttributeRouteModel.Template = ToKebabCase(selector.AttributeRouteModel.Template);
                }
            }
        }
    }

    private static string ToKebabCase(string? value)
    {
        if (string.IsNullOrEmpty(value)) return value ?? string.Empty;

        return KebabCaseRegex()
            .Replace(value, "-$1")
            .Trim()
            .ToLower();
    }

    [GeneratedRegex("(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])")]
    private static partial Regex KebabCaseRegex();
}
