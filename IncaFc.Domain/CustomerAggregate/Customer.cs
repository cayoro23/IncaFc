using IncaFc.Domain.Common.Models;
using IncaFc.Domain.CustomerAggregate.ValueObjects;

namespace IncaFc.Domain.CustomerAggregate;

public sealed class Customer : AggregateRoot<CustomerId, Guid>
{
    public string Name { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Customer(
        CustomerId customerId,
        string name,
        DateTime createdDateTime,
        DateTime updatedDateTime
    )
        : base(customerId)
    {
        Name = name;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Customer Create(string name)
    {
        return new Customer(CustomerId.CreateUnique(), name, DateTime.UtcNow, DateTime.UtcNow);
    }

#pragma warning disable CS8618
    private Customer() { }
#pragma warning restore CS8618
}
