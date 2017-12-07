using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GestionClients
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{token}/{userhash}/{id}",
                defaults: new { id = RouteParameter.Optional },
                //constraints: new { token = @"[a-f0-9-]+" }
                constraints: new { token = new GuidConstraint() }
            );

            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "api/{controller}/{action}"
            );
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}