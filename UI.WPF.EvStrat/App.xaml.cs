
using Lib.Main.Interfaces;
using Lib.Main.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Windows;

namespace UI.WPF.EvStrat;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IHost _builder;

    private string basePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "DialHard");
    private string fileName = "Database.json";

    public App()
    {
        _builder = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {

                services.AddSingleton<IFileService, ContactFileService>(fs =>
                    new ContactFileService(basePath, fileName));
                services.AddSingleton<IContactService, ContactService>();

            })
            .Build();
    }
}
