namespace Clean.Domain.Entities;

public class Lesson
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    public string VideoUrl { get; set; }
    public int DurationSeconds { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsPreview { get; set; }

    public int ModuleId { get; set; }
    public Module Module { get; set; } = default!;

    public ICollection<LessonProgress> LessonProgresses { get; set; } = new List<LessonProgress>();
}