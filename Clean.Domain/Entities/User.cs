using Clean.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Clean.Domain.Entities;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserRole Role { get; set; }
    public DateTime RegistrationDate { get; set; }

    public bool IsActive { get; set; }
    public ICollection<Course> Courses { get; set; } = new List<Course>();
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public ICollection<LessonProgress> LessonProgresses { get; set; } = new List<LessonProgress>();
}