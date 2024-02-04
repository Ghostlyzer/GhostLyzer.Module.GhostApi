using GhostLyzer.Module.GhostApi.Attributes;
using Newtonsoft.Json;

namespace GhostLyzer.Module.GhostApi.Models
{
    /// <summary>
    /// Request sent to Ghost
    /// </summary>
    public class TierRequest
    {
        /// <summary>
        /// Collection of tiers.
        /// </summary>
        [JsonProperty("tiers")]
        [RequiredForUpdate]
        public List<Tier> Tiers { get; set; }
    }
}
