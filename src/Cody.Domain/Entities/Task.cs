using Cody.Domain.Commons;
using Cody.DataAccess.Enitties.Commons;

namespace Cody.Domain.Entities;

public class Task : Auditable
{
    public string Title {  get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public long GroupId {  get; set; }
    public long? FileId { get; set; }

    public Group Group { get; set; }
    public Asset File { get; set; }
}