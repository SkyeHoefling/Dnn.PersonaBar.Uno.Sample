using Newtonsoft.Json;

namespace Dnn.PersonaBar.Uno.Shared.Models
{
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
