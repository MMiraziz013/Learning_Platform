namespace Clean.Application.Dtos.Course;

public class AddCourseDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal? Price { get; set; }
    public int? CategoryId { get; set; }
    public int? InstructorId { get; set; }
}