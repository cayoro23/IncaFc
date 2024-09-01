using IncaFc.Domain.CategoryAggregate.ValueObjects;
using IncaFc.Domain.Common.Models;

namespace IncaFc.Domain.CategoryAggregate;

public sealed class Category : AggregateRoot<CategoryId>
{
    public string Name { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

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
}