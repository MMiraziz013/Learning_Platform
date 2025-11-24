namespace Clean.Application.Dtos.Module;

public class AddModuleDto
{
    public string Title { get; set; } = null!;
    public int DisplayOrder { get; set; }
    public int CourseId { get; set; }
}