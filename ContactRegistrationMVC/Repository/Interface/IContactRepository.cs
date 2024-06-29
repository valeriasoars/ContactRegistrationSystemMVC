using ContactRegistrationMVC.Models;

namespace ContactRegistrationMVC.Repository.Interface
{
    public interface IContactRepository
    {
        ContactModel Adiconar(ContactModel contact);
    }
}
