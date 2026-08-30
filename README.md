# Davish.SharedKernel

[![NuGet](https://img.shields.io/nuget/v/Davish.SharedKernel.svg)](https://www.nuget.org/packages/Davish.SharedKernel)
[![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

Shared DDD building blocks for Davish projects: `Entity`, `AggregateRoot`, `DomainEvent`, and `IUnitOfWork`.

## Install

```
dotnet add package Davish.SharedKernel
```

## What's included

- `EntityBase` / `Entity<TId>` — base types for domain entities.
- `AggregateRoot<TId>` / `AggregateRoot` — aggregate root with domain event tracking (`RaiseDomainEvent`, `ClearDomainEvents`).
- `DomainEvent` / `IDomainEvent` / `IDomainEventHandler<TEvent>` — domain event contracts, built on `Davish.Sendr`'s notification pipeline.
- `IAggregateRootChangeTracker` / `AggregateRootChangeTracker` — collects aggregate roots that raised events so they can be dequeued and published (e.g. before `SaveChanges`).
- `IUnitOfWorkBase` / `IUnitOfWork` — commit/begin/rollback contracts for a unit of work.

## Usage

### Define an aggregate root and its domain events

```csharp
public sealed record OrderPlaced(Guid OrderId) : DomainEvent;

public sealed class Order : AggregateRoot
{
    public static Order Place(Guid id)
    {
        var order = new Order { Id = id };
        order.RaiseDomainEvent(new OrderPlaced(id));
        return order;
    }
}
```

`AggregateRoot` is an `AggregateRoot<Guid>`; use `AggregateRoot<TId>` directly if your aggregate is identified by something other than a `Guid`.

### Handle a domain event

```csharp
public sealed class SendOrderConfirmationEmail : IDomainEventHandler<OrderPlaced>
{
    public Task Handle(OrderPlaced notification, CancellationToken cancellationToken)
    {
        // send the email
        return Task.CompletedTask;
    }
}
```

### Track and dispatch domain events from a unit of work

```csharp
public sealed class SqlUnitOfWork(IAggregateRootChangeTracker changeTracker, IPublisher publisher) : IUnitOfWork
{
    public async Task CommitAsync(CancellationToken ct)
    {
        // persist changes here, then dispatch what was raised
        foreach (var aggregateRoot in changeTracker.Dequeue())
        {
            foreach (var domainEvent in aggregateRoot.DomainEvents)
                await publisher.PublishAsync(domainEvent, ct);

            aggregateRoot.ClearDomainEvents();
        }
    }

    public Task BeginAsync(CancellationToken ct) => Task.CompletedTask;

    public Task RollbackAsync(CancellationToken ct) => Task.CompletedTask;
}
```

Enqueue an aggregate root into the `IAggregateRootChangeTracker` whenever it's added or modified (e.g. in your repository's `Add`/`Update` methods), so `CommitAsync` knows which aggregates to dispatch events for.

## Requirements

- .NET 10.0+

## License

MIT
