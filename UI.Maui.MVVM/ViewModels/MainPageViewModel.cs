

using CommunityToolkit.Mvvm.ComponentModel;
using Lib.Main.Interfaces;
using Lib.Main.Models;
using System.Collections.ObjectModel;

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
        var contacts = _contactService.GetAllContacts();
        foreach (var contact in contacts)
        {
            _contacts.Add(contact);
        }
    }
}
