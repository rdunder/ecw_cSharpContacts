

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lib.Main.Factories;
using Lib.Main.Interfaces;
using Lib.Main.Models;
using UI.Maui.MVVM.Pages;

namespace UI.Maui.MVVM.ViewModels;

public partial class ContactAddPageViewModel : ObservableObject
{
    private readonly IContactService _contactService;

    [ObservableProperty]
    private ContactFormModel _contactForm = ContactFactory.Create();


    public ContactAddPageViewModel(IContactService contactService)
    {
        _contactService = contactService;
        
    }



    [RelayCommand]
    public async Task AddContact()
    {
        if (ContactForm != null)
        {
            if (_contactService.AddContact(ContactForm))
            {
                ContactForm = ContactFactory.Create();
                await Shell.Current.GoToAsync(nameof(MainPage));
            }
            else
            {
                ContactForm.FirstName = "There was ERRORS";
            }
        }
    }
}
