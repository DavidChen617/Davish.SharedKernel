namespace Davish.SharedKernel;

/// <summary>
/// An aggregate root that can raise and hold domain events until they are dispatched.
/// </summary>
public interface IAggregateRoot
{
    /// <summary>
    /// The domain events raised by this aggregate root that have not yet been cleared.
    /// </summary>
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    /// <summary>
    /// Records a domain event raised by this aggregate root.
    /// </summary>
    void RaiseDomainEvent(IDomainEvent domainEvent);

    /// <summary>
    /// Clears all domain events previously raised by this aggregate root.
    /// </summary>
    void ClearDomainEvents();
}
