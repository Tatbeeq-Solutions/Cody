using Cody.Domain.Commons;
using Cody.DataAccess.Enitties.Commons;

namespace Cody.Domain.Entities;

public class Course : Auditable
{
    public string Name {  get; set; }
    public string Description { get; set; }
    public int DurationInMonth {  get; set; }
    public string Prerequisites { get; set; }
    public long? SyllabusId {  get; set; }

    public Asset Syllabus { get; set; }
    public IEnumerable<Group> Groups { get; set; }
}