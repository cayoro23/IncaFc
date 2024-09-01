using IncaFc.Domain.Enum;

namespace IncaFc.Domain.Entities;

public class Price
{
    public Guid PriceId { get; set; } = Guid.NewGuid();
    public decimal PriceAmount { get; set; }
    public UnitOfMeasure Unit { get; set; }
    public Product Product { get; set; } = null!;
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
}
