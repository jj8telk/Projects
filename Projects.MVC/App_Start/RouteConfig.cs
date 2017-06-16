using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Projects.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Project",
                url: "Project/{id}",
                defaults: new { controller = "Project", action = "Index" }
            );

            routes.MapRoute(
                name: "ProjectSVN",
                url: "ProjectSVN/{id}",
                defaults: new { controller = "ProjectSVN", action = "Index" }
            );

            routes.MapRoute(
                name: "ProjectItem",
                url: "ProjectItem/{id}",
                defaults: new { controller = "ProjectItem", action = "Index" }
            );

            routes.MapRoute(
                name: "Item",
                url: "Item/{id}",
                defaults: new { controller = "Item", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
