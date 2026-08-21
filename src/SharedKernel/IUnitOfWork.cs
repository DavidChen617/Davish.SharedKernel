namespace Davish.SharedKernel;

/// <summary>
/// A unit of work that supports explicit transaction control in addition to committing changes.
/// </summary>
public interface IUnitOfWork : IUnitOfWorkBase
{
    /// <summary>
    /// Begins a new transaction.
    /// </summary>
    Task BeginAsync(CancellationToken ct);

    /// <summary>
    /// Rolls back the current transaction.
    /// </summary>
    Task RollbackAsync(CancellationToken ct);
}
