using Newtonsoft.Json;

namespace GhostLyzer.Module.GhostApi.Models
{
    /// <summary>
    /// Response representing basic information about a site.
    /// </summary>
    public class SiteResponse
    {
        /// <summary>
        /// Basic information about a site
        /// </summary>
        [JsonProperty("site")]
        public Site Site { get; set; }
    }
}
