using Newtonsoft.Json;

namespace GhostLyzer.Module.GhostApi.Models
{
    public class ThemeAuthor
    {
        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// URL
        /// </summary>
        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
