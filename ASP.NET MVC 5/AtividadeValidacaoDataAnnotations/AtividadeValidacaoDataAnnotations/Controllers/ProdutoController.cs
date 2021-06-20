using AtividadeValidacaoDataAnnotations.Models;
using System.Web.Mvc;

namespace AtividadeValidacaoDataAnnotations.Controllers
{
    public class ProdutoController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Produto produto = new Produto();
            return View(produto);
        }

        [HttpPost]
        public ActionResult Index(Produto produto)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Resultado", produto);
            }
            else
            {
                return View(produto);
            }
        }

        public ActionResult Resultado(Produto produto)
        {
            return View(produto);
        }
    }
}