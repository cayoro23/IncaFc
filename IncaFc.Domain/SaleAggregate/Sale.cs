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
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }
    public List<SaleDetail> SaleDetails { get; private set; } = [];
    public decimal Total { get; private set; }

    private Sale(
        SaleId saleId,
        string name,
        bool state,
        string? reason,
        CustomerId customerId,
        UserId userId,
        List<SaleDetail> saleDetails,
        decimal total,
        DateTime createdDateTime,
        DateTime updatedDateTime
    )
        : base(saleId)
    {
        Name = name;
        State = state;
        Reason = reason;
        CustomerId = customerId;
        UserId = userId;
        SaleDetails = saleDetails;
        Total = total;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public void UpdateStateAndReason(bool newState, string newReason)
    {
        State = newState;
        Reason = newReason;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void AddSaleDetail(SaleDetail saleDetail)
    {
        SaleDetails.Add(saleDetail);
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void RemoveSaleDetail(SaleDetail saleDetail)
    {
        SaleDetails.Remove(saleDetail);
        UpdatedDateTime = DateTime.UtcNow;
    }

    public static Sale Create(
        string name,
        bool state,
        string? reason,
        CustomerId customerId,
        UserId userId,
        List<SaleDetail> saleDetails,
        decimal total
    )
    {
        return new Sale(
            SaleId.CreateUnique(),
            name,
            state,
            reason ?? "",
            customerId,
            userId,
            saleDetails,
            total,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }

#pragma warning disable CS8618
    private Sale() { }
#pragma warning restore CS8618
}
