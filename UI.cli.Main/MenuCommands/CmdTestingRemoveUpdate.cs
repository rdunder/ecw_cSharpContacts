

using Lib.Main.Factories;
using Lib.Main.Interfaces;
using Lib.Main.Models;
using UI.cli.Main.Interfaces;

namespace UI.cli.Main.MenuCommands;

internal class CmdTestingRemoveUpdate : IMenuCommand
{
    private readonly IContactService _contactService;
    private ContactModel[] _contacts;
    public string Description => "Test Remove and Update";

    public CmdTestingRemoveUpdate(IContactService contactService)
    {
        _contactService = contactService;
        _contacts = _contactService.GetAllContacts().ToArray();
    }


    public void Execute()
    {
        Console.Clear();
        Console.WriteLine("here are the current contacts\n");
        ListAllContacts();

        Console.WriteLine("\ncreating a testContact\n");
        var newContact = ContactFactory.Create();
        newContact.FirstName = "testFirstname";
        newContact.LastName = "TestLastname";
        newContact.Email = "test@domain.com";

        _contactService.AddContact(newContact);

        Console.WriteLine("\ntest contact is added\n");
        UpdateContactList();
        ListAllContacts();
        Console.ReadKey();



        Console.Clear();
        Console.WriteLine("\ngetting the newly created contact by its id\n");
        var testContact = _contactService.GetContactById(_contacts.Last().Id);

        Console.WriteLine("Presenting the test contact:");
        Console.WriteLine($"{testContact.FirstName} {testContact.LastName} - {testContact.Email}\n");

        Console.Write($"\nchange first name of test contact: ");

        var formModel = ContactFactory.Create();
        formModel.FirstName = Console.ReadLine() ?? "";

        _contactService.UpdateContact(testContact.Id, formModel);

        UpdateContactList();
        Console.WriteLine("\nHere is the updated List of contacts.\n");
        ListAllContacts();
        Console.ReadKey();

        Console.Clear();
        Console.WriteLine("\nNow removing the test contact");
        _contactService.RemoveContact(testContact.Id);

        UpdateContactList();
        Console.WriteLine("\nhere is the list after removing the test contact\n");
        ListAllContacts();
    }

    private void ListAllContacts()
    {        
        for (int i = 0; i < _contacts.Length; i++)
        {
            Console.WriteLine($"{_contacts[i].FirstName} {_contacts[i].LastName} - {_contacts[i].Email}");
        }
    }

    private void UpdateContactList()
    {
        _contacts = _contactService.GetAllContacts().ToArray();
    }
}
