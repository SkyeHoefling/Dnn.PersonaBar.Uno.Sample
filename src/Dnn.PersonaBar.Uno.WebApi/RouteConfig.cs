using System.Web.Http;
using DotNetNuke.Web.Api;

namespace Dnn.PersonaBar.Uno.WebApi
{
    public class RouteConfig : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            // this properly resolves - http://localhost:8012/DesktopModules/UnoSample/API/Wasm/package_62c5d6b8fb8db29389b26a650f0085c3c6c7a6ef/uno-bootstrap
            // it does not resolve - http://localhost:8012/DesktopModules/UnoSample/API/Wasm/package_62c5d6b8fb8db29389b26a650f0085c3c6c7a6ef/uno-bootstrap.css
            // maybe we use a URL rewrite like in this blog - https://weblog.west-wind.com/posts/2015/Nov/13/Serving-URLs-with-File-Extensions-in-an-ASPNET-MVC-Application
            mapRouteManager.MapHttpRoute(
                "UnoSample",
                "clientResources",
                "Wasm/package_{packageId}/{file}",
                new { controller = "wasm", action = "clientresource" },
                new[] { "Dnn.PersonaBar.Uno.WebApi.Controllers" });

            mapRouteManager.MapHttpRoute(
                "UnoSample",
                "default",
                "{controller}/{action}",
                new[] { "Dnn.PersonaBar.Uno.WebApi.Controllers" });

            //mapRouteManager.MapHttpRoute(
            //    "UnoSample",
            //    "default",
            //    "{controller}/package_{packageId}/{file}",
            //    new { Controller = "Wasm", Action = "ClientFile" },
            //    new[] { "Dnn.PersonaBar.Uno.WebApi.Controllers" });
        }
    }
}
