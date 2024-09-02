using IncaFc.Domain.Common.Models;
using IncaFc.Domain.CustomerAggregate.ValueObjects;
using IncaFc.Domain.SaleAggregate.ValueObjects;
using IncaFc.Domain.UserAggregate.ValueObjects;

namespace IncaFc.Domain.SaleAggregate;

public sealed class Sale : AggregateRoot<SaleDetailId, Guid>
{
    public string Name { get; }
    public bool State { get; }
    public string? Reason { get; }
    public CustomerId CustomerId { get; }
    public UserId UserId { get; }
    public SaleDetailId SaleDetailId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Sale(
        SaleDetailId saleId,
        string name,
        bool state,
        CustomerId customerId,
        UserId userId,
        SaleDetailId saleDetailId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(saleId)
    {
        Name = name;
        State = state;
        CustomerId = customerId;
        UserId = userId;
        SaleDetailId = saleDetailId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Sale Create(
        string name,
        bool state,
        CustomerId customerId,
        UserId userId,
        SaleDetailId saleDetailId)
    {
        return new Sale(
            SaleDetailId.CreateUnique(),
            name,
            state,
            customerId,
            userId,
            saleDetailId,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}