using Clean.Application.Dtos.Module;

namespace Clean.Application.Dtos.Lesson;

public class GetLessonDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string VideoUrl { get; set; } = null!;
    public int DurationSeconds { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsPreview { get; set; }
}

