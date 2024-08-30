using IncaFc.Domain.Enum;

namespace IncaFc.Domain.Entities;

public class Client
{
    public Guid ClientId { get; set; }
    public string Name { get; set; } = null!;
    public ClientType Type { get; set; }
    public string Contact { get; set; } = null!;
}
