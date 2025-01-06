using Lib.Main.Factories;
using Lib.Main.Interfaces;
using System.Diagnostics;

namespace UI.Maui.Main.Views;

public partial class AddContactPage : ContentPage
{
    IContactService _contactService;

	public AddContactPage(IContactService contactService)
	{
		InitializeComponent();
        _contactService = contactService;
	}

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        var contactForm = ContactFactory.Create();

        contactForm.FirstName   = contactCtr.FirstName;
        contactForm.LastName    = contactCtr.LastName;
        contactForm.Email       = contactCtr.Email;
        contactForm.PhoneNumber = contactCtr.PhoneNumber;
        contactForm.Address     = contactCtr.Address;
        contactForm.PostalCode  = contactCtr.PostalCode;
        contactForm.City        = contactCtr.City;

        if (_contactService.AddContact(contactForm))
        {
            Shell.Current.GoToAsync("..");
        }
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void contactControl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}