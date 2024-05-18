using Cody.DataAccess.Enitties.Commons;
using Cody.Domain.Commons;

namespace Cody.Domain.Entities;

public class HomeTask : Auditable
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public long GroupId { get; set; }
    public long? FileId { get; set; }

    public Group Group { get; set; }
    public Asset File { get; set; }
}