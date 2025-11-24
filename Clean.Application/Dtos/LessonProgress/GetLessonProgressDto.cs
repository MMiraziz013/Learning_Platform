using Clean.Application.Dtos.Lesson;

namespace Clean.Application.Dtos.LessonProgress;

public class GetLessonProgressDto
{
    public int Id { get; set; }
    public int WatchedSeconds { get; set; }
    public bool IsCompleted { get; set; }

    public LessonBasicDto Lesson { get; set; } = null!;
}
