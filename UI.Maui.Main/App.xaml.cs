namespace UI.Maui.Main
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell())
            {
                Width = 500,
                Height = 1000,
                X = 10,
                Y = 10
            };
        }
    }
}