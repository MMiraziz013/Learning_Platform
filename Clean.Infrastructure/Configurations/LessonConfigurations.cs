using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Infrastructure.Configurations;

public class LessonConfigurations :IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("lessons");

        builder.Property(l => l.Title).HasMaxLength(150).IsRequired();
        builder.Property(l => l.VideoUrl).HasMaxLength(300);

        builder.HasOne(l => l.Module)
            .WithMany(m => m.Lessons)
            .HasForeignKey(l => l.ModuleId);

        builder.HasMany(l => l.LessonProgresses)
            .WithOne(lp => lp.Lesson);
    }
}