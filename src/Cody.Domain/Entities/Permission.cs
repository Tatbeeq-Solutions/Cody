using Cody.Domain.Commons;

namespace Cody.Domain.Entities;

public class Permission : Auditable
{
    public string Action { get; set; }
    public string Controller { get; set; }
}
