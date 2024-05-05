namespace Cody.Domain.Entities;

public class Announcement
{
    public string Name { get; set; }
    public string Content { get; set; }
    public long? MediaId { get; set; }

    //public Asset Media { get; set; }
}