namespace Clean.Domain.Entities;

public class LessonProgress
{
    public int Id { get; set; }
    public int WatchedSeconds { get; set; }
    public bool IsCompleted { get; set; }
    
    
    public int UserId { get; set; }
    public User User { get; set; }
    
    public int LessonId { get; set; }
    public Lesson Lesson { get; set; }
}