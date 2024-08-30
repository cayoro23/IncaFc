using IncaFc.Domain.Enum;

namespace IncaFc.Domain.Entities;

public class Price
{
    public Guid PriceId { get; set; } = Guid.NewGuid();
    public Guid ProductId { get; set; }
    public decimal PriceAmount { get; set; }
    public UnitOfMeasure Unit { get; set; }

    public Product Product { get; set; } = null!;
}
