namespace IncaFc.Domain.Entities;

public class SaleDetail
{
    public Guid SaleDetailId { get; set; } = Guid.NewGuid();
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TaxableBase { get; set; }
    public decimal IGV { get; set; }
    public decimal Total { get; set; }
    public Sale Sale { get; set; } = null!;
    public Product Product { get; set; } = null!;
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
}
