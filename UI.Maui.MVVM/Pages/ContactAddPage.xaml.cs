using UI.Maui.MVVM.ViewModels;

namespace UI.Maui.MVVM.Pages;

public partial class ContactAddPage : ContentPage
{
	public ContactAddPage(ContactAddPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }
}