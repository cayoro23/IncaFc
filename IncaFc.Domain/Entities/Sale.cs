using IncaFc.Domain.Enum;

namespace IncaFc.Domain.Entities;

public class Sale
{
    public Guid SaleId { get; set; }
    public Guid ClientId { get; set; }
    public DateTime Date { get; set; }
    public SaleState State { get; set; }

    public Client Client { get; set; } = null!;
    public List<SaleDetail> SaleDetails { get; set; } = null!;
}
