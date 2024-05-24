using Cody.Domain.Enums;

namespace Cody.Service.Options;

public class SuperAdminOptions
{
    public required string Phone { get; set; }
    public required string Password { get; set; }
    public Role Role => Role.SuperAdmin;
}
