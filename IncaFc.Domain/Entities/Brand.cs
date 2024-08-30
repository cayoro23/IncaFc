namespace IncaFc.Domain.Entities;

public class Brand
{
    public Guid BranId { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;

    public List<Product> Products { get; set; } = null!;
}
