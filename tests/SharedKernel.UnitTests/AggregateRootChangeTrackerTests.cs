using Davish.SharedKernel;

namespace SharedKernel.UnitTests;

public class AggregateRootChangeTrackerTests
{
    [Fact]
    public void GivenNoAggregateRootHasBeenEnqueued_WhenDequeuing_ThenTheSequenceIsEmpty()
    {
        // Given
        var tracker = new AggregateRootChangeTracker();

        // When
        var dequeued = tracker.Dequeue();

        // Then
        Assert.Empty(dequeued);
    }

    [Fact]
    public void GivenASingleAggregateRootEnqueued_WhenDequeuing_ThenThatAggregateRootIsReturned()
    {
        // Given
        var tracker = new AggregateRootChangeTracker();
        var aggregateRoot = new TestAggregateRoot();
        tracker.Enqueue(aggregateRoot);

        // When
        var dequeued = tracker.Dequeue();

        // Then
        Assert.Same(aggregateRoot, dequeued.Single());
    }

    [Fact]
    public void GivenMultipleAggregateRootsEnqueued_WhenDequeuing_ThenTheyAreReturnedInEnqueueOrder()
    {
        // Given
        var tracker = new AggregateRootChangeTracker();
        var first = new TestAggregateRoot();
        var second = new TestAggregateRoot();
        tracker.Enqueue(first);
        tracker.Enqueue(second);

        // When
        var dequeued = tracker.Dequeue().ToArray();

        // Then
        Assert.Equal([first, second], dequeued);
    }

    [Fact]
    public void GivenATrackerAlreadyDequeued_WhenDequeuingAgain_ThenItYieldsNothingMore()
    {
        // Given
        var tracker = new AggregateRootChangeTracker();
        tracker.Enqueue(new TestAggregateRoot());
        tracker.Dequeue().ToArray();

        // When
        var secondDequeue = tracker.Dequeue();

        // Then
        Assert.Empty(secondDequeue);
    }
}
