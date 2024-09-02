using IncaFc.Domain.Common.Models;
using IncaFc.Domain.SaleAggregate.ValueObjects;

namespace IncaFc.Domain.SaleAggregate.Entities;

public sealed class State : AggregateRoot<StateId, Guid>
{
    public string Name { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private State(
        StateId stateId,
        string name,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(stateId)
    {
        Name = name;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static State Create(
        string name)
    {
        return new State(
            StateId.CreateUnique(),
            name,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}