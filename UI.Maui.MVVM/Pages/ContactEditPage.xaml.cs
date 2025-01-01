using UI.Maui.MVVM.ViewModels;

namespace UI.Maui.MVVM.Pages;

public partial class ContactEditPage : ContentPage
{
	public ContactEditPage(ContactEditPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }
}