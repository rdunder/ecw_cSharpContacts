

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lib.Main.Factories;
using Lib.Main.Interfaces;
using Lib.Main.Models;
using System.Diagnostics;
using UI.Maui.MVVM.Pages;

namespace UI.Maui.MVVM.ViewModels;


[QueryProperty("CurrentContact", "CurrentContact")]
public partial class ContactEditPageViewModel : ObservableObject
{
    IContactService _contactService;

    [ObservableProperty]
    private ContactModel _currentContact = new();

    public ContactEditPageViewModel(IContactService contactService)
    {
        _contactService = contactService;
    }

    [RelayCommand]
    public void SaveEditedContact()
    {
        var contactForm = ContactFactory.Create();
        contactForm.FirstName = _currentContact.FirstName;
        contactForm.LastName = _currentContact.LastName;
        contactForm.Email = _currentContact.Email;
        contactForm.PhoneNumber = _currentContact.PhoneNumber;
        contactForm.Address = _currentContact.Address;
        contactForm.PostalCode = _currentContact.PostalCode;
        contactForm.City = _currentContact.City;

        if (_contactService.UpdateContact(_currentContact.Id, contactForm))
        {
            var editedContact = _contactService.GetContactById(_currentContact.Id);

            var navParams = new ShellNavigationQueryParameters
            {
                {"EditedContact", editedContact}
            };

            Shell.Current.GoToAsync(nameof(ContactDetailsPage), navParams);
        }
    }
}
