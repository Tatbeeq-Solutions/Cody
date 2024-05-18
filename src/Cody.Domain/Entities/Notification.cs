using Cody.Domain.Commons;
using Cody.Domain.Enums;

namespace Cody.Domain.Entities;

public class Notification : Auditable
{
    public long UserId { get; set; }
    public string Content { get; set; }
    public NotificationType Type { get; set; }

    public User User { get; set; }
}
