namespace Davish.SharedKernel;

/// <summary>
/// Base class for aggregate roots, tracking domain events raised during their lifetime.
/// </summary>
public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
{
    private readonly List<IDomainEvent> _domainEvents = [];

    /// <inheritdoc />
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

    /// <inheritdoc />
    public void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    /// <inheritdoc />
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}


/// <summary>
/// An <see cref="AggregateRoot{TId}"/> identified by a <see cref="Guid"/>.
/// </summary>
public abstract class AggregateRoot : AggregateRoot<Guid>;
