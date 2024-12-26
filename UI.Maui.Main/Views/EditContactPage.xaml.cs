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

            firstName.Text = _currentContact.FirstName;
            lastName.Text = _currentContact.LastName;
            email.Text = _currentContact.Email;
            phoneNumber.Text = _currentContact.PhoneNumber;
            address.Text = _currentContact.Address;
            postalCode.Text = _currentContact.PostalCode;
            city.Text = _currentContact.City;
        }
    }

    public EditContactPage(IContactService contactService)
	{
		InitializeComponent();

        _contactService = contactService;
        
	}



    private void btnSave_Clicked(object sender, EventArgs e)
    {
        if (firstNameValidator.IsNotValid)
        {
            DisplayAlert("ERROR", "First name need to be at least 2 letters long", "go back");
            return;
        }

        if (emailValidator.IsNotValid)
        {
            string error = "";

            foreach(var err in emailValidator.Errors)
            {
                error += $"{err}\n";    
            }

            DisplayAlert("error", error, "go back");

            return;
        }

        if (_currentContact != null)
        {
            var changedContact = ContactFactory.Create();
            changedContact.FirstName = firstName.Text;
            changedContact.LastName = lastName.Text;
            changedContact.Email = email.Text;
            changedContact.PhoneNumber = phoneNumber.Text;
            changedContact.Address = address.Text;
            changedContact.PostalCode = postalCode.Text;
            changedContact.City = city.Text;

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
                feedback.Text = "Something went south";
               
            }
        }
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Debug.WriteLine("cliked cancel btn");

        Shell.Current.GoToAsync("..");
    }
}