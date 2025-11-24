namespace Clean.Application.Dtos.Lesson;

public class AddLessonDto
{
    public string Title { get; set; } = null!;
    public string VideoUrl { get; set; } = null!;
    public int DurationSeconds { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsPreview { get; set; }
    
    public int ModuleId { get; set; }
}