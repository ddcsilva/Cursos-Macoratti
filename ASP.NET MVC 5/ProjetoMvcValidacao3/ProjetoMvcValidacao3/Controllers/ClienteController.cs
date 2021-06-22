using ProjetoMvcValidacao3.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoMvcValidacao3.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Index()
        {
            Cliente cliente = new Cliente();
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Index(Cliente cliente)
        {
            // A validação falhou?
            if (!ModelState.IsValid)
            {
                // Sim, falhou
                return View(cliente);
            }
            else
            {
                // Não, está tudo certo
                return View("Validacao", cliente);
            }
        }

        public ActionResult Validacao(Cliente cliente)
        {
            return View(cliente);
        }

        public ActionResult ValidaEmailDisponivel(string email)
        {
            var listaDeEmails = new List<string>
            {
                "danilo.silva@msn.com",
                "teste@teste.com",
                "raquel@gmail.com"
            };

            return Json(listaDeEmails.All(e => e.ToString().ToLower() != email), JsonRequestBehavior.AllowGet);
        }
    }
}