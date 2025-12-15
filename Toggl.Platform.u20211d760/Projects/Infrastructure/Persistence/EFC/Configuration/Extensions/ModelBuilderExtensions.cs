using Microsoft.EntityFrameworkCore;
using Toggl.Platform.u20211d760.Projects.Domain.Model.Aggregates;
using Toggl.Platform.u20211d760.Projects.Domain.Model.ValueObjects;

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
                cb.WithOwner().HasForeignKey("Id");
                cb.HasKey("Id");

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

            entity.HasData(
                new
                {
                    Id = 1,
                    WorkSpaceId = 10,
                    Name = "Internal-dev",
                    Billable = false,
                    Status = EProjectStatus.CREATED
                },
                new
                {
                    Id = 2,
                    WorkSpaceId = 12,
                    Name = "Marketing",
                    Billable = true,
                    Status = EProjectStatus.VALIDATED
                },
                new
                {
                    Id = 3,
                    WorkSpaceId = 10,
                    Name = "Research",
                    Billable = false,
                    Status = EProjectStatus.PROCESSING
                },
                new
                {
                    Id = 4,
                    WorkSpaceId = 15,
                    Name = "Consulting",
                    Billable = true,
                    Status = EProjectStatus.SUCCESS
                }
            );

            entity.OwnsOne(e => e.CreatedBy).HasData(
                new { Id = 1, Value = "00000000-0000-0000-0000-000000000001" },
                new { Id = 2, Value = "00000000-0000-0000-0000-000000000002" },
                new { Id = 3, Value = "00000000-0000-0000-0000-000000000003" },
                new { Id = 4, Value = "00000000-0000-0000-0000-000000000004" }
            );
        });
    }
}