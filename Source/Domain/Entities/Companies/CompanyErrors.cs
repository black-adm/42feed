using Common;

namespace Domain.Entities.Companies;

public static class CompanyErrors
{
    public static Error NotFound(Guid companyId) => Error.NotFound(
        "Companies.NotFound",
        $"The company with the Id = '{companyId}' was not found");

    public static Error Unauthorized() => Error.Failure(
        "Companies.Unauthorized",
        "You are not authorized to perform this action.");

    public static Error IsInactive(Guid companyId) => Error.Failure(
        "Companies.IsInactive",
        $"The company with the Id = '{companyId}' is inactive.");

    public static Error NotFoundByDocument(string document) => Error.NotFound(
        "Companies.NotFoundByDocument",
        $"The company with the document = '{document}' was not found");

    public static readonly Error NotFoundByEmail = Error.NotFound(
        "Companies.NotFoundByEmail",
        "The company with the specified email was not found");

    public static readonly Error EmailNotUnique = Error.Conflict(
        "Companies.EmailNotUnique",
        "The provided email is not unique");
}
