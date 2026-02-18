using Common;

namespace Domain.Entities.Addresses;

public static class AddressErrors
{
    public static Error NotFound(Guid addressId) => Error.NotFound(
        "Addresses.NotFound",
        $"The address with the Id = '{addressId}' was not found");

    public static Error Unauthorized() => Error.Failure(
        "Addresses.Unauthorized",
        "You are not authorized to perform this action.");

    public static Error IsInactive(Guid addressId) => Error.Failure(
        "Addresses.IsInactive",
        $"The address with the Id = '{addressId}' is inactive.");
}
