using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cache.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [OutputCache(Duration =10)]
        public ActionResult Index()
        {
            return View();
        }
    }
}