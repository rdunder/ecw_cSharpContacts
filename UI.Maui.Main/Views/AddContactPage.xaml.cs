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
        contactForm.FirstName = entryFirstName.Text;
        contactForm.LastName = entryLastName.Text;
        contactForm.Email = entryEmail.Text;
        contactForm.PhoneNumber = entryPhone.Text;
        contactForm.Address = entryAddress.Text;
        contactForm.PostalCode = entryPostal.Text;
        contactForm.City = entryCity.Text;

        if (_contactService.AddContact(contactForm))
        {
            Shell.Current.GoToAsync("..");
        }
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}