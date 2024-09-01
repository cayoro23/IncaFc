using IncaFc.Domain.Enum;

namespace IncaFc.Domain.Entities;

public class Client
{
    public Guid ClientId { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public ClientType Type { get; set; }
    public string Contact { get; set; } = null!; 
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
}
