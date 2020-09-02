using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using Dnn.PersonaBar.Library;
using Dnn.PersonaBar.Library.Attributes;
using DotNetNuke.Web.Api;

namespace Dnn.PersonaBar.Uno.WebApi.Controllers
{
    /// <summary>
    /// The WasmController is used to securely deliver the
    /// WASM site that is being hosted as static content
    /// inside the persona bar module. All of the files will
    /// only be delievered to the user if they have host
    /// access.
    ///
    /// If this controller isn't used, the Uno Platform App
    /// would be available to anyone that knows the direct
    /// URL to the index.html. This controller prevents
    /// security attacks by leveraging DNN's security system.
    /// </summary>
    [MenuPermission(Scope = ServiceScope.Host)]
    public class WasmController : PersonaBarApiController
    {
        const string WasmPath = "~/DesktopModules/Admin/Dnn.PersonaBar/Modules/Dnn.UnoSample/dist";
        const string IndexFile = "index.html";

        public WasmController()
        {
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        [RequireHost]
        public HttpResponseMessage Html()
        {
            var rawHtml = string.Empty;
            var path = HttpContext.Current.Server.MapPath($"{WasmPath}/{IndexFile}");
            using (var fileStream = File.OpenRead(path))
            using (var streamReader = new StreamReader(fileStream))
            {
                rawHtml = streamReader.ReadToEnd();
            }

            var content = new StringContent(rawHtml, Encoding.UTF8, "text/html");
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = content };
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        //[RequireHost]
        [AllowAnonymous]
        public HttpResponseMessage ClientResource(string packageId, string file, string extension)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        [RequireHost]
        public HttpResponseMessage Stylesheet(string path)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
