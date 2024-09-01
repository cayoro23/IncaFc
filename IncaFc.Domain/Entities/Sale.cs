using IncaFc.Domain.Enum;

namespace IncaFc.Domain.Entities;

public class Sale
{
    public Guid SaleId { get; set; } = Guid.NewGuid();
    public DateTime Date { get; set; }
    public SaleState State { get; set; }
    public Client Client { get; set; } = null!;
    public List<SaleDetail> SaleDetails { get; set; } = null!;
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
}
