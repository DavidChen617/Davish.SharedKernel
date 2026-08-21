namespace Davish.SharedKernel;

/// <summary>
/// A unit of work that persists pending changes.
/// </summary>
public interface IUnitOfWorkBase
{
    /// <summary>
    /// Commits all pending changes.
    /// </summary>
    Task CommitAsync(CancellationToken ct);
}
