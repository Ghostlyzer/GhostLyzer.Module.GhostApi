using Newtonsoft.Json;

namespace GhostLyzer.Module.GhostApi.Models
{
    public class ThemeImageSizeWidth
    {
        /// <summary>
        /// Width
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }
    }
}
