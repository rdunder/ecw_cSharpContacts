

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lib.Main.Interfaces;
using Lib.Main.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace UI.Maui.MVVM.ViewModels;


public partial class MainPageViewModel : ObservableObject
{
    private readonly IContactService _contactService;

    [ObservableProperty]
    private ObservableCollection<ContactModel> _contacts = new();


    public MainPageViewModel(IContactService contactService)
    {
        _contactService = contactService;
        LoadContacts();
    }

    private void LoadContacts()
    {
        _contacts = new( _contactService.GetAllContacts().OrderBy(c => c.LastName) );
    }
}
