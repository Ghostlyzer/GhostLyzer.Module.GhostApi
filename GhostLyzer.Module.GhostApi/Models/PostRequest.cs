using GhostLyzer.Module.GhostApi.Attributes;
using Newtonsoft.Json;

namespace GhostLyzer.Module.GhostApi.Models
{
    /// <summary>
    /// Request sent to Ghost
    /// </summary>
    public class PostRequest
    {
        /// <summary>
        /// Collection of posts.
        /// </summary>
        [JsonProperty("posts")]
        [RequiredForUpdate]
        public List<Post> Posts { get; set; }
    }
}
