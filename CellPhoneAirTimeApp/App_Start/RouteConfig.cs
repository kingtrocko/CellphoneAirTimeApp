using System.Web.Mvc;
using System.Web.Routing;

namespace CellPhoneAirTimeApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "mysettings",
               url: "mysettings/{*catchall}",
               defaults: new { controller = "Account", action = "MySettings" });

            routes.MapRoute(
               name: "users",
               url: "security/users/{*catchall}",
               defaults: new { controller = "Security", action = "Users" });

            routes.MapRoute(
              name: "privileges",
              url: "security/privileges/{*catchall}",
              defaults: new { controller = "Security", action = "Privileges" });

            routes.MapRoute(
              name: "roles",
              url: "security/roles/{*catchall}",
              defaults: new { controller = "Security", action = "Roles" });

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
