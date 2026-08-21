namespace Davish.SharedKernel;

/// <summary>
/// Tracks aggregate roots that changed during a unit of work, so their domain events can be dispatched later.
/// </summary>
public interface IAggregateRootChangeTracker
{
    /// <summary>
    /// Removes and returns all tracked aggregate roots, in the order they were enqueued.
    /// </summary>
    IEnumerable<IAggregateRoot> Dequeue();

    /// <summary>
    /// Tracks an aggregate root so it can be retrieved later via <see cref="Dequeue"/>.
    /// </summary>
    void Enqueue(IAggregateRoot aggregateRoot);
}
