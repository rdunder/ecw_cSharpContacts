using UI.Maui.MVVM.ViewModels;

namespace UI.Maui.MVVM.Pages;

public partial class ContactDetailsPage : ContentPage
{
	public ContactDetailsPage(ContactDetailsPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}