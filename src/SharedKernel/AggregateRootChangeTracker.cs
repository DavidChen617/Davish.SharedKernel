namespace Davish.SharedKernel;

/// <inheritdoc />
public sealed class AggregateRootChangeTracker : IAggregateRootChangeTracker
{
    private readonly Queue<IAggregateRoot> _aggregateRoots = [];

    /// <inheritdoc />
    public IEnumerable<IAggregateRoot> Dequeue()
    {
        while (_aggregateRoots.Count > 0)
            yield return _aggregateRoots.Dequeue();
    }

    /// <inheritdoc />
    public void Enqueue(IAggregateRoot aggregateRoot)
    {
        _aggregateRoots.Enqueue(aggregateRoot);
    }
}
