using IncaFc.Domain.Common.Models;

namespace IncaFc.Domain.Sale.ValueObjects;

public class SaleId : ValueObject
{
    public Guid Value { get; }

    private SaleId(Guid value)
    {
        Value = value;
    }

    public static SaleId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}