namespace IncaFc.Domain.Entities;

public class Location
{
    public Guid LocationId { get; set; } = Guid.NewGuid();
    public string Address { get; set; } = null!;
    public Guid ProductId { get; set; }
    public int Stock { get; set; }

    public Product Product { get; set; } = null!;
}
