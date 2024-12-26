using UI.Maui.MVVM.ViewModels;

namespace UI.Maui.MVVM.Pages;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}