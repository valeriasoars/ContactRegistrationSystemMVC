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

        public ContactModel Adiconar(ContactModel contact)
        {
            _bankContext.Contacts.Add(contact);
            _bankContext.SaveChanges(); 
            return contact;
        }
    }
}
