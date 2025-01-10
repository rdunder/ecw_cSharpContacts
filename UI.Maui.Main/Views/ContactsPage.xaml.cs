using Lib.Main.Interfaces;
using Lib.Main.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace UI.Maui.Main.Views;

public partial class ContactsPage : ContentPage
{
    private readonly IContactService _contactService;
    private ObservableCollection<ContactModel> _contacts = new();

    public ContactsPage(IContactService contactService)
    {
        InitializeComponent();
        _contactService = contactService;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _contacts = new ObservableCollection<ContactModel>( _contactService.GetAllContacts() );
        ContactsListView.ItemsSource = _contacts;
    }



    private void btnAddContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void ContactsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (ContactsListView.SelectedItem != null)
        {
            var selectedContact = e.SelectedItem as ContactModel ?? new ContactModel();
            var navParam = new ShellNavigationQueryParameters
            {
                {"SelectedContact", selectedContact }
            };
            Shell.Current.GoToAsync(nameof(ShowContactDetailsPage), navParam);
        }
    }

    private void ContactsListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        ContactsListView.SelectedItem = null;
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        ContactsListView.ItemsSource = _contacts.Where(x => x.LastName.StartsWith(SearchBar.Text, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}


