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

            contactCtr.FirstName    = _currentContact.FirstName;
            contactCtr.LastName     = _currentContact.LastName;
            contactCtr.Email        = _currentContact.Email;
            contactCtr.PhoneNumber  = _currentContact.PhoneNumber;
            contactCtr.Address      = _currentContact.Address;
            contactCtr.PostalCode   = _currentContact.PostalCode;
            contactCtr.City         = _currentContact.City;
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

            changedContact.FirstName    = contactCtr.FirstName;
            changedContact.LastName     = contactCtr.LastName;
            changedContact.Email        = contactCtr.Email;
            changedContact.PhoneNumber  = contactCtr.PhoneNumber;
            changedContact.Address      = contactCtr.Address;
            changedContact.PostalCode   = contactCtr.PostalCode;
            changedContact.City         = contactCtr.City;

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