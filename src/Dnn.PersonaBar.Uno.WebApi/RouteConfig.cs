using DotNetNuke.Web.Api;

namespace Dnn.PersonaBar.Uno.WebApi
{
    public class RouteConfig : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute(
                "personabar/UnoSample",
                "default",
                "{controller}/{action}",
                new[] { "Dnn.PersonaBar.Uno.WebApi.Controllers" });
        }
    }
}
