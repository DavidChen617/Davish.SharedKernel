namespace Davish.SharedKernel;

/// <summary>
/// A domain event: something significant that happened within the domain.
/// </summary>
public interface IDomainEvent : INotification
{
    /// <summary>
    /// The UTC time at which the event occurred.
    /// </summary>
    DateTime OccurredOnUtc { get; }
}
