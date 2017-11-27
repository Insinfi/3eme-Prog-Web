using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterPage.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DataClasses1DataContext mycontext = new DataClasses1DataContext();
            var Articles = mycontext.GetAllArticle().ToList<GetAllArticleResult>();
            return View(Articles);
        }


        public ActionResult ArticleItem(string id)
        {
            DataClasses1DataContext mycontext = new DataClasses1DataContext();
            var Article = mycontext.GetArticle(id);
            return PartialView(Article);
        }
    }
}