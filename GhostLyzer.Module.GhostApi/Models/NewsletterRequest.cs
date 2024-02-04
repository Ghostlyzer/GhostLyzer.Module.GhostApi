using Newtonsoft.Json;

namespace GhostLyzer.Module.GhostApi.Models
{
    /// <summary>
    /// Request sent to Ghost
    /// </summary>
    public class NewsletterRequest
    {
        /// <summary>
        /// Represents your publication's newsletters
        /// </summary>
        [JsonProperty("newsletters")]
        public List<Newsletter> Newsletters { get; set; }
    }
}
