using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebProducts
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "IndexByName",
                url: "{controller}/buscarPorNombre/{name}",
                defaults: new { controller = "Product", action = "Index", name = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "IndexByCategory",
                url: "{controller}/buscarPorCategoria/{category}",
                defaults: new { controller = "Product", action = "Index", category = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
