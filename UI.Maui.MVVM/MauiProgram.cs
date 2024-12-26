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


            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();



            builder.Services.AddSingleton<IFileService, ContactFileService>(fs =>
                new ContactFileService(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "DialHard"),
                    "Database.json"
                ));
            builder.Services.AddSingleton<IContactService, ContactService>();




#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
