using UI.Maui.Testing.Models;
using UI.Maui.Testing.PageModels;

namespace UI.Maui.Testing.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}