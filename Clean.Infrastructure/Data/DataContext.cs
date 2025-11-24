using Clean.Application.Abstractions;
using Clean.Domain.Entities;
using Clean.Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Clean.Infrastructure.Data;

public class DataContext : IdentityDbContext<User, IdentityRole<int>, int>, IDataContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    public DbSet<Course> Courses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<LessonProgress> LessonProgresses { get; set; }
    public DbSet<Module> Modules { get; set; }
    
    public async Task MigrateAsync()
    {
        await Database.MigrateAsync();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(UserConfigurations).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(CourseConfigurations).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(CategoryConfigurations).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(EnrollmentConfigurations).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(LessonConfigurations).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(LessonProgressConfigurations).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(ModuleConfigurations).Assembly);
    }
}