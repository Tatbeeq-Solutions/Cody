using Cody.Domain.Commons;

namespace Cody.Domain.Entities;

public class LessonMark : Auditable
{
    public long StudentId { get; set; }
    public long LessonId { get; set; }
    public string Comment { get; set; }
    public int Points { get; set; }

    public Student Student { get; set; }
    public Lesson Lesson { get; set; }
}