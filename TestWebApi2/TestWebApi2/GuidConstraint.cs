
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
namespace GestionClients
{
        public class GuidConstraint : IRouteConstraint
        {
            bool IRouteConstraint.Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
            {
                Guid MyGuid;
                return Guid.TryParse(values[parameterName].ToString(), out MyGuid);
            }
        }
    
}