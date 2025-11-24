namespace Clean.Application.Dtos.Enrollment;

public class EnrollmentBasicDto
{
    public int Id { get; set; }
    public DateTime EnrolledAt { get; set; }
    public int ProgressPercent { get; set; }
}