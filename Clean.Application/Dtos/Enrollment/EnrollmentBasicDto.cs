namespace Clean.Application.Dtos.User;

public class EnrollmentBasicDto
{
    public int Id { get; set; }
    public DateTime EnrolledAt { get; set; }
    public int ProgressPercent { get; set; }
}