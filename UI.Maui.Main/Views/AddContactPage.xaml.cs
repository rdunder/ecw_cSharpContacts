using Lib.Main.Factories;
using Lib.Main.Interfaces;

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

        contactForm.FirstName   = ContactCtr.FirstName;
        contactForm.LastName    = ContactCtr.LastName;
        contactForm.Email       = ContactCtr.Email;
        contactForm.PhoneNumber = ContactCtr.PhoneNumber;
        contactForm.Address     = ContactCtr.Address;
        contactForm.PostalCode  = ContactCtr.PostalCode;
        contactForm.City        = ContactCtr.City;

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