using ContactRegistrationMVC.Models;
using ContactRegistrationMVC.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ContactRegistrationMVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository) 
        {
            _contactRepository = contactRepository;
        }
        public IActionResult Index()
        {
           List<ContactModel> contacts =  _contactRepository.SearchAllRecords();
            return View(contacts);
        }

        public IActionResult CreateContact()
        {
            return View();
        }

        public IActionResult EditContact()
        {
            return View();
        }

        public IActionResult ConfirmationDeleteContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateContact(ContactModel contact)
        {
            _contactRepository.ToAdd(contact);
            return RedirectToAction("Index");
        }
    }
}
