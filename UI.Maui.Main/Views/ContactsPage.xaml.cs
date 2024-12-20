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
        ContactsCollection.ItemsSource = contacts;
	}




    private void btnAddContact_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(AddContactPage));
    }


    //  Send Selected contact to EditContactPage on the event of selecting a contact from the collectionview
    private void ContactsCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedContact = e.CurrentSelection.FirstOrDefault() as ContactModel ?? new ContactModel();
        var navParam = new ShellNavigationQueryParameters
        {
            {"SelectedContact", selectedContact }
        };
        Shell.Current.GoToAsync(nameof(EditContactPage), navParam);
    }
}