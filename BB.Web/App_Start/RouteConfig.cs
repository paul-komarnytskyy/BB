using System.Web.Mvc;
using System.Web.Routing;

namespace BB.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{*urls}");
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{*url}",
            //    defaults: new { controller = "Home", action = "Index" }
            //);
        }
    }
}
