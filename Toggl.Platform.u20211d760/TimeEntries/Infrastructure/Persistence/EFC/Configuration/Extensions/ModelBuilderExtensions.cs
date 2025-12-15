using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Toggl.Platform.u20211d760.TimeEntries.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
/// Extension methods for configuring the TimeEntries context model.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public static class ModelBuilderExtensions
{
    public static void ApplyTimeEntriesConfiguration(this ModelBuilder builder)
    {
        builder.Entity<DataRecord>(entity =>
        {
            entity.ToTable("DataRecord");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.OwnsOne(e => e.PotMacAddress, mac =>
            {
                // Align the owned type's key with the principal key to avoid
                // conflicting primary key column names when sharing the table.
                mac.WithOwner().HasForeignKey("Id");
                mac.HasKey("Id");
                mac.Property(m => m.Address).HasColumnName("pot_mac_address").IsRequired();
            });
            
            entity.Property(e => e.OperationMode).IsRequired();
            entity.Property(e => e.TargetHumidityLevel).HasPrecision(5, 2).IsRequired();
            entity.Property(e => e.CurrentHumidityLevel).HasPrecision(5, 2).IsRequired();
            entity.Property(e => e.OperationPhase).IsRequired();
            entity.Property(e => e.EmittedAt).IsRequired();
        });
    }
}