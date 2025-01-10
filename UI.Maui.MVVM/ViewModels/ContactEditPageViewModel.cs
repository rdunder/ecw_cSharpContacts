

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lib.Main.Factories;
using Lib.Main.Interfaces;
using Lib.Main.Models;
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
        if ( _contactService.UpdateContact( CurrentContact.Id, ContactFactory.Create(CurrentContact) ) )
        {
            var editedContact = _contactService.GetContactById(CurrentContact.Id);

            var navParams = new ShellNavigationQueryParameters
            {
                {"EditedContact", editedContact}
            };

            Shell.Current.GoToAsync(nameof(ContactDetailsPage), navParams);
        }
    }
}
