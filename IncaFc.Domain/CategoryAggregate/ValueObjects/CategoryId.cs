using IncaFc.Domain.Common.Models;

namespace IncaFc.Domain.CategoryAggregate.ValueObjects;

public class CategoryId : ValueObject
{
    public Guid Value { get; private set; }

    private CategoryId(Guid value)
    {
        Value = value;
    }

    public static CategoryId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static CategoryId Create(Guid value)
    {
        return new CategoryId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}