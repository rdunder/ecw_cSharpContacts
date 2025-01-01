
using UI.Maui.MVVM.ViewModels;

namespace UI.Maui.MVVM.Pages;

public partial class MainPage : ContentPage
{
    MainPageViewModel _viewModel;
	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
		BindingContext = _viewModel;
	}

    private void btnGoToAddContact_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(ContactAddPage));
    }

   
}