
using UI.Maui.MVVM.ViewModels;

namespace UI.Maui.MVVM.Pages;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    private void btnGoToAddContact_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(ContactAddPage));
    }

   
}