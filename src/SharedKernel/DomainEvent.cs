namespace Davish.SharedKernel;

/// <summary>
/// Base class for domain events, assigning a time-ordered id and the UTC time at which it occurred.
/// </summary>
public abstract record DomainEvent : IDomainEvent
{
    /// <summary>
    /// The unique id of this event, generated as a time-ordered (UUID v7) <see cref="Guid"/>.
    /// </summary>
    public Guid Id { get; protected set; } = Guid.CreateVersion7();

    /// <inheritdoc />
    public DateTime OccurredOnUtc { get; } = DateTime.UtcNow;
}
