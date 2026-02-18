using Common;
using Domain.Entities.Companies;
using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Entities.Addresses;

public sealed class Address : Entity, IAggregateRoot
{
    public string Street { get; private set; } = string.Empty;

    public string AddressNumber { get; private set; } = string.Empty;

    public string? Complement { get; private set; } = null!;

    public string Zipcode { get; private set; } = string.Empty;

    public string Neighborhood { get; private set; } = string.Empty;

    public string City { get; private set; } = string.Empty;

    public string State { get; private set; } = string.Empty;

    public UfTypes Uf { get; private set; } = UfTypes.UNDEFINED;

    public Company Company { get; private set; } = null!;

    public User? User { get; private set; } = null!;

    private Address()
    {
    }

    private Address(
        string street,
        string addressNumber,
        string complement,
        string zipcode,
        string neighborhood,
        string city,
        string state,
        UfTypes uf,
        Company company)
    {
        Street = street;
        AddressNumber = addressNumber;
        Complement = complement;
        Zipcode = zipcode;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Uf = uf;
        Company = company;
    }

    public static Address Create(
        string street,
        string addressNumber,
        string complement,
        string postalCode,
        string neighborhood,
        string city,
        string state,
        UfTypes uf,
        Company company)
    {
        return new Address(
            street,
            addressNumber,
            complement,
            postalCode,
            neighborhood,
            city,
            state,
            uf,
            company);
    }

    public void Update(
        string street,
        string addressNumber,
        string complement,
        string zipcode,
        string neighborhood,
        string city,
        string state,
        UfTypes uf)
    {
        Street = street;
        AddressNumber = addressNumber;
        Complement = complement;
        Zipcode = zipcode;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Uf = uf;
    }

    public void DeactivateAddress() => Deactivate();
}
