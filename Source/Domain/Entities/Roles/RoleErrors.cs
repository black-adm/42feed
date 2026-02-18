using Common;

namespace Domain.Entities.Roles;

public static class RoleErrors
{
    public static Error NotFound(Guid roleId) => Error.NotFound(
        "Roles.NotFound",
        $"The role with the Id = '{roleId}' was not found");

    public static Error Unauthorized() => Error.Failure(
        "Roles.Unauthorized",
        "You are not authorized to perform this action.");
}
