using UI.Maui.MVVM.ViewModels;

namespace UI.Maui.MVVM.Pages;

public partial class ContactDetailsPage : ContentPage
{
	public ContactDetailsPage(ContactDetailsPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    private void btnBack_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(MainPage));
    }
}