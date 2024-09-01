using IncaFc.Domain.Common.Models;
using IncaFc.Domain.Customer.ValueObjects;
using IncaFc.Domain.Sale.ValueObjects;

namespace IncaFc.Domain.Sale;

public sealed class Sale : AggregateRoot<SaleDetailId>
{
    public string Name { get; }
    public StateId StateId { get; }
    public CustomerId CustomerId { get; }
    public SaleDetailId SaleDetailId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Sale(
        SaleDetailId saleId,
        string name,
        StateId stateId,
        CustomerId customerId,
        SaleDetailId saleDetailId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(saleId)
    {
        Name = name;
        StateId = stateId;
        CustomerId = customerId;
        SaleDetailId = saleDetailId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Sale Create(
        string name,
        StateId stateId,
        CustomerId customerId,
        SaleDetailId saleDetailId)
    {
        return new Sale(
            SaleDetailId.CreateUnique(),
            name,
            stateId,
            customerId,
            saleDetailId,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}