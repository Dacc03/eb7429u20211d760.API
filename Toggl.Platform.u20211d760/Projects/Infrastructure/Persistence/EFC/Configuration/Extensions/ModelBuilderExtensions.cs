using Microsoft.EntityFrameworkCore;
using Toggl.Platform.u20211d760.Projects.Domain.Model.Aggregates;
using Toggl.Platform.u20211d760.Projects.Domain.Model.ValueObjects;

namespace Toggl.Platform.u20211d760.Projects.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
/// Extension methods for configuring the Projects context model.
/// </summary>
/// <remarks>
/// Author: Rafael Oswaldo Castro Veramendi
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
            entity.Property(e => e.WorkSpaceId).IsRequired();
            entity.Property(e => e.Name).HasMaxLength(60).IsRequired();
            entity.Property(e => e.Billable).IsRequired();
            entity.Property(e => e.Status).IsRequired();

            entity.OwnsOne(e => e.CreatedBy, createdBy =>
            {
                createdBy.WithOwner().HasForeignKey("ProjectId");
                createdBy.Property(cb => cb.Value).HasColumnName("created_by").IsRequired();
                createdBy.HasKey("ProjectId");
            });
        });

        SeedProjects(builder);
    }

    private static void SeedProjects(ModelBuilder builder)
    {
        builder.Entity<Project>().HasData(
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
                Status = EProjectStatus.CREATED
            },
            new
            {
                Id = 3,
                WorkSpaceId = 10,
                Name = "Research",
                Billable = false,
                Status = EProjectStatus.VALIDATED
            },
            new
            {
                Id = 4,
                WorkSpaceId = 15,
                Name = "Consulting",
                Billable = true,
                Status = EProjectStatus.PROCESSING
            }
        );

        builder.Entity<Project>().OwnsOne(p => p.CreatedBy).HasData(
            new { ProjectId = 1, Value = "11111111-1111-1111-1111-111111111111" },
            new { ProjectId = 2, Value = "22222222-2222-2222-2222-222222222222" },
            new { ProjectId = 3, Value = "33333333-3333-3333-3333-333333333333" },
            new { ProjectId = 4, Value = "44444444-4444-4444-4444-444444444444" }
        );
    }
}
