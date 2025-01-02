using Lib.Main.Interfaces;
using Lib.Main.Models;

namespace UI.Maui.Main.Views;

[QueryProperty(nameof(SelectedContact), "SelectedContact")]
public partial class ShowContactDetailsPage : ContentPage
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

    public ShowContactDetailsPage(IContactService contactService)
    {
        InitializeComponent();

        _contactService = contactService;
    }



    private void btnBack_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void btnEdit_Clicked(object sender, EventArgs e)
    {
        if (_currentContact != null)
        {
            var navParam = new ShellNavigationQueryParameters
            {
                {"CurrentContact", _currentContact }
            };
            Shell.Current.GoToAsync(nameof(EditContactPage), navParam);
        }
    }

    private void btnRemove_Clicked(object sender, EventArgs e)
    {
        if (_currentContact != null)
        {
            _contactService.RemoveContact(_currentContact.Id);
            Shell.Current.GoToAsync("..");
        }
    }
}