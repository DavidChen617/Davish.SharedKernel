namespace Davish.SharedKernel;

/// <summary>
/// Handles a domain event of type <typeparamref name="TEvent"/>.
/// </summary>
public interface IDomainEventHandler<in TEvent> : INotificationHandler<TEvent>
    where TEvent : IDomainEvent;
