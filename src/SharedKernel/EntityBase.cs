namespace Davish.SharedKernel;

/// <summary>
/// Non-generic base class shared by all entities, regardless of their id type.
/// </summary>
public abstract class EntityBase;

/// <summary>
/// Base class for entities identified by a <typeparamref name="TId"/>.
/// </summary>
public abstract class EntityBase<TId> : EntityBase
{
    /// <summary>
    /// The entity's identifier.
    /// </summary>
    public TId Id { get; set; } = default!;
}
