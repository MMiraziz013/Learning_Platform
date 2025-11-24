using Clean.Application.Dtos.Category;
using Clean.Application.Dtos.Enrollment;
using Clean.Application.Dtos.Module;
using Clean.Application.Dtos.User;
using Clean.Domain.Enums;

namespace Clean.Application.Dtos.Course;

public class GetCourseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ThumbnailUrl { get; set; } = null!;
    public decimal? Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public CourseStatus Status { get; set; }

    public CategoryBasicDto? Category { get; set; }
    public UserBasicDto? Instructor { get; set; }

    public List<ModuleBasicDto> Modules { get; set; } = [];
    public List<EnrollmentBasicDto> Enrollments { get; set; } = [];
}

