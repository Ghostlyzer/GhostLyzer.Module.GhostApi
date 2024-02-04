using Newtonsoft.Json;

namespace GhostLyzer.Module.GhostApi.Models
{
    public class Repository
    {
        /// <summary>
        /// Type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// URL
        /// </summary>
        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
