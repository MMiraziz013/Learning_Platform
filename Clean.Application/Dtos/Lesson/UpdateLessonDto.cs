namespace Clean.Application.Dtos.Lesson;

public class UpdateLessonDto
{
    public string? Title { get; set; }
    public string? VideoUrl { get; set; }
    public int? DurationSeconds { get; set; }
    public int? DisplayOrder { get; set; }
    public bool? IsPreview { get; set; }

}