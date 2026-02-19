using Common.Interfaces;

namespace Common;

public abstract class Entity
{
    private readonly List<IDomainEvent> _events = [];

    protected Entity(Guid id)
    {
        Id = id;
    }

    protected Entity()
    {
    }

    public Guid Id { get; init; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    protected void SetUpdatedAt(IDateTimeProvider provider) => UpdatedAt = provider.UtcNow;

    public void Deactivate(Guid entityId)
    {
        if (Id != entityId)
        {
            Error.Failure(
                "Deactivate.NotFound",
                $"The entity with the Id = '{entityId}' was not found");
        }

        IsActive = false;
    }

    public List<IDomainEvent> DomainEvents => [.. _events];

    public void ClearDomainEvents() => _events.Clear();

    protected void Raise(IDomainEvent domainEvent) => _events.Add(domainEvent);
}
