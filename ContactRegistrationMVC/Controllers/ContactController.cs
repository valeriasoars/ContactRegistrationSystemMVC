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

        public IActionResult EditContact(int id)
        {
            ContactModel contact = _contactRepository.ListById(id);
            return View(contact);
        }

        public IActionResult ConfirmationDeleteContact(int id)
        {
            ContactModel contact = _contactRepository.ListById(id);
            return View(contact);
        }

        public IActionResult Delete(int id)
        {
            _contactRepository.Delete(id);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult CreateContact(ContactModel contact)
        {
            if(ModelState.IsValid)
            {
                _contactRepository.ToAdd(contact);
                return RedirectToAction("Index");
            }

            return View(contact);

        }

        [HttpPost]
        public IActionResult UpdateContact(ContactModel contact)
        {

            if(ModelState.IsValid)
            {
                _contactRepository.ToUpdate(contact);
                return RedirectToAction("Index");
            }

            return View("EditContact", contact);
        }
    }
}
