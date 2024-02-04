using Newtonsoft.Json;

namespace GhostLyzer.Module.GhostApi.Models
{
    public class GhostPackageManager
    {
        /// <summary>
        /// Type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Categories
        /// </summary>
        [JsonProperty("categories")]
        public List<string> Categories { get; set; }
    }
}
