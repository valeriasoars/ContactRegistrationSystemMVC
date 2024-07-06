using ContactRegistrationMVC.Models;

namespace ContactRegistrationMVC.Repository.Interface
{
    public interface IContactRepository
    {
        ContactModel ListById(int id);
        List<ContactModel> SearchAllRecords();
        ContactModel ToAdd(ContactModel contact);
        ContactModel ToUpdate(ContactModel contact);
        bool Delete(int id);



    }
}
