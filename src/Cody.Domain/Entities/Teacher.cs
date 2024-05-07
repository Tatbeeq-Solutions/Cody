using Cody.Domain.Commons;
using Cody.DataAccess.Enitties.Commons;

namespace Cody.Domain.Entities;

public class Teacher :Auditable
{
    public string Profession {  get; set; }
    public string About {  get; set; }
    public long UserId { get; set; }
    public long? PictureId { get; set; }

    public User Detail { get; set; }
    public Asset Picture { get; set; }
}