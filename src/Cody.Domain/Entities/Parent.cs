using Cody.DataAccess.Enitties.Commons;
using Cody.Domain.Commons;
using Cody.Domain.Entities;

namespace Cody.DataAccess.Enitties;

public class Parent : Auditable
{
    public string SecondPhone { get; set; }
    public long DetailId { get; set; }
    public long? PictureId { get; set; }

    public User Detail { get; set; }
    public Asset Picture { get; set; }
    public IEnumerable<Student> Children { get; set; }
}