using Lib.Main.Factories;
using Lib.Main.Interfaces;
using UI.cli.Main.Interfaces;

namespace UI.cli.Main.MenuCommands
{
    internal class CmdAddContact(IContactService contactService) : IMenuCommand
    {
        private readonly IContactService _contactService = contactService;
        public string Description => "Add Contact";

        public void Execute()
        {
            var formModel = ContactFactory.Create();

            Console.WriteLine("Time to add a contact, here we go...");

            Console.Write("(Required!) First Name: ");
            formModel.FirstName = Console.ReadLine()!;

            Console.Write("(Required!) Last Name: ");
            formModel.LastName = Console.ReadLine()!;

            Console.Write("(Required!) Email: ");
            formModel.Email = Console.ReadLine()!;

            Console.Write("Phone: ");
            formModel.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Adress: ");
            formModel.Address = Console.ReadLine() ?? "";

            Console.Write("Postal Code: ");
            formModel.PostalCode = Console.ReadLine() ?? "";

            Console.Write("City: ");
            formModel.City = Console.ReadLine() ?? "";


            if (_contactService.AddContact(formModel))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nThanks for the entry!");
                Console.ForegroundColor = ConsoleColor.White;               
            }
            else
            {
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There was errors somewhere...");
                Console.ForegroundColor = ConsoleColor.White;
            }            
        }
    }
}
