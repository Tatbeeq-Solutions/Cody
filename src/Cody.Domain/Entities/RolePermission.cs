using Cody.Domain.Commons;

namespace Cody.Domain.Entities;

public class RolePermission : Auditable
{
    public long RoleId { get; set; }
    public long PermissionId { get; set; }

     public Role Role { get; set; }
     public Permission Permission { get; set; }
}