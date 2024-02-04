using GhostLyzer.Module.GhostApi.Attributes;
using Newtonsoft.Json;

namespace GhostLyzer.Module.GhostApi.Models
{
    /// <summary>
    /// Request sent to Ghost
    /// </summary>
    public class OfferRequest
    {
        /// <summary>
        /// Represents your publication's offers (discounts or special prices) assigned to particular tiers.
        /// </summary>
        [Updateable]
        [JsonProperty("offers")]
        public List<Offer> Offers { get; set; }
    }
}
