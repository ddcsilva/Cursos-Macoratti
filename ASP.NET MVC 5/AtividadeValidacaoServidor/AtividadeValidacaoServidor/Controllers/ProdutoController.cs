using AtividadeValidacaoServidor.Models;
using System.Web.Mvc;

namespace AtividadeValidacaoServidor.Controllers
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
            if (string.IsNullOrEmpty(produto.Nome))
                ModelState.AddModelError("Nome", "O nome é obrigatório!");

            if (string.IsNullOrEmpty(produto.Descricao))
                ModelState.AddModelError("Descricao", "A descrição é obrigatória!");

            if (produto.Estoque <= 0 || produto.Estoque >= 10)
                ModelState.AddModelError("Estoque", "O estoque deve estar entre 1 e 10");

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