using Cody.Domain.Enums;
using Cody.Domain.Commons;

namespace Cody.Domain.Entities;

public class Notification : Auditable
{
    public long UserId { get; set; }
    public string Content { get; set; }
    public NotificationType Type { get; set; }

    public User User { get; set; }
}
