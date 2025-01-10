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
            ViewName.Text = $"Name: {_currentContact.FullName}";
            ViewEmail.Text = $"Email: {_currentContact.Email}";
            ViewPhone.Text = $"Phone: {_currentContact.PhoneNumber}";
            ViewAddress.Text = $"Adress: {_currentContact.Address}";
            ViewPostal.Text = $"Postal Code: {_currentContact.PostalCode}";
            ViewCity.Text = $"City: {_currentContact.City}";
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