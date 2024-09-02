using IncaFc.Domain.Common.Models;
using IncaFc.Domain.CustomerAggregate.ValueObjects;
using IncaFc.Domain.SaleAggregate.Entities;
using IncaFc.Domain.SaleAggregate.ValueObjects;
using IncaFc.Domain.UserAggregate.ValueObjects;

namespace IncaFc.Domain.SaleAggregate;

public sealed class Sale : AggregateRoot<SaleId, Guid>
{
    public string Name { get; private set; }
    public bool State { get; private set; }
    public string? Reason { get; private set; }
    public CustomerId CustomerId { get; private set; }
    public UserId UserId { get; private set; }
    public SaleDetail SaleDetail { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Sale(
        SaleId saleId,
        string name,
        bool state,
        string? reason,
        CustomerId customerId,
        UserId userId,
        SaleDetail saleDetail,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(saleId)
    {
        Name = name;
        State = state;
        Reason = reason;
        CustomerId = customerId;
        UserId = userId;
        SaleDetail = saleDetail;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public void UpdateStateAndReason(bool newState, string? newReason)
    {
        State = newState;
        Reason = newReason;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public static Sale Create(
        string name,
        bool state,
        string? reason,
        CustomerId customerId,
        UserId userId,
        SaleDetail saleDetail)
    {
        return new Sale(
            SaleId.CreateUnique(),
            name,
            state,
            reason ?? "",
            customerId,
            userId,
            saleDetail,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }

#pragma warning disable CS8618
    private Sale()
    { }
#pragma warning restore CS8618
}