using Lib.Main.Factories;
using Lib.Main.Helpers;
using Lib.Main.Interfaces;
using Lib.Main.Models;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lib.Main.Services;

public class ContactService : IContactService
{
    private readonly IFileService _fileService;
    private readonly List<ContactEntity> _contacts;

    public ContactService(IFileService fileService)
    {
        _fileService = fileService;
        _contacts = UpdateContactList();
    }




    //  save json in a variable, in a try/catch, then use if statement on fileservice
    //  change this method to return a bool.
    //  Test if email already exists, then return false
    //  Maybe create a model that reps return object with error message?
    //
    //
    public bool AddContact(ContactFormModel contactForm)
    {
        if (_contacts.Any(c => c.Email == contactForm.Email)) return false;

        ContactEntity contactEntity = ContactFactory.Create(contactForm);
        contactEntity.Id = Guid.NewGuid();
        _contacts.Add(contactEntity);

        try
        {
            var jsonString = ContactJsonSerializer.Serialize(_contacts);
            if (!_fileService.WriteContentToFile(jsonString))
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ContactService.AddContact: Errors with json serialize" + ex.Message);
            return false;
        }
        return true;
    }

    public IEnumerable<ContactModel> GetAllContacts()
    {
        List<ContactModel> returnContacts = new List<ContactModel>();
        foreach (ContactEntity contactEntity in _contacts)
        {
            returnContacts.Add(ContactFactory.Create(contactEntity));
        }
        return returnContacts;
    }

    public ContactModel GetContactById(Guid id)
    {
        var entity = _contacts.FirstOrDefault(contact => contact.Id == id);
        if (entity != null)
            return ContactFactory.Create(entity);

        return null!;      
    }

    public bool RemoveContact(Guid id)
    {
        if (!_contacts.Any(_contact => _contact.Id == id)) return false;

        try
        {
            _contacts.RemoveAll(entity => entity.Id == id);
            var jsonString = ContactJsonSerializer.Serialize(_contacts);

            if (!_fileService.WriteContentToFile(jsonString))
            {
                return false;
            }
        }
        catch
        {
            return false;
        }

        return true;
    }

    public bool UpdateContact(Guid id, ContactFormModel contactForm)
    {
        if (!_contacts.Any(contact => contact.Id == id)) return false;

        var entity = _contacts.Where(e => e.Id == id).FirstOrDefault();
        if (entity == null)
            return false;

        entity.FirstName    = string.IsNullOrEmpty(contactForm.FirstName)   ? entity.FirstName     : contactForm.FirstName;
        entity.LastName     = string.IsNullOrEmpty(contactForm.LastName)    ? entity.LastName      : contactForm.LastName;
        entity.Email        = string.IsNullOrEmpty(contactForm.Email)       ? entity.Email         : contactForm.Email;
        entity.PhoneNumber  = string.IsNullOrEmpty(contactForm.PhoneNumber) ? entity.PhoneNumber   : contactForm.PhoneNumber;
        entity.Address      = string.IsNullOrEmpty(contactForm.Address)     ? entity.Address       : contactForm.Address;
        entity.PostalCode   = string.IsNullOrEmpty(contactForm.PostalCode)  ? entity.PostalCode    : contactForm.PostalCode;
        entity.City         = string.IsNullOrEmpty(contactForm.City)        ? entity.City          : contactForm.City;

        var jsonString = ContactJsonSerializer.Serialize(_contacts);

        if (!_fileService.WriteContentToFile(jsonString))
        {
            return false;
        }

        return true;
    }

    private List<ContactEntity> UpdateContactList()
    {
        try
        {
            return ContactJsonSerializer.Deserialize(_fileService.GetContentFromFile()) ?? new List<ContactEntity>();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"You got errors in ContactService.UpdateContactList: {ex.Message}");
            return new List<ContactEntity>();
        }
    }
}

