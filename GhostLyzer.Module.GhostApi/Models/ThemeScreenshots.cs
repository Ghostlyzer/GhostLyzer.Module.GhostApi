using Newtonsoft.Json;

namespace GhostLyzer.Module.GhostApi.Models
{
    public class ThemeScreenshots
    {
        /// <summary>
        /// Desktop Screenshot
        /// </summary>
        [JsonProperty("desktop")]
        public string Desktop { get; set; }

        /// <summary>
        /// Mobile Screenshot
        /// </summary>
        [JsonProperty("mobile")]
        public string Mobile { get; set; }
    }
}
