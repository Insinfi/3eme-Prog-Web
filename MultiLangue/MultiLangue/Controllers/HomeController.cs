using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MultiLangue.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private string CurrentLang { get; set; }
        protected override void Initialize(RequestContext requestContext)
        {
            this.CurrentLang = string.Empty;
            if (requestContext.RouteData.Values["lang"] != null)
            {
                string lang = requestContext.RouteData.Values["lang"].ToString();
                if (lang != null)
                {
                    CurrentLang = lang;
                    System.Globalization.CultureInfo cult = new System.Globalization.CultureInfo(lang);
                    Thread.CurrentThread.CurrentUICulture = cult;
                    Thread.CurrentThread.CurrentCulture = cult;
                }
                else
                {
                    throw new Exception("Langue non supporté");
                }
            }
            else
            {

                string[] Langs = requestContext.HttpContext.Request.UserLanguages;
                if (Langs.Length > 0)
                {
                    CultureInfo CultInf = new CultureInfo(Langs[0]);
                    string lang = CultInf.TwoLetterISOLanguageName;
                    CurrentLang = lang;
                    System.Globalization.CultureInfo cult = new System.Globalization.CultureInfo(lang);
                    Thread.CurrentThread.CurrentUICulture = cult;
                    Thread.CurrentThread.CurrentCulture = cult;
                }
            }
            base.Initialize(requestContext);
        }
        [LangageAttributes("en")]
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult ShowPerson()
        {
            return ShowPerson();
        }

    }
}