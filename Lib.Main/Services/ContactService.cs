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
        _contacts = UpdateContactList();
    }



    public void AddContact(ContactFormModel contactForm)
    {
        ContactEntity contactEntity = ContactFactory.Create(contactForm);
        contactEntity.Id = Guid.NewGuid();
        _contacts.Add(contactEntity);
                
        if (!_fileService.WriteContentToFile(ContactJsonSerializer.Serialize(_contacts)))
        {
            throw new IOException("Errors in FileService.WriteContentToFile");
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

