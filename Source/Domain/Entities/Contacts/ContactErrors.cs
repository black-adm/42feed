using Common;

namespace Domain.Entities.Contacts;

public static class ContactErrors
{
    public static Error NotFound(Guid contactId) => Error.NotFound(
        "Contacts.NotFound",
        $"The contact with the Id = '{contactId}' was not found");

    public static Error Unauthorized() => Error.Failure(
        "Contacts.Unauthorized",
        "You are not authorized to perform this action.");

    public static Error IsInactive(Guid contactId) => Error.Failure(
        "Contacts.IsInactive",
        $"The contact with the Id = '{contactId}' is inactive.");

    public static readonly Error InvalidEmailAddress = Error.Validation(
        "Contacts.InvalidEmailAddress",
        "The contact email address is invalid");

    public static readonly Error InvalidPhoneNumber = Error.Validation(
        "Contacts.InvalidPhoneNumber",
        "The contact phone number is invalid");
}
