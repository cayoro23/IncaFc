using IncaFc.Domain.Common.Models;

namespace IncaFc.Domain.ProductAggregate.ValueObjects;

public class ProductId : AgregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private ProductId(Guid value)
    {
        Value = value;
    }

    public static ProductId CreateUnique()
    {
        return new ProductId(Guid.NewGuid());
    }

    public static ProductId Create(Guid value)
    {
        return new ProductId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}