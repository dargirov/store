namespace OnlineStore.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Products",
                url: "Product/{acronym}",
                defaults: new { controller = "Product", action = "Index" });

            routes.MapRoute(
                name: "Collections",
                url: "Collection/{acronym}",
                defaults: new { controller = "Collection", action = "Index" },
                namespaces: new[] { "OnlineStore.Web.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
