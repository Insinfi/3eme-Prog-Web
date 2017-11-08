using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTML_Helper_Exo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult validmail( string mail)
        {
            if (mail != "toto@helha.be")
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("L'addresse mail est déjà utilisée", JsonRequestBehavior.AllowGet);
            }
        }
    }
}