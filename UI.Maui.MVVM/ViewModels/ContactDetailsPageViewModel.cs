

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lib.Main.Interfaces;
using Lib.Main.Models;
using UI.Maui.MVVM.Pages;

namespace UI.Maui.MVVM.ViewModels;


[QueryProperty("SelectedContact", "SelectedContact")]
public partial class ContactDetailsPageViewModel(IContactService contactService) : ObservableObject
{
    IContactService _contactService = contactService;

    [ObservableProperty]
    private ContactModel _selectedContact = new();

    [RelayCommand]
    public void DeleteContact()
    {
        if (_selectedContact != null)
        {
            _contactService.RemoveContact(_selectedContact.Id);
            Shell.Current.GoToAsync(nameof(MainPage));
        }
    }
}
