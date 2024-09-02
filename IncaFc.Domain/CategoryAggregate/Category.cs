using IncaFc.Domain.CategoryAggregate.ValueObjects;
using IncaFc.Domain.Common.Models;

namespace IncaFc.Domain.CategoryAggregate;

public sealed class Category : AggregateRoot<CategoryId>
{
    public string Name { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Category(
        CategoryId categoryId,
        string name,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(categoryId)
    {
        Name = name;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Category Create(
        string name)
    {
        return new Category(
            CategoryId.CreateUnique(),
            name,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
#pragma warning disable CS8618
    private Category()
    { }
#pragma warning restore CS8618
}