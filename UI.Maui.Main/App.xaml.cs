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
            if (DeviceInfo.Current.Platform.ToString() == "WinUI")
            {
                return new Window(new AppShell())
                {
                    Width = 500,
                    Height = 1000,
                    X = 10,
                    Y = 10
                };
            }
            return new Window(new AppShell());
        }
    }
}