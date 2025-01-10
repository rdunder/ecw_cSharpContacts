
using Lib.Main.Models;

namespace Lib.Main.Factories;

public static class ContactFactory
{
    public static ContactFormModel Create() => new();

    public static ContactEntity Create(ContactFormModel formModel) => 
        formModel is null
            ? throw new ArgumentNullException(nameof(formModel))
            : new ContactEntity
            {
                FirstName = formModel.FirstName,
                LastName = formModel.LastName,
                Email = formModel.Email,
                PhoneNumber = formModel.PhoneNumber,
                PostalCode = formModel.PostalCode,
                Address = formModel.Address,
                City = formModel.City
            };

    public static ContactModel Create(ContactEntity contactEntity) =>
        contactEntity is null
        ? throw new ArgumentNullException(nameof(contactEntity))
        : new ContactModel
        {
            Id = contactEntity.Id,
            FirstName = contactEntity.FirstName,
            LastName = contactEntity.LastName,
            Email = contactEntity.Email,
            PhoneNumber = contactEntity.PhoneNumber,
            PostalCode = contactEntity.PostalCode,
            Address = contactEntity.Address,
            City = contactEntity.City
        };

    public static ContactFormModel Create(ContactModel contactModel) =>    
        contactModel is null
        ? throw new ArgumentNullException(nameof(contactModel))
        : new ContactFormModel
        {
            FirstName = contactModel.FirstName,
            LastName = contactModel.LastName,
            Email = contactModel.Email,
            PhoneNumber = contactModel.PhoneNumber,
            Address = contactModel.Address,
            PostalCode = contactModel.PostalCode,
            City = contactModel.City
        };
}
