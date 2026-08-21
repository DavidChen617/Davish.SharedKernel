namespace SharedKernel.UnitTests;

public class DomainEventTests
{
    [Fact]
    public void GivenANewDomainEvent_WhenItIsCreated_ThenItReceivesANonEmptyId()
    {
        // Given / When
        var domainEvent = new TestDomainEvent();

        // Then
        Assert.NotEqual(Guid.Empty, domainEvent.Id);
    }

    [Fact]
    public void GivenTwoDomainEvents_WhenCreatedOneAfterAnother_ThenTheyReceiveDifferentIds()
    {
        // Given / When
        var firstEvent = new TestDomainEvent();
        var secondEvent = new TestDomainEvent();

        // Then
        Assert.NotEqual(firstEvent.Id, secondEvent.Id);
    }

    [Fact]
    public void GivenANewDomainEvent_WhenItIsCreated_ThenOccurredOnUtcIsSetToTheCurrentTime()
    {
        // Given
        var before = DateTime.UtcNow;

        // When
        var domainEvent = new TestDomainEvent();

        // Then
        var after = DateTime.UtcNow;
        Assert.InRange(domainEvent.OccurredOnUtc, before, after);
    }
}
