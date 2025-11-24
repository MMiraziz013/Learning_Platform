using Clean.Domain.Enums;

namespace Clean.Domain.Entities;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ThumbnailUrl { get; set; }
    public decimal? Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public CourseStatus Status { get; set; }

    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    
    public int? InstructorId { get; set; }
    public User? Instructor { get; set; }

    public ICollection<Module> Modules { get; set; } = new List<Module>();
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}