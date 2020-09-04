using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dnn.PersonaBar.Library;
using Dnn.PersonaBar.Library.Attributes;
using DotNetNuke.Web.Api;

namespace Dnn.PersonaBar.Uno.WebApi.Controllers
{
    [MenuPermission(Scope = ServiceScope.Host)]
    public class AuthorizeController : PersonaBarApiController
    {
        [HttpGet]
        [RequireHost]
        [ValidateAntiForgeryToken]
        public HttpResponseMessage Authorize()
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
