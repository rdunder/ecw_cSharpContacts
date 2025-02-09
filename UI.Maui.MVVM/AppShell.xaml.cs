﻿using UI.Maui.MVVM.Pages;

namespace UI.Maui.MVVM
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(ContactAddPage), typeof(ContactAddPage));
            Routing.RegisterRoute(nameof(ContactDetailsPage), typeof(ContactDetailsPage));
            Routing.RegisterRoute(nameof(ContactEditPage), typeof(ContactEditPage));
        }
    }
}
