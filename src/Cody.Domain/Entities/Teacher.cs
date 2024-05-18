using Cody.DataAccess.Enitties.Commons;
using Cody.Domain.Commons;

namespace Cody.Domain.Entities;

public class Teacher : Auditable
{
    public string Profession { get; set; }
    public string About { get; set; }
    public long DetailId { get; set; }
    public long? PictureId { get; set; }

    public User Detail { get; set; }
    public Asset Picture { get; set; }
    public IEnumerable<Group> Groups { get; set; }
}