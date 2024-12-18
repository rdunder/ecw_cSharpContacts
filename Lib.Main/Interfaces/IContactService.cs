

using Lib.Main.Models;

namespace Lib.Main.Interfaces;

public interface IContactService
{
    public bool AddContact(ContactFormModel contactForm);
    public IEnumerable<ContactModel> GetAllContacts();
    public ContactModel GetContactById(Guid id);
    public bool RemoveContact(Guid id);
    public bool UpdateContact(Guid id, ContactFormModel contactForm);
}
