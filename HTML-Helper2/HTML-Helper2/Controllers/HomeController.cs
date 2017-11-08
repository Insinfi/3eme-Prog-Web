using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTML_Helper2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Models.Etudiant et1 = new Models.Etudiant { Nom = "Core", Prenom = "Jean-Webchel", Matricule = "LA020202" };
            return View(et1);
        }
    }
}