using ProjetoMvc.Models;
using System.Web.Mvc;

namespace ProjetoMvc.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detalhes()
        {
            Cliente cliente = new Cliente()
            {
                ClienteId = 200,
                Nome = "Danilo",
                Email = "danilo.silva@msn.com",
                Telefone = "12-99999-8888"
            };

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Salvar(Cliente cliente)
        {
            return View(cliente);
        }
    }
}