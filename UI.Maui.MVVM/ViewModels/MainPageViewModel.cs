
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lib.Main.Interfaces;
using Lib.Main.Models;
using System.Collections.ObjectModel;
using UI.Maui.MVVM.Pages;

namespace UI.Maui.MVVM.ViewModels;


public partial class MainPageViewModel : ObservableObject
{
    private readonly IContactService _contactService;

    [ObservableProperty]
    private ObservableCollection<ContactModel> _contacts = new();

    [ObservableProperty]
    private ContactModel _selectedContact = new();

    [ObservableProperty]
    private List<object> _selectedItems = new();


    public MainPageViewModel(IContactService contactService)
    {
        _contactService = contactService;
        LoadContacts();

        //  Tried to add this because of the navstack keeps growing infinite, but the navigation breaks when adding this.
        //
        //var nav = Shell.Current.Navigation;
        //if (nav.NavigationStack.Count() > 2)
        //{
        //    nav.PopAsync();
        //}
    }

    private void LoadContacts()
    {
        Contacts = new( _contactService.GetAllContacts().OrderBy(c => c.LastName) );
    }

    [RelayCommand]
    public void ShowContactDetails()
    {
        if (SelectedContact != null)
        {
            var navParam = new ShellNavigationQueryParameters
            {
                {"SelectedContact", SelectedContact }
            };

            Shell.Current.GoToAsync(nameof(ContactDetailsPage), navParam);
        }
    }

    [RelayCommand]
    public void SearchContact(string query)
    {
        if (query == string.Empty)
        {
            LoadContacts();
            return;
        }            

        var filteredList = Contacts.Where(x => x.LastName.StartsWith(query, StringComparison.OrdinalIgnoreCase)).ToList();
        Contacts = new(filteredList);
    }
}
