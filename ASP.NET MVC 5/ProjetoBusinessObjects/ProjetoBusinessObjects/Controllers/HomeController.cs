using Business;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoBusinessObjects.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AlunoBusiness aluno = new AlunoBusiness();

            List<Aluno> alunos = aluno.getAlunos().ToList();

            return View(alunos);
        }

        public ActionResult ListaAlunos()
        {
            AlunoBusiness aluno = new AlunoBusiness();

            List<Aluno> alunos = aluno.getAlunos().ToList();

            return View(alunos);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                AlunoBusiness alunoBusiness = new AlunoBusiness();
                alunoBusiness.IncluirAluno(aluno);

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            AlunoBusiness alunoBusiness = new AlunoBusiness();
            Aluno aluno = alunoBusiness.getAlunos().Single(x => x.Id == id);

            return View(aluno);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "Nome")]Aluno aluno)
        {
            AlunoBusiness alunoBusiness = new AlunoBusiness();
            aluno.Nome = alunoBusiness.getAlunos().Single(x => x.Id == aluno.Id).Nome;

            if (ModelState.IsValid)
            {
                alunoBusiness.AtualizarAluno(aluno);
                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        public ActionResult Delete(int id)
        {
            AlunoBusiness alunoBusiness = new AlunoBusiness();
            Aluno aluno = alunoBusiness.getAlunos().Single(x => x.Id == id);
            return View(aluno);
        }

        [HttpPost]
        public ActionResult Delete(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                AlunoBusiness alunoBusiness = new AlunoBusiness();
                alunoBusiness.ExcluirAluno(aluno.Id);
                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        public ActionResult Details(int id)
        {
            AlunoBusiness alunobll = new AlunoBusiness();
            Aluno aluno = alunobll.getAlunos().Single(x => x.Id == id);
            return View(aluno);
        }

        public ActionResult Procurar(string procurarPor, string criterio)
        {
            AlunoBusiness alunoBusiness = new AlunoBusiness();
            if (procurarPor == "Email")
            {
                Aluno aluno = alunoBusiness.getAlunos().SingleOrDefault(x => x.Email == criterio || criterio == null);
                return View(aluno);
            }
            else
            {
                Aluno aluno = alunoBusiness.getAlunos().SingleOrDefault(x => x.Nome == criterio || criterio == null);
                return View(aluno);
            }
        }
    }
}