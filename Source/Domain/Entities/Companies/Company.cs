using Common;
using Domain.Entities.Addresses;
using Domain.Entities.Contacts;
using Domain.Interfaces;

namespace Domain.Entities.Companies;

public sealed class Company : Entity, IAggregateRoot
{
    private readonly List<Contact> _contacts = [];

    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public string Document { get; set; } = string.Empty;

    public string AvatarUrl { get; private set; } = string.Empty;

    public Address? Address { get; private set; } = null!;

    public IReadOnlyCollection<Contact> Contacts => _contacts;

    private Company()
    {
    }

    private Company(string name, string description, string document, string avatarUrl)
    {
        Name = name;
        Description = description;
        Document = document;
        AvatarUrl = avatarUrl;
    }

    public static Company Create(
        string name,
        string description,
        string document,
        string avatarUrl)
    {
        return new Company(name, description, document, avatarUrl);
    }

    public void Update(string description, string avatarUrl)
    {
        Description = description;
        AvatarUrl = avatarUrl;
    }

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

        currentContacts.Update(contact.Email!, contact.Phone!);
    }

    public void RemoveContact(Guid contactId) => _contacts.RemoveAll(c => c.Id == contactId);

    public void SetAsDisable(Guid companyId) => Deactivate(companyId);
}
