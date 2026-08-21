namespace SharedKernel.UnitTests;

public class AggregateRootTests
{
    [Fact]
    public void GivenANewAggregateRoot_WhenNoEventHasBeenRaised_ThenDomainEventsIsEmpty()
    {
        // Given
        var aggregateRoot = new TestAggregateRoot();

        // When / Then
        Assert.Empty(aggregateRoot.DomainEvents);
    }

    [Fact]
    public void GivenANewAggregateRoot_WhenRaisingADomainEvent_ThenItAppearsInDomainEvents()
    {
        // Given
        var aggregateRoot = new TestAggregateRoot();
        var domainEvent = new TestDomainEvent();

        // When
        aggregateRoot.RaiseDomainEvent(domainEvent);

        // Then
        Assert.Single(aggregateRoot.DomainEvents);
        Assert.Same(domainEvent, aggregateRoot.DomainEvents.Single());
    }

    [Fact]
    public void GivenMultipleEventsRaised_WhenRaisingThemInOrder_ThenDomainEventsPreservesThatOrder()
    {
        // Given
        var aggregateRoot = new TestAggregateRoot();
        var firstEvent = new TestDomainEvent();
        var secondEvent = new TestDomainEvent();

        // When
        aggregateRoot.RaiseDomainEvent(firstEvent);
        aggregateRoot.RaiseDomainEvent(secondEvent);

        // Then
        Assert.Equal([firstEvent, secondEvent], aggregateRoot.DomainEvents);
    }

    [Fact]
    public void GivenAnAggregateRootWithRaisedEvents_WhenClearingDomainEvents_ThenDomainEventsBecomesEmpty()
    {
        // Given
        var aggregateRoot = new TestAggregateRoot();
        aggregateRoot.RaiseDomainEvent(new TestDomainEvent());

        // When
        aggregateRoot.ClearDomainEvents();

        // Then
        Assert.Empty(aggregateRoot.DomainEvents);
    }
}
