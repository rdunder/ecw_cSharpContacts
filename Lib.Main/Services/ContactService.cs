using Lib.Main.Factories;
using Lib.Main.Helpers;
using Lib.Main.Interfaces;
using Lib.Main.Models;
using System.Diagnostics;

namespace Lib.Main.Services;

public class ContactService : IContactService
{
    private readonly IFileService _fileService;
    private readonly List<ContactEntity> _contacts;

    public ContactService(IFileService fileService)
    {
        _fileService = fileService;
        _contacts = ContactJsonSerializer.Deserialize(_fileService.GetContentFromFile());
    }



    public bool AddContact(ContactFormModel contactForm)
    {
        try
        {
            ContactEntity contactEntity = ContactFactory.Create(contactForm);
            contactEntity.Id = Guid.NewGuid();
            _contacts.Add(contactEntity);

            _fileService.WriteContentToFile(ContactJsonSerializer.Serialize(_contacts));

            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ContactService got errors when on add contact: " + ex.Message);
            return false;
        }
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
        throw new NotImplementedException();
        //try
        //{
        //    //  Update _contacts from repo and send user back according to ID
        //    return ContactFactory.Create(_contacts.Where(contact => contact.Id == id).FirstOrDefault());
        //}
        //catch (Exception ex)
        //{
        //    Debug.WriteLine($"You got errors in ContactService.GetContactById: {ex.Message}");
        //    return new ContactModel();
        //}        
    }

    public bool RemoveContact(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ContactModel> UpdateContact(Guid id, ContactFormModel contactForm)
    {
        throw new NotImplementedException();
    }
}
