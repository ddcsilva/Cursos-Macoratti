using ProjetoMvcValidacao.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoMvcValidacao.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Index()
        {
            var cliente = new Cliente();
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Index(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                return View("Validacao", cliente);
            }
            else
            {
                return View(cliente);
            }
        }

        public ActionResult Validacao(Cliente cliente)
        {
            return View(cliente);
        }

        public ActionResult ValidaEmailDisponivel(string email)
        {
            var baseDeEmails = new List<string>
            {
                "macoratti@yahoo.com",
                "teste@teste.com.br",
                "janjan@bol.com.br"
            };

            // Se o email não existir na lista então retorna true, senão false
            return Json(baseDeEmails.All(e => e.ToString().ToLower() != email), JsonRequestBehavior.AllowGet);

        }
    }
}