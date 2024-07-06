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
            try
            {
                bool deleted = _contactRepository.Delete(id);
                if (deleted)
                {
                    TempData["SuccessMessage"] = "Contato apagado com sucesso";
                }
                else
                {
                    TempData["ErrorMessage"] = "Não conseguimos apagar seu contato";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["ErrorMessage"] = $"Não conseguimos apagar seu contato, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult CreateContact(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.ToAdd(contact);
                    TempData["SuccessMessage"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch (System.Exception erro)
            {
                TempData["ErrorMessage"] = $"Não conseguimos cadastrar seu contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult UpdateContact(ContactModel contact)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.ToUpdate(contact);
                    TempData["SuccessMessage"] = "Contato atualizado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("EditContact", contact);
            }
            catch (System.Exception erro)
            {
                TempData["ErrorMessage"] = $"Não conseguimos atualizar seu contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
