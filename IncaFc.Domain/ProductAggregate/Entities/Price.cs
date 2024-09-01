using IncaFc.Domain.Common.Models;
using IncaFc.Domain.ProductAggregate.ValueObjects;

namespace IncaFc.Domain.ProductAggregate.Entities;

public sealed class Price : Entity<PriceId>
{
    public decimal Amount { get; }
    public string Currency { get; }
    public string UnitOfMeasure { get; }

    private Price(
        PriceId priceId,
        decimal amount,
        string currency,
        string unitOfMeasure)
        : base(priceId)
    {
        Amount = amount;
        Currency = currency;
        UnitOfMeasure = unitOfMeasure;
    }

    public static Price Create(decimal amount, string currency, string unitOfMeasure)
    {
        return new(
            PriceId.CreateUnique(),
            amount,
            currency,
            unitOfMeasure
        );
    }
}