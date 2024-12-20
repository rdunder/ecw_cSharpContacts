using Lib.Main.Interfaces;
using Lib.Main.Models;

namespace UI.Maui.Main.Views;


[QueryProperty(nameof(SelectedContact), "SelectedContact")]
public partial class EditContactPage : ContentPage
{
    private readonly IContactService _contactService;
    private ContactModel? _currentContact;

    public ContactModel SelectedContact
    {
        set
        {
            _currentContact = value;
            viewName.Text = $"Name: {_currentContact.FullName}";
            viewEmail.Text = $"Email: {_currentContact.Email}";
            viewPhone.Text = $"Phone: {_currentContact.PhoneNumber}";
            viewAdress.Text = $"Adress: {_currentContact.Address}";
            viewPostal.Text = $"Postal Code: {_currentContact.PostalCode}";
            viewCity.Text = $"City: {_currentContact.City}";
        }
    }

    public EditContactPage(IContactService contactService)
	{
		InitializeComponent();

        _contactService = contactService;
        
	}



    private void btnSave_Clicked(object sender, EventArgs e)
    {

    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}