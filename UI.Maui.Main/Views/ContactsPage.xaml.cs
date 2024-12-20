using Lib.Main.Interfaces;
using Lib.Main.Models;
using System.Diagnostics;

namespace UI.Maui.Main.Views;

public partial class ContactsPage : ContentPage
{
    private readonly IContactService _contactService;

    public ContactsPage(IContactService contactService)
    {
        InitializeComponent();

        _contactService = contactService;
        var contacts = _contactService.GetAllContacts();
        ContactsListView.ItemsSource = contacts;
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
            Shell.Current.GoToAsync(nameof(EditContactPage), navParam);
        }
    }

    private void ContactsListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        ContactsListView.SelectedItem = null;
    }
}


    