namespace IncaFc.Domain.Entities;

public class Location
{
    public Guid LocationId { get; set; } = Guid.NewGuid();
    public string Address { get; set; } = null!;
    public int Stock { get; set; }
    public Product Product { get; set; } = null!;
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
}
