using ContactRegistrationMVC.Data;
using ContactRegistrationMVC.Models;
using ContactRegistrationMVC.Repository.Interface;

namespace ContactRegistrationMVC.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly BankContext _bankContext;
        public ContactRepository(BankContext bankContext)
        { 
            _bankContext = bankContext;
        }

        public ContactModel ListById(int id)
        {
            return _bankContext.Contacts.FirstOrDefault(x => x.Id == id);
        }

        public List<ContactModel> SearchAllRecords()
        {
            return _bankContext.Contacts.ToList();
        }

        public ContactModel ToAdd(ContactModel contact)
        {
            _bankContext.Contacts.Add(contact);
            _bankContext.SaveChanges(); 
            return contact;
        }

        public ContactModel ToUpdate(ContactModel contact)
        {
            ContactModel contactDB = ListById(contact.Id);

            if (contactDB == null) throw new Exception("Houve um erro na atualização do contato!");

            contactDB.Name = contact.Name;
            contactDB.Email = contact.Email;
            contactDB.Phone = contact.Phone;

            _bankContext.Contacts.Update(contactDB);
            _bankContext.SaveChanges();
            return contactDB;

        }
    }
}
