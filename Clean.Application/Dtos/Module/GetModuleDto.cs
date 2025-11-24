using Clean.Application.Dtos.Lesson;

namespace Clean.Application.Dtos.Module;

public class GetModuleDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int DisplayOrder { get; set; }

    public List<LessonBasicDto> Lessons { get; set; } = [];
}