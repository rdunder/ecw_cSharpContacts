
using Lib.Main.Interfaces;
using UI.cli.Main.Interfaces;

namespace UI.cli.Main.MenuCommands;

internal class CmdGetAllContacts(IContactService contactService) : IMenuCommand
{
    private readonly IContactService _contactService = contactService;
    public string Description => "Show All Contacts";

    public void Execute()
    {
        var contacts = _contactService.GetAllContacts();

        if (contacts.Count() > 0)
        {
            Console.WriteLine("\nHere is the users curently in database\n");


            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.FirstName,-10}{contact.LastName,-15}{contact.Email,-25}{contact.PhoneNumber,12}");
                Console.WriteLine("ID: " + contact.Id + "\n");
            }
        }
        else
        {
            Console.WriteLine("There are currently no users registered");
        }
    }
}
