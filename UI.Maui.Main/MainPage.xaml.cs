using Lib.Main.Interfaces;
using Lib.Main.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace UI.Maui.Main;

public partial class MainPage : ContentPage
{
    private readonly IContactService _contactService;
    public List<ContactModel> Contacts { get; set; }

    public MainPage(IContactService contactService)
    {
        InitializeComponent();
        _contactService = contactService;
        Contacts = _contactService.GetAllContacts().ToList();

        foreach (ContactModel contact in Contacts)
        {
            new Label()
            {
                Text = $"{contact.FirstName} {contact.LastName} {contact.Email}",
                TextColor = Colors.Aquamarine,
                FontSize = 20
            };
        }

    }

    //private void LoadContacts()
    //{
    //    var contactList = _contactService.GetAllContacts();
    //    foreach (var contact in contactList)
    //    {
    //        //Contacts.Add(contact);
    //        _contacts.Add(new ContactViewModel(contact));
    //    }
    //}

   

}