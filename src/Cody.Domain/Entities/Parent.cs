using Cody.DataAccess.Enitties.Commons;

namespace Cody.DataAccess.Enitties;

public class Parent
{
    public string SecondPhone { get; set; }
    public long UserId { get; set; }
    public long? PictureId { get; set; }

   // public User User { get; set; }
    public Asset Picture { get; set; }
}