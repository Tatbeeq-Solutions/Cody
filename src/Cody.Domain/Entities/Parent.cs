using Cody.Domain.Commons;
using Cody.Domain.Entities;
using Cody.DataAccess.Enitties.Commons;

namespace Cody.DataAccess.Enitties;

public class Parent : Auditable
{
    public string SecondPhone { get; set; }
    public long UserId { get; set; }
    public long? PictureId { get; set; }
    public User Detail { get; set; }
    public Asset Picture { get; set; }
}