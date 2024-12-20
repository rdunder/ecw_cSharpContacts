using Lib.Main.Interfaces;
using Lib.Main.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace UI.Maui.Main;

public partial class MainPage : ContentPage
{
    private readonly IContactService _contactService;
    public ObservableCollection<ContactModel> Contacts { get; set; } = new();

    public MainPage(IContactService contactService)
    {
        InitializeComponent();
        _contactService = contactService;
        LoadContacts();
        BindingContext = this;
    }

    private void LoadContacts()
    {
        var contactList = _contactService.GetAllContacts();
        foreach (var contact in contactList)
        {
            //Contacts.Add(contact);
            Contacts.Add(contact);
        }
    }


    private async void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        var contact = (ContactModel)e.SelectedItem;

        // Update details view
        detailsTitle.Text = contact.FirstName;
        phoneLabel.Text = contact.PhoneNumber;
        addressLabel.Text = contact.Address;
        postalLabel.Text = contact.PostalCode;
        cityLabel.Text = contact.City;

        // Show details with animation
        detailsFrame.IsVisible = true;
        await detailsFrame.TranslateTo(0, 0, 250, Easing.CubicOut);

        // Deselect the item
        ((ListView)sender).SelectedItem = null;
    }

    private async void OnCloseDetails(object sender, EventArgs e)
    {
        await detailsFrame.TranslateTo(0, detailsFrame.Height, 250, Easing.CubicIn);
        detailsFrame.IsVisible = false;
    }

}