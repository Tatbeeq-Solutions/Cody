using Cody.Domain.Commons;

namespace Cody.Domain.Entities;

public class Lesson : Auditable
{
    public string Title { get; set; }
    public DateTime DateTime { get; set; }
    public long GroupId { get; set; }

    public Group Group { get; set; }
}