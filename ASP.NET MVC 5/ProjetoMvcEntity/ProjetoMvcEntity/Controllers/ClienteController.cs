using ProjetoMvcEntity.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoMvcEntity.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Index(int tipoId)
        {
            using (ClienteContext clienteContext = new ClienteContext())
            {
                List<Cliente> clientes = clienteContext.Clientes.Where(c => c.TipoId == tipoId).ToList();
                return View(clientes);
            }
        }

        public ActionResult Detalhes(int id)
        {
            using (ClienteContext clienteContext = new ClienteContext())
            {
                Cliente cliente = clienteContext.Clientes.Single(c => c.ClienteId == id);
                return View(cliente);
            }
        }
    }
}