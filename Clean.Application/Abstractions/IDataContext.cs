using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Clean.Application.Abstractions;

public interface IDataContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<LessonProgress> LessonProgresses { get; set; }
    public DbSet<Module> Modules { get; set; }
    
    Task MigrateAsync();
    
    DatabaseFacade Database { get; }
}