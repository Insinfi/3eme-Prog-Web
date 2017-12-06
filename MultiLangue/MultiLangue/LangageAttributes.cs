using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiLangue
{
    public class LangageAttributes: ActionFilterAttribute
    {
        private string Lang;
        public LangageAttributes(string Lang)
        {
            this.Lang = Lang;
        }
        public override void OnActionExecuted(ActionExecutedContext filterConrext)
        {
            base.OnActionExecuted(filterConrext);
        }
    }
}