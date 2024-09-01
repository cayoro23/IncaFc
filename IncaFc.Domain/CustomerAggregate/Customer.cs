using IncaFc.Domain.Common.Models;
using IncaFc.Domain.CustomerAggregate.ValueObjects;

namespace IncaFc.Domain.CustomerAggregate;

public sealed class Customer : AggregateRoot<CustomerId>
{
    public string Name { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Customer(
        CustomerId customerId,
        string name,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(customerId)
    {
        Name = name;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Customer Create(
        string name)
    {
        return new Customer(
            CustomerId.CreateUnique(),
            name,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}