using System.Web.Mvc;
using System.Web.Routing;

namespace FileObmen
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "Files/{sha}",
                new { controller = "Home", action = "ShowFile" });

            routes.MapRoute(null, "{controller}/{action}/{sha}",
                new { controller = "File", action = "Details" });
            
            routes.MapRoute(null, "Share/{sha}",
                new { controller = "File", action = "Share" });

            routes.MapRoute(null, "Edit/{sha}",
                new { controller = "File", action = "EditFile" });

            routes.MapRoute(null, "Download/{sha}",
                new { controller = "File", action = "GetFile" });

            routes.MapRoute(null, "Pass/{sha}",
                new { controller = "File", action = "CheckPassword" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}