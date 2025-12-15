using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace Toggl.Platform.u20211d760.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
/// Extension methods for applying snake_case naming conventions to database objects.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public static class ModelBuilderExtensions
{
    /// <summary>
    /// Applies snake_case naming convention to all database objects.
    /// </summary>
    /// <param name="builder">The model builder.</param>
    public static void UseSnakeCaseNamingConvention(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            // Table names to snake_case and plural
            var tableName = entity.GetTableName();
            if (!string.IsNullOrEmpty(tableName))
            {
                entity.SetTableName(tableName.Underscore().Pluralize());
            }

            // Column names to snake_case
            foreach (var property in entity.GetProperties())
            {
                var columnName = property.GetColumnName();
                if (!string.IsNullOrEmpty(columnName))
                {
                    property.SetColumnName(columnName.Underscore());
                }
            }

            // Foreign key names to snake_case
            foreach (var key in entity.GetKeys())
            {
                var keyName = key.GetName();
                if (!string.IsNullOrEmpty(keyName))
                {
                    key.SetName(keyName.Underscore());
                }
            }

            // Index names to snake_case
            foreach (var index in entity.GetIndexes())
            {
                var indexName = index.GetDatabaseName();
                if (!string.IsNullOrEmpty(indexName))
                {
                    index.SetDatabaseName(indexName.Underscore());
                }
            }

            // Foreign key constraint names to snake_case
            foreach (var foreignKey in entity.GetForeignKeys())
            {
                var foreignKeyName = foreignKey.GetConstraintName();
                if (!string.IsNullOrEmpty(foreignKeyName))
                {
                    foreignKey.SetConstraintName(foreignKeyName.Underscore());
                }
            }
        }
    }
}
