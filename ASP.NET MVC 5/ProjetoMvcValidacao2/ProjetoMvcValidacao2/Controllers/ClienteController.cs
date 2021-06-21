using ProjetoMvcValidacao2.Models;
using System.Web.Mvc;

namespace ProjetoMvcValidacao2.Controllers
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
            // Validação do lado do servidor
            if (string.IsNullOrEmpty(cliente.Nome))
                ModelState.AddModelError("Nome", "O nome é obrigatório");

            if (string.IsNullOrEmpty(cliente.Email))
                ModelState.AddModelError("Email", "O email é obrigatório");

            if (string.IsNullOrEmpty(cliente.Telefone))
                ModelState.AddModelError("Telefone", "O telefone é obrigatório");

            if (cliente.Idade == 0)
            {
                ModelState.AddModelError("Idade", "A idade é obrigatória");
            }
            else
            {
                if (cliente.Idade <= 21)
                {
                    ModelState.AddModelError("Idade", "A idade informada tem que ser maior que 21 anos");
                }
            }

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