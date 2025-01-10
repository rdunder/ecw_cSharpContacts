

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lib.Main.Interfaces;
using Lib.Main.Models;
using UI.Maui.MVVM.Pages;

namespace UI.Maui.MVVM.ViewModels;


[QueryProperty("SelectedContact", "SelectedContact")]
[QueryProperty("SelectedContact", "EditedContact")]
public partial class ContactDetailsPageViewModel(IContactService contactService) : ObservableObject
{
    IContactService _contactService = contactService;

    [ObservableProperty]
    private ContactModel _selectedContact = new();

    [RelayCommand]
    public void DeleteContact()
    {
        if (SelectedContact != null)
        {
            _contactService.RemoveContact(SelectedContact.Id);
            Shell.Current.GoToAsync(nameof(MainPage));
        }
    }

    [RelayCommand]
    public void EditContact()
    {
        if (SelectedContact != null)
        {
            var navParams = new ShellNavigationQueryParameters
            {
                {"CurrentContact", SelectedContact}
            };
            Shell.Current.GoToAsync(nameof(ContactEditPage), navParams);
        }

    }
}
