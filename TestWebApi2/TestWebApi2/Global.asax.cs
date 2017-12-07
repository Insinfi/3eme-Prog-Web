using GestionClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace TestWebApi2
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            Application["toto"] = "test";
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
