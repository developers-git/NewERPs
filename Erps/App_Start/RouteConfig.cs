using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Erps
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
       name: "Default",
       url: "{controller}/{action}/{id}",
       defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional }
   );
        }
    }
}