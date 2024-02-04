using GhostLyzer.Module.GhostApi.Attributes;
using Newtonsoft.Json;

namespace GhostLyzer.Module.GhostApi.Models
{
    /// <summary>
    /// Request sent to Ghost
    /// </summary>
    public class PageRequest
    {
        /// <summary>
        /// Collection of pages.
        /// </summary>
        [JsonProperty("pages")]
        [RequiredForUpdate]
        public List<Post> Pages { get; set; }
    }
}
