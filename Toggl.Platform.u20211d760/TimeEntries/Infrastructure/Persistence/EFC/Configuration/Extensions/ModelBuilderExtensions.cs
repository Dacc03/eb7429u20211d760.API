using Microsoft.EntityFrameworkCore;
using Toggl.Platform.u20211d760.TimeEntries.Domain.Model.Aggregates;

namespace Toggl.Platform.u20211d760.TimeEntries.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
/// Extension methods for configuring the TimeEntries context model.
/// </summary>
/// <remarks>
/// Author: July Zelmira Paico Calderon
/// </remarks>
public static class ModelBuilderExtensions
{
    public static void ApplyTimeEntriesConfiguration(this ModelBuilder builder)
    {
        builder.Entity<TimeEntry>(entity =>
        {
            entity.ToTable("TimeEntry");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ProjectId).IsRequired();
            entity.Property(e => e.UserId).IsRequired();
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.DurationMinutes).IsRequired();
            entity.Property(e => e.EntryStatus).IsRequired();
            entity.Property(e => e.StartedAt).IsRequired();
        });
    }
}
