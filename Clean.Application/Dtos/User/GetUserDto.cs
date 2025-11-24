using Clean.Application.Dtos.Course;
using Clean.Application.Dtos.Enrollment;
using Clean.Application.Dtos.LessonProgress;
using Clean.Domain.Entities;
using Clean.Domain.Enums;

namespace Clean.Application.Dtos.User;

public class GetUserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserRole Role { get; set; }
    public DateOnly RegistrationDate { get; set; }
    public bool IsActive { get; set; }

    public List<CourseBasicDto> Courses { get; set; } = [];
    public List<EnrollmentBasicDto> Enrollments { get; set; } = [];
    public List<LessonProgressBasicDto> LessonProgresses { get; set; } = [];

}