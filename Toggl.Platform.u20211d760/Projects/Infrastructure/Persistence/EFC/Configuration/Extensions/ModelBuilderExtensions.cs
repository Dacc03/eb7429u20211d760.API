using Microsoft.EntityFrameworkCore;
using Toggl.Platform.u20211d760.Projects.Domain.Model.Aggregates;

namespace Toggl.Platform.u20211d760.Projects.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
/// Extension methods for configuring the Projects context model.
/// </summary>
/// <remarks>
/// Author: July Zelmira Paico Calderon
/// </remarks>
public static class ModelBuilderExtensions
{
    public static void ApplyProjectsConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Project>(entity =>
        {
            entity.ToTable("Project");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            
            entity.OwnsOne(e => e.CreatedBy, cb =>
            {
                cb.Property(m => m.Value)
                    .HasColumnName("created_by")
                    .IsRequired()
                    .HasMaxLength(36);
            });
            
            entity.Property(e => e.WorkSpaceId).IsRequired();
            entity.Property(e => e.Name).IsRequired().HasMaxLength(60);
            entity.Property(e => e.Billable).IsRequired();
            
            entity.Property(e => e.Status)
                .IsRequired()
                .HasConversion<string>();
        });
    }
}