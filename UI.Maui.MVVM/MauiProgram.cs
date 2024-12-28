using Lib.Main.Interfaces;
using Lib.Main.Services;
using Microsoft.Extensions.Logging;
using UI.Maui.MVVM.Pages;
using UI.Maui.MVVM.ViewModels;

namespace UI.Maui.MVVM
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });




            builder.Logging.AddDebug();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<ContactAddPage>();
            builder.Services.AddTransient<ContactAddPageViewModel>();
            builder.Services.AddTransient<ContactDetailsPage>();
            builder.Services.AddTransient<ContactDetailsPageViewModel>();



            builder.Services.AddSingleton<IFileService, ContactFileService>(fs =>
                new ContactFileService(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "DialHard"),
                    "Database.json"
                ));
            builder.Services.AddSingleton<IContactService, ContactService>();






            return builder.Build();
        }
    }
}
