using Newtonsoft.Json;

namespace Dnn.PersonaBar.Uno.WebApi.Models
{
    [JsonObject]
    public class Setting
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
