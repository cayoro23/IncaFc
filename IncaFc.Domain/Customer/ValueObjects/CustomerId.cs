using IncaFc.Domain.Common.Models;

namespace IncaFc.Domain.Customer.ValueObjects;

public class CustomerId : ValueObject
{
    public Guid Value { get; }

    private CustomerId(Guid value)
    {
        Value = value;
    }

    public static CustomerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}