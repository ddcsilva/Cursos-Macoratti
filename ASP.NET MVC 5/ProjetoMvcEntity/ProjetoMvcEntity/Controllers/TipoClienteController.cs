using ProjetoMvcEntity.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoMvcEntity.Controllers
{
    public class TipoClienteController : Controller
    {
        public ActionResult Index()
        {
            using (ClienteContext clienteContext = new ClienteContext())
            {
                List<Tipo> tiposCliente = clienteContext.Tipos.ToList();
                return View(tiposCliente);
            }
        }
    }
}