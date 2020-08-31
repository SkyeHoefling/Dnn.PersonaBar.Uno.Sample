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
            var credentials = JsonConvert.DeserializeObject<Credentials>(json);

            TabId = credentials.TabId;
            RequestVerificationToken = credentials.RequestVerificationToken;
#else
            TabId = -1;
            RequestVerificationToken = "INVALID TOKEN";
#endif
        }

        public int TabId { get; }
        public string RequestVerificationToken { get; }
    }

    [JsonObject]
    public class Credentials
    {
        [JsonProperty("tabId")]
        public int TabId { get; set; }

        [JsonProperty("requestVerificationToken")]
        public string RequestVerificationToken { get; set; }
    }
}
