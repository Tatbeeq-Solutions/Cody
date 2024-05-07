using Cody.Domain.Commons;

namespace Cody.DataAccess.Enitties.Commons;

public class Asset : Auditable
{
    public string Name { get; set; }
    public string Path { get; set; }
}