using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestFiltresDAction
{
    public class MyAuthorize : AuthorizeAttribute
    {
        public virtual string MasterName { get; set; }
        public virtual string ViewName { get; set; } = "Error";
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
            else
            {
                ViewDataDictionary viewData = new ViewDataDictionary();
                viewData.Add("Message", "You do not have sufficient privileges for this operation");
                filterContext.Result = new ViewResult { MasterName = this.MasterName, ViewName = this.ViewName, ViewData = viewData };
            }
        }
    }
}