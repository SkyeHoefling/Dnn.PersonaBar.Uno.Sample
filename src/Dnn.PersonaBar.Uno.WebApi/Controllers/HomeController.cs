using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dnn.PersonaBar.Library;
using Dnn.PersonaBar.Library.Attributes;
using Dnn.PersonaBar.Uno.WebApi.Models;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Web.Api;

namespace Dnn.PersonaBar.Uno.WebApi.Controllers
{
    [MenuPermission(Scope = ServiceScope.Host)]
    public class HomeController : PersonaBarApiController
    {
        const string UnoSampleSetting = "UnoSample.Setting";

        [HttpGet]
        [RequireHost]
        [ValidateAntiForgeryToken]
        public HttpResponseMessage Get()
        {
            var portalSettings = PortalController.Instance.GetPortalSettings(PortalId);
            if (portalSettings.ContainsKey(UnoSampleSetting))
                return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(portalSettings[UnoSampleSetting]) };

            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("") };
        }

        [HttpPost]
        [RequireHost]
        [ValidateAntiForgeryToken]
        public HttpResponseMessage Update(Setting setting)
        {
            if (setting == null)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            PortalController.Instance.UpdatePortalSetting(PortalId, UnoSampleSetting, setting.Value, true, "", false);
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(setting.Value) };
        }
    }
}
