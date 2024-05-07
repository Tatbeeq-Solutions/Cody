using Cody.Domain.Commons;

namespace Cody.Domain.Entities;

public class Role : Auditable
{
    public string Name { get; set; }
}