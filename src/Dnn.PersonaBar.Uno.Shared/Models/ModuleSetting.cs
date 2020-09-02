using Newtonsoft.Json;

namespace Dnn.PersonaBar.Uno.Shared.Models
{
    [JsonObject]
    public class ModuleSetting
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
