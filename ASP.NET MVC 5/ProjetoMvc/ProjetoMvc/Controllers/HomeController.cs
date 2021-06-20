using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjetoMvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //ViewData["Nome"] = "Danilo";
            //ViewData["Email"] = "danilo.silva@msn.com";
            //ViewData["DataInicio"] = new DateTime(2021, 05, 24);

            //ViewBag.Nome = "Danilo";
            //ViewBag.Email = "danilo.silva@msn.com";
            //ViewBag.DataInicio = new DateTime(2021, 05, 24);

            ViewBag.Paises = new List<string>()
            {
                "Brasil",
                "Peru",
                "China",
                "Canada"
            };

            return View();
        }

        public string Inicio()
        {
            return "Minha primeira aplicação ASP.NET MVC";
        }

        public string Saudacao(int id)
        {
            return "Saudações, seu código é: " + id;
        }
    }
}