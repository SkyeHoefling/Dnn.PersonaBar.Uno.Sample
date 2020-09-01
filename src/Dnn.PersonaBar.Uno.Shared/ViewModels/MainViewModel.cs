using System;
using Newtonsoft.Json;
using Uno.Foundation;

namespace Dnn.PersonaBar.Uno.Shared.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
#if __WASM__
            var json = WebAssemblyRuntime.InvokeJS("DnnInterop()");
            try
            {
                var settings = JsonConvert.DeserializeObject<PersonaBarSettings>(json);

                IsHost = settings.IsHost;
                IsAdmin = settings.IsAdmin;
                UserId = settings.UserId;
                PortalId = settings.PortalId;
                RequestVerificationToken = settings.RequestVerificationToken;
            }
            catch (Exception) { }
#else
            PortalId = -1;
            RequestVerificationToken = "INVALID TOKEN";
#endif
        }

        public bool IsHost { get; }
        public bool IsAdmin { get; }
        public int UserId { get; }
        public int PortalId { get; }
        public string RequestVerificationToken { get; }
    }

    [JsonObject]
    public class PersonaBarSettings
    {
        [JsonProperty("isHost")]
        public bool IsHost { get; set; }

        [JsonProperty("isAdmin")]
        public bool IsAdmin { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("portalId")]
        public int PortalId { get; set; }

        [JsonProperty("requestVerificationToken")]
        public string RequestVerificationToken { get; set; }
    }
}
