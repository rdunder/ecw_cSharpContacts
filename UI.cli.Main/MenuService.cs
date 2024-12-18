

using Lib.Main.Interfaces;
using Microsoft.Extensions.Hosting;
using UI.cli.Main.Interfaces;
using UI.cli.Main.MenuCommands;

namespace UI.cli.Main;

internal class MenuService
{
    private readonly IContactService _contactService;
    private readonly List<IMenuCommand> _commands;

    public MenuService(IContactService contactService)
    {
        _contactService = contactService;
        _commands = new List<IMenuCommand>()
        {
            new CmdAddContact(contactService),
            new CmdGetAllContacts(contactService),
            new CmdTestingRemoveUpdate(contactService)
        };
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("********************************************************");
            Console.WriteLine("OBS! this app is saving a file called Database.json in");
            Console.WriteLine($"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "DialHard")}");
            Console.WriteLine("********************************************************\n\n");
            Console.ForegroundColor = ConsoleColor.White;


            Console.WriteLine("Welcome to the App of the year!\n");
            Console.WriteLine("___Its___Time___To___Dial___Hard___\n");

            Console.WriteLine("=== Main Menu ===\n");

            for (int i = 0; i < _commands.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {_commands[i].Description}");
            }

            Console.WriteLine("\nQ: Quit the program\n");
            Console.WriteLine("=================");


            if (!ProcessMenuSelection(Console.ReadKey(true))) break;
        }
    }

    public bool ProcessMenuSelection(ConsoleKeyInfo key)
    {
        if (key.KeyChar.ToString().ToLower() == "q")
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to quit?\t(y/n)");
            if (Console.ReadKey().KeyChar == 'y')
            {
                return false;
            }
            return true;
        }

        if (int.TryParse(key.KeyChar.ToString(), out int select)
            && select > 0
            && select <= _commands.Count)
        {
            try
            {
                _commands[select - 1].Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An Errror Occured\n{ex}\n_____________________");
            }
        }
        else
        {
            Console.WriteLine("That is not a valid input ...!");
        }

        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();
        return true;
    }
}
