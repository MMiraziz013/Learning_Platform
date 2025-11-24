using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Infrastructure.Configurations;

public class CourseConfigurations : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("courses");

        builder.Property(c => c.Title).HasMaxLength(200).IsRequired();
        builder.Property(c => c.ThumbnailUrl).HasMaxLength(500);
        builder.Property(c => c.CreatedAt).HasDefaultValueSql("NOW()");
        builder.Property(c => c.Status)
            .HasConversion<string>();
        
        builder.HasOne(c => c.Category)
            .WithMany(ca => ca.Courses)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(c => c.Instructor)
            .WithMany(u => u.Courses)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.Modules)
            .WithOne(m => m.Course)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Enrollments)
            .WithOne(e => e.Course)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasIndex(c => c.Title);
        builder.HasIndex(c => c.CreatedAt);

    }
}