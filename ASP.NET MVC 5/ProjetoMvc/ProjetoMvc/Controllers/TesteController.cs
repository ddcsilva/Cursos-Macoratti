using System.Web.Mvc;

namespace ProjetoMvc.Controllers
{
    public class TesteController : Controller
    {
        // GET: Teste
        public string Index()
        {
            return "Retornando pelo controlador TesteController";
        }
    }
}