using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GreenCollaboration
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Account",
               url: "Account/{action}",
               defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "Manage",
              url: "Manage/{action}",
              defaults: new { controller = "Manage", action = "Index", id = UrlParameter.Optional }
          );

            routes.MapRoute(
                name: "Default",
                url: "{*route}",
                defaults: new { controller = "Page", action = "Index", route = UrlParameter.Optional }
            );
        }
    }
}
