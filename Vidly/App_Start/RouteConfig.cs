using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // MapRoute(this RouteCollection routes, string name, string url, object defaults, object constraints);
            //routes.MapRoute("FilmesPorDataLancamento",
            //                "Filmes/PorDataLancamento/{ano}/{mes}"
            //                ,new { controller = "Filmes", action = "PorDataLancamento"}
            //                //,new { ano = @"2015|2016", mes = @"\d{2}" }
            //                , new { ano = @"\d{4}", mes = @"\d{2}" }
            //                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
