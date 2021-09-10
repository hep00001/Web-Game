using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Product Detail",
               url: "chi-tiet/{metatitle}-{id}",
               defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional }, namespaces: new[] { "Shop.Controllers" }
           );
            routes.MapRoute(
               name: "Add Cart",
               url: "them-gio-hang",
               defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional }, namespaces: new[] { "Shop.Controllers" }
           );
            routes.MapRoute(
              name: "Cart",
              url: "gio-hang",
              defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "Shop.Controllers" }
          );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "Shop.Controllers" }
            );

        }
    }
}
