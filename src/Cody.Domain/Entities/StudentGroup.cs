using Cody.Domain.Commons;

namespace Cody.Domain.Entities;

public class StudentGroup : Auditable
{
    public long StudentId { get; set; }
    public Student Student { get; set; }
    public long GroupId { get; set; }
    public Group Group { get; set; }
}
