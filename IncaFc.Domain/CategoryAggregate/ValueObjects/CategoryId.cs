using IncaFc.Domain.Common.Models;

namespace IncaFc.Domain.CategoryAggregate.ValueObjects;

public class CategoryId : AgregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private CategoryId(Guid value)
    {
        Value = value;
    }

    public static CategoryId CreateUnique()
    {
        return new CategoryId(Guid.NewGuid());
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