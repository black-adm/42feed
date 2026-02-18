using Common;
using Domain.Interfaces;

namespace Domain.Entities.Roles;

public sealed class Role : Entity, IAggregateRoot
{
    public Enums.Roles Type { get; private set; } = Enums.Roles.INCOGNITO;

    private Role()
    {
    }

    private Role(Enums.Roles type)
    {
        Type = type;
    }

    public static Role Create(Enums.Roles type)
    {
        return new Role(type);
    }
}
