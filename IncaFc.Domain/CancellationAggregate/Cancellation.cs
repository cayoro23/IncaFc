using IncaFc.Domain.CancellationAggregate.ValueObjects;
using IncaFc.Domain.Common.Models;
using IncaFc.Domain.SaleAggregate.ValueObjects;

namespace IncaFc.Domain.CancellationAggregate;

public sealed class Cancellation : AggregateRoot<CancellationId>
{
    public string Reason { get; }
    public SaleId SaleId { get; }
    public DateTime CreatedDateTime { get; set; }

    private Cancellation(
        CancellationId cancellationId,
        string reason,
        SaleId saleId,
        DateTime createdDateTime)
        : base(cancellationId)
    {
        Reason = reason;
        SaleId = saleId;
        CreatedDateTime = createdDateTime;
    }

    public static Cancellation Create(
        string reason,
        SaleId saleId,
        DateTime createdDateTime)
    {
        return new Cancellation(
            CancellationId.CreateUnique(),
            reason,
            saleId,
            DateTime.UtcNow
        );
    }
}