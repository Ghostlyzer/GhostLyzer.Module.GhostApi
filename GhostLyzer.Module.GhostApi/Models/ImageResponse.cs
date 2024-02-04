using Newtonsoft.Json;

namespace GhostLyzer.Module.GhostApi.Models
{
    /// <summary>
    /// Response representing an image
    /// </summary>
    public class ImageResponse
    {
        /// <summary>
        /// List of images
        /// </summary>
        [JsonProperty("images")]
        public List<Image> Images { get; set; }
    }
}
