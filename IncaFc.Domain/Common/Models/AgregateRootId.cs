namespace IncaFc.Domain.Common.Models;

public abstract class AgregateRootId<TId> : ValueObject
{
    public abstract TId Value { get; protected set; }
}