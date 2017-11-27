using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TestFiltresDAction.Controllers
{
    [MyAuthorize(Roles="admin")]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string ReturnUrl)
        {
            if(ReturnUrl == null)
            {
                ReturnUrl = FormsAuthentication.DefaultUrl;
            }
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Models.Identite idt)
        {
            if (Membership.ValidateUser(idt.Identifiant, idt.Password))
            {
                FormsAuthentication.SetAuthCookie(idt.Identifiant, false);//enregistrement
                return new RedirectResult(idt.Redirection);
            }
            if (FormsAuthentication.Authenticate(idt.Identifiant, idt.Password))
            {
                FormsAuthentication.SetAuthCookie(idt.Identifiant, false);
                return new RedirectResult(idt.Redirection);
            }
            ViewBag.ReturnUrl = idt.Redirection;
            return View();
        }

        public ActionResult privateEnv()
        {
            return View();
        }
    }
}