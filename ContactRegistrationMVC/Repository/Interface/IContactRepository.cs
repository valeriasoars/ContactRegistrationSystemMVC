using ContactRegistrationMVC.Models;

namespace ContactRegistrationMVC.Repository.Interface
{
    public interface IContactRepository
    {

        List<ContactModel> SearchAllRecords();
        ContactModel ToAdd(ContactModel contact);

        
    }
}
