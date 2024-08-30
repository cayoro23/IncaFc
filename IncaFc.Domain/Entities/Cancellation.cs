namespace IncaFc.Domain.Entities;

public class Cancellation
{
    public Guid CancellationId { get; set; } = Guid.NewGuid();
    public Guid SaleId { get; set; }
    public string Reason { get; set; } = null!;
    public DateTime CancellationDate { get; set; }

    public Sale Sale { get; set; } = null!;
}
