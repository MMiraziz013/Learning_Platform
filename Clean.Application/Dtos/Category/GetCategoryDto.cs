using Clean.Application.Dtos.Course;

namespace Clean.Application.Dtos.Category;

public class GetCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    
    public List<CourseBasicDto> Courses { get; set; } = [];
}