using ProjetoMvcValidacao3.Models;
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
    }
}