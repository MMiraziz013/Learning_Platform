using Clean.Application.Dtos.Course;
using Clean.Application.Dtos.User;

namespace Clean.Application.Dtos.Enrollment;

public class GetEnrollmentDto
{
    public int Id { get; set; }
    public DateTime EnrolledAt { get; set; }
    public int ProgressPercent { get; set; }

    public UserBasicDto User { get; set; } = null!;
    public CourseBasicDto Course { get; set; } = null!;
}
