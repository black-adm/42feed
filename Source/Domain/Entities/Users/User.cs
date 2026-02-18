using Common;
using Domain.Entities.Addresses;
using Domain.Entities.Contacts;
using Domain.Entities.Roles;
using Domain.Interfaces;

public sealed class User : Entity, IAggregateRoot
{
    private readonly List<Role> _roles = [];

    private readonly List<Contact> _contacts = [];

    public string Name { get; private set; }

    public string Registration { get; private set; }

    public string PasswordHash { get; private set; }

    public IReadOnlyCollection<Role> Roles => _roles;

    public IReadOnlyCollection<Contact> Contacts => _contacts;

    public Address? Address { get; private set; } = null!;

    private User()
    {
    }

    private User(string name, string registration)
    {
        Name = name;
        Registration = registration;
    }

    public static User Create(string name, string registration)
    {
        return new User(name, registration);
    }

    public void AddRole(Role role)
    {
        if (_roles.Any(r => r.Id == role.Id))
        {
            return;
        }

        _roles.Add(role);
    }

    public void RemoveRole(Role role) => _roles.RemoveAll(r => r.Id == role.Id);

    public void AddContact(Contact contact)
    {
        if (_contacts.Any(c => c.Id == contact.Id))
        {
            return;
        }

        _contacts.Add(contact);
    }

    public void UpdateContact(Contact contact)
    {
        var currentContacts = _contacts.FirstOrDefault(c => c.Id == contact.Id);

        if (currentContacts is null)
        {
            return;
        }

        currentContacts.Update(contact.Email, contact.Phone);
    }

    public void RemoveContact(Guid contactId) => _contacts.RemoveAll(c => c.Id == contactId);

    public void AddAddress(Address address)
    {
        if (Address is not null)
        {
            return;
        }

        Address = address;
    }

    public void UpdateAddress(Address address)
    {
        if (Address is null)
        {
            return;
        }

        Address.Update(
            address.Street,
            address.AddressNumber,
            address.Complement!,
            address.Zipcode,
            address.Neighborhood,
            address.City,
            address.State,
            address.Uf);
    }

    public void RemoveAddress() => Address = null;

    public void ChangePassword(string passwordHash) => PasswordHash = passwordHash;

    public void DeactivateUser() => Deactivate();
}
