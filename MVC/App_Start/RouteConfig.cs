using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace networkProj
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "login page",
                url: "Pages/login",
                defaults: new { controller = "Pages", action = "login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "register page",
                url: "User/regUser",
                defaults: new { controller = "User", action = "regUser", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "product list page",
                url: "Pages/productsList",
                defaults: new { controller = "Pages", action = "productsList", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "main page",
                url: "",
                defaults: new { controller = "Pages", action = "mainPage", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
