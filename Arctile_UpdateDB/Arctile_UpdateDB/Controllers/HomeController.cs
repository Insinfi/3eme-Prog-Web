using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Arctile_UpdateDB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            AddArticle();
            return View();
        }

        public ActionResult AddArticle()
        {
            return View("AddArticle");
        }

        public string Preview(HttpPostedFileBase PhotoSelect)
        {
            string filename = string.Empty;
            if (PhotoSelect.ContentLength > 0)
            {
                filename = Path.GetFileName(PhotoSelect.FileName);
                var path = Server.MapPath("/Images/");      //Url
                string FullPath = path + @"\" + filename;   //Chemin
                System.Drawing.Image sourceimage =
                    System.Drawing.Image.FromStream(PhotoSelect.InputStream);
                sourceimage.Save(FullPath);
            }
            return filename;
        }
    }
}