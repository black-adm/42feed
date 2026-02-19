using Common;
using Domain.Entities.Companies;
using Domain.Interfaces;

namespace Domain.Entities.Contacts;

public sealed class Contact : Entity, IAggregateRoot
{
    public string? Email { get; private set; } = null!;

    public string? Phone { get; private set; } = null!;

    public Company Company { get; private set; } = null!;

    public User User { get; private set; } = null!;

    private Contact()
    {
    }

    private Contact(string email, string phone)
    {
        Email = email;
        Phone = phone;
    }

    public static Contact Create(string email, string phone)
    {
        return new Contact(email, phone);
    }

    public void Update(string email, string phone)
    {
        Email = email;
        Phone = phone;
    }

    public void SetAsDisable(Guid contactId) => Deactivate(contactId);
}
