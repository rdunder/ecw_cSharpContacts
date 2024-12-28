

using CommunityToolkit.Mvvm.ComponentModel;
using Lib.Main.Models;

namespace UI.Maui.MVVM.ViewModels;


[QueryProperty("SelectedContact", "SelectedContact")]
public partial class ContactDetailsPageViewModel : ObservableObject
{
    [ObservableProperty]
    private ContactModel _selectedContact = new();

    
}
