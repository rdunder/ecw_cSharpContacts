
using Lib.Main.Interfaces;
using Lib.Main.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UI.cli.Main;

string basePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "DialHard");
string fileName = "Database.json";

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<IFileService, ContactFileService>(fs =>
            new ContactFileService(basePath, fileName));
        services.AddSingleton<IContactService, ContactService>();
        services.AddSingleton<MenuService>();
    })
    .Build();

var menu = host.Services.GetRequiredService<MenuService>();
menu.Run();



