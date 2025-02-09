﻿using Lib.Main.Factories;
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
    
    public bool AddContact(ContactFormModel contactForm)
    {
        if (_contacts.Any(c => c.Email == contactForm.Email)) return false;

        ContactEntity contactEntity = ContactFactory.Create(contactForm);
        contactEntity.Id = Guid.NewGuid();
        _contacts.Add(contactEntity);

        return SaveContactsToFile();
    }

    public IEnumerable<ContactModel> GetAllContacts()
    {
        return _contacts.Select(entity => ContactFactory.Create(entity)).ToList();
    }

    public ContactModel GetContactById(Guid id)
    {
        var entity = _contacts.FirstOrDefault(contact => contact.Id == id);
        return entity != null ? ContactFactory.Create(entity) : null!;
    }

    public bool RemoveContact(Guid id)
    {
        if (_contacts.All(contact => contact.Id != id)) 
            return false;

        _contacts.RemoveAll(entity => entity.Id == id);

        return SaveContactsToFile();
    }

    public bool UpdateContact(Guid id, ContactFormModel contactForm)
    {
        if (_contacts.All(contact => contact.Id != id)) 
            return false;

        //  Here i get a reference to the object that is in the list.
        //  So by changeing the reference, i will change the object in the list
        var entity = _contacts.FirstOrDefault(e => e.Id == id);

        if (entity == null)
            return false;

        entity.FirstName    = string.IsNullOrEmpty(contactForm.FirstName)   ? entity.FirstName     : contactForm.FirstName;
        entity.LastName     = string.IsNullOrEmpty(contactForm.LastName)    ? entity.LastName      : contactForm.LastName;
        entity.Email        = string.IsNullOrEmpty(contactForm.Email)       ? entity.Email         : contactForm.Email;
        entity.PhoneNumber  = string.IsNullOrEmpty(contactForm.PhoneNumber) ? entity.PhoneNumber   : contactForm.PhoneNumber;
        entity.Address      = string.IsNullOrEmpty(contactForm.Address)     ? entity.Address       : contactForm.Address;
        entity.PostalCode   = string.IsNullOrEmpty(contactForm.PostalCode)  ? entity.PostalCode    : contactForm.PostalCode;
        entity.City         = string.IsNullOrEmpty(contactForm.City)        ? entity.City          : contactForm.City;
        
        return SaveContactsToFile();
    }

    private bool SaveContactsToFile()
    {
        var jsonString = ContactJsonSerializer.Serialize(_contacts);

        return _fileService.WriteContentToFile(jsonString);
    }

    private List<ContactEntity> UpdateContactList()
    {
        try
        {
            return ContactJsonSerializer.Deserialize(_fileService.GetContentFromFile());
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"You got errors in ContactService.UpdateContactList: {ex.Message}");
            return new List<ContactEntity>();
        }
    }
}

