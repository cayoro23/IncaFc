using IncaFc.Domain.Common.Models;
using IncaFc.Domain.ProductAggregate.ValueObjects;

namespace IncaFc.Domain.ProductAggregate.Entities;

public sealed class Location : Entity<LocationId>
{
    public string Address { get; }
    public int Stock { get; set; }

    private Location(
        LocationId locationId,
        string address,
        int stock)
        : base(locationId)
    {
        Address = address;
        Stock = stock;
    }

    public static Location Create(string address, int stock)
    {
        return new(
            LocationId.CreateUnique(),
            address,
            stock
        );
    }
}