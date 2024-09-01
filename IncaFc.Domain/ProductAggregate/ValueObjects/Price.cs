using IncaFc.Domain.Common.Models;

namespace IncaFc.Domain.ProductAggregate.ValueObjects;

public sealed class Price : ValueObject
{
    public decimal Amount { get; }
    public string Currency { get; }
    public string UnitOfMeasure { get; }

    private Price(
        decimal amount,
        string currency,
        string unitOfMeasure)
    {
        Amount = amount;
        Currency = currency;
        UnitOfMeasure = unitOfMeasure;
    }

    public static Price Create(decimal amount, string currency, string unitOfMeasure)
    {
        return new(
            amount,
            currency,
            unitOfMeasure
        );
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
        yield return UnitOfMeasure;
    }

}