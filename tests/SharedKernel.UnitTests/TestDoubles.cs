using Davish.SharedKernel;

namespace SharedKernel.UnitTests;

internal sealed class TestAggregateRoot : AggregateRoot;

internal sealed record TestDomainEvent : DomainEvent;
