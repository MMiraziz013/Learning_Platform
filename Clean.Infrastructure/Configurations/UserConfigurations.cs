using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Infrastructure.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.Property(u => u.UserName).HasMaxLength(100).IsRequired();
        builder.Property(u => u.Email).HasMaxLength(255).IsRequired();

        builder.Property(u => u.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(u => u.LastName).HasMaxLength(50).IsRequired();
        builder.Property(u => u.RegistrationDate).HasDefaultValueSql("NOW()");
        builder.Property(u => u.Role)
            .HasConversion<string>();

        builder.HasMany(u => u.Courses)
            .WithOne(c => c.Instructor)
            .HasForeignKey(c => c.InstructorId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.Enrollments)
            .WithOne(e => e.User)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.LessonProgresses)
            .WithOne(lp => lp.User)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasIndex(u => u.Email).IsUnique();
        builder.HasIndex(u => u.Role);
        builder.HasIndex(u => u.RegistrationDate);
    }
}