using Common;

namespace Domain.Entities.Feedbacks;

public static class FeedbackErrors
{
    public static Error NotFound(Guid feedbackId) => Error.NotFound(
        "Feedbacks.NotFound",
        $"The feedback with the Id = '{feedbackId}' was not found");

    public static Error Unauthorized() => Error.Failure(
        "Feedbacks.Unauthorized",
        "You are not authorized to perform this action.");

    public static Error IsInactive(Guid feedbackId) => Error.Failure(
        "Feedbacks.IsInactive",
        $"The feedback with the Id = '{feedbackId}' is inactive.");
}
