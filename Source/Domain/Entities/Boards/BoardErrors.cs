using Common;

namespace Domain.Entities.Boards;

public static class BoardErrors
{
    public static Error NotFound(Guid boardId) => Error.NotFound(
        "Boards.NotFound",
        $"The boards with the Id = '{boardId}' was not found");

    public static Error Unauthorized() => Error.Failure(
        "Boards.Unauthorized",
        "You are not authorized to perform this action.");

    public static Error IsInactive(Guid boardId) => Error.Failure(
        "Boards.IsInactive",
        $"The boards with the Id = '{boardId}' is inactive.");
}
