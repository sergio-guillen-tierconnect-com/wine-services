using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Wines.Web {
    public class MvcApplication : System.Web.HttpApplication {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /*
                new { httpMethod = new HttpMethodConstraint(new string[] { "PUT" }) }
             */
            routes.MapRoute(
                "UpdatetWine", // Route name
                "api/wines/{wineId}", // URL with parameters
                new { controller = "Wine", action = "Update" },
                new { httpMethod = new HttpMethodConstraint(new string[] { "PUT" }) }
            );
            routes.MapRoute(
                "DeleteWine", // Route name
                "api/wines/{wineId}", // URL with parameters
                new { controller = "Wine", action = "Delete" },
                new { httpMethod = new HttpMethodConstraint(new string[] { "DELETE" }) }
            );
            routes.MapRoute(
                "InsertWine", // Route name
                "api/wines", // URL with parameters
                new { controller = "Wine", action = "Insert" },
                new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );
            routes.MapRoute(
                "GetWines", // Route name
                "api/wines", // URL with parameters
                new { controller = "Wine", action = "Get" },
                new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );
            routes.MapRoute(
                "GetWine", // Route name
                "api/wines/{id}", // URL with parameters
                new { controller = "Wine", action = "GetWine" },
                new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );
        }

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}