using Newtonsoft.Json;

namespace GhostLyzer.Module.GhostApi.Models
{
    /// <summary>
    /// Response representing offers
    /// </summary>
    public class OfferResponse
    {
        /// <summary>
        /// Represents your publication's offers (discounts or special prices) assigned to particular tiers.
        /// </summary>
        [JsonProperty("offers")]
        public List<Offer> Offers { get; set; }
    }
}
