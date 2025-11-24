namespace Clean.Application.Dtos.Course;

public class UpdateCourseDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public int? CategoryId { get; set; }
    public int? InstructorId { get; set; }
    public string? Status { get; set; }
}