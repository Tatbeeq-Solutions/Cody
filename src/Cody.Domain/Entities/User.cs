using Cody.Domain.Commons;

namespace Cody.Domain.Entities;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string PasswordHash { get; set; }
    public long RoleId { get; set; }

    public Role Role { get; set; }
    public IEnumerable<Notification> Notifications { get; set; }
}