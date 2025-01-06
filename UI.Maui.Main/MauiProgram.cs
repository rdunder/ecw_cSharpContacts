using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Lib.Main.Interfaces;
using Lib.Main.Factories;
using Lib.Main.Services;

namespace UI.Maui.Main;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });


#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<IFileService, ContactFileService>(fs =>
            new ContactFileService(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "DialHard"),
                "Database.json"
            ));
        builder.Services.AddSingleton<IContactService, ContactService>();

        return builder.Build();
    }
}
