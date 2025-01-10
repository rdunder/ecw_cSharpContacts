using Lib.Main.Factories;
using Lib.Main.Interfaces;
using Lib.Main.Models;
using System.Diagnostics;

namespace UI.Maui.Main.Views;


[QueryProperty(nameof(CurrentContact), "CurrentContact")]
public partial class EditContactPage : ContentPage
{
    private readonly IContactService _contactService;
    private ContactModel? _currentContact;

    public ContactModel CurrentContact
    {
        set
        {
            _currentContact = value;

            ContactCtr.FirstName    = _currentContact.FirstName;
            ContactCtr.LastName     = _currentContact.LastName;
            ContactCtr.Email        = _currentContact.Email;
            ContactCtr.PhoneNumber  = _currentContact.PhoneNumber;
            ContactCtr.Address      = _currentContact.Address;
            ContactCtr.PostalCode   = _currentContact.PostalCode;
            ContactCtr.City         = _currentContact.City;
        }
    }

    public EditContactPage(IContactService contactService)
	{
		InitializeComponent();

        _contactService = contactService;
        
	}



    private void btnSave_Clicked(object sender, EventArgs e)
    {

        if (_currentContact != null)
        {
            var changedContact = ContactFactory.Create();

            changedContact.FirstName    = ContactCtr.FirstName;
            changedContact.LastName     = ContactCtr.LastName;
            changedContact.Email        = ContactCtr.Email;
            changedContact.PhoneNumber  = ContactCtr.PhoneNumber;
            changedContact.Address      = ContactCtr.Address;
            changedContact.PostalCode   = ContactCtr.PostalCode;
            changedContact.City         = ContactCtr.City;

            if (_contactService.UpdateContact(_currentContact.Id, changedContact))
            {
                var updatedContact = _contactService.GetContactById(_currentContact.Id);

                var navParam = new ShellNavigationQueryParameters
                {
                    {"SelectedContact", updatedContact }
                };

                Shell.Current.GoToAsync("..", navParam);
            }
            else
            {
                DisplayAlert("Service Error", "There was an error in contact service when trying to update the contact", "OK");
               
            }
        }
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Debug.WriteLine("cliked cancel btn");

        Shell.Current.GoToAsync("..");
    }

    private void contactCtr_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}