using ContactList.Models;
using ContactList.Repository;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom;

namespace ContactList.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;
        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }
        public IActionResult Index()
        {
            List<ContactModel> contatos = _contatoRepository.GetAll();
            return View(contatos);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            ContactModel contato = _contatoRepository.GetById(id);
            return View(contato);
        }

        public IActionResult DeleteConfirm(int id)
        {
            ContactModel contato = _contatoRepository.GetById(id);
            return View(contato);
        }

        public IActionResult Delete(int id)
        {

            try
            {
                bool isDeleted = _contatoRepository.Delete(id);

                if (isDeleted)
                {
                    TempData["SuccessMessage"] = "Contato apagado com sucesso.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Falha ao excluir contato.";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Falha ao excluir contato. {ex}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Create(ContactModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Add(contato);
                    TempData["SuccessMessage"] = "Contato cadastrado com sucesso.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Falha ao cadastrar contato. {ex}";
                return RedirectToAction("Index");
            }

            return View(contato);
        }

        [HttpPost]
        public IActionResult Update(ContactModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Update(contato);
                    TempData["SuccessMessage"] = "Contato atualizado com sucesso.";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Falha ao atualizar contato. {ex}";
                return RedirectToAction("Index");
            }

            return View(contato);
        }

      
    }
}
