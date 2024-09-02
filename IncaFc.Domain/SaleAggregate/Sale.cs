using IncaFc.Domain.Common.Models;
using IncaFc.Domain.CustomerAggregate.ValueObjects;
using IncaFc.Domain.SaleAggregate.ValueObjects;
using IncaFc.Domain.UserAggregate.ValueObjects;

namespace IncaFc.Domain.SaleAggregate;

public sealed class Sale : AggregateRoot<SaleDetailId, Guid>
{
    public string Name { get; private set; }
    public bool State { get; private set; }
    public string? Reason { get; private set; }
    public CustomerId CustomerId { get; private set; }
    public UserId UserId { get; private set; }
    public SaleDetailId SaleDetailId { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

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

#pragma warning disable CS8618
    private Sale()
    { }
#pragma warning restore CS8618
}