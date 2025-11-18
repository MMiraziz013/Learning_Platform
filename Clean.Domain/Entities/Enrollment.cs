namespace Clean.Domain.Entities;

public class Enrollment
{
    public int Id { get; set; }
    public DateTime EnrolledAt { get; set; }
    public int ProgressPercent { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
    
    public int CourseId { get; set; }
    public Course Course { get; set; }

}