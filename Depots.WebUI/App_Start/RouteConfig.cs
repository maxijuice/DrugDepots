using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Depots.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "OrderDefault",
                url: "order",
                defaults: new { controller = "Order", action = "MakeOrder" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) } 
            );

            routes.MapRoute(
                name: "OrderSummaryDefault",
                url: "order/summary",
                defaults: new { controller = "Order", action = "MakeOrder" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "DepotsListDefault",
                url: "depots",
                defaults: new { controller = "Depots", action = "List"}
            );

            routes.MapRoute(
                name: "UnitsListDefault",
                url: "units",
                defaults: new { controller = "DrugUnits", action = "List"}
            );

            routes.MapRoute(
                name: "DepotsList",
                url: "depots/page/{page}",
                defaults: new { controller = "Depots", action = "List", page = UrlParameter.Optional },
                constraints: new { page = @"\d+" }
            );

            routes.MapRoute(
                name: "UnitsList",
                url: "units/page/{page}",
                defaults: new {controller = "DrugUnits", action = "List", page = UrlParameter.Optional},
                constraints: new { page = @"\d+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "DrugUnits", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}
