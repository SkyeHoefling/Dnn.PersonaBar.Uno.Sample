using DotNetNuke.Web.Api;

namespace Dnn.PersonaBar.Uno.WebApi
{
    public class RouteConfig : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute(
                "personabar/UnoSample",
                "authorize-routes",
                "Authorize",
                new { controller = "authorize", action = "authorize" },
                new[] { "Dnn.PersonaBar.Uno.WebApi.Controller" });

            mapRouteManager.MapHttpRoute(
                "personabar/UnoSample",
                "default",
                "{controller}/{action}",
                new[] { "Dnn.PersonaBar.Uno.WebApi.Controllers" });
        }
    }
}
