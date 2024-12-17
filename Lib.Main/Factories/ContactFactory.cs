
using Lib.Main.Models;
using System.Diagnostics;

namespace Lib.Main.Factories;

public static class ContactFactory
{
    public static ContactFormModel Create() => new ContactFormModel();

    public static ContactEntity Create(ContactFormModel formModel)
    {
        try
        {
            return new ContactEntity()
            {
                FirstName = formModel.FirstName,
                LastName = formModel.LastName,
                Email = formModel.Email,
                PhoneNumber = formModel.PhoneNumber,
                PostalCode = formModel.PostalCode,
                Address = formModel.Address,
                City = formModel.City,
            };
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error when creating Contact Entity:\n{ex.Message}\n");
            return new ContactEntity();
        }
    }

    public static ContactModel Create(ContactEntity contactEntity)
    {
        try
        {
            return new ContactModel()
            {
                Id = contactEntity.Id,
                FirstName = contactEntity.FirstName,
                LastName = contactEntity.LastName,
                Email = contactEntity.Email,
                PhoneNumber = contactEntity.PhoneNumber,
                PostalCode = contactEntity.PostalCode,
                Address = contactEntity.Address,
                City = contactEntity.City,
            };
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error when creating Contact Entity:\n{ex.Message}\n");
            return new ContactModel();
        }
    }
}
