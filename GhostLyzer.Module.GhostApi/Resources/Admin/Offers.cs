using GhostLyzer.Module.GhostApi.ContractResolvers;
using GhostLyzer.Module.GhostApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;

namespace GhostLyzer.Module.GhostApi.Services
{
    public partial class GhostAdminAPI
    {
        /// <summary>
        /// Get all offers
        /// </summary>
        /// <returns>Returns all available offers</returns>
        /// <seealso cref="https://ghost.org/docs/admin-api/#offers"/>
        public OfferResponse GetOffers()
        {
            var request = CreateRequest("offers", Method.Get);
            return Execute<OfferResponse>(request);
        }

        /// <summary>
        /// Create an offer
        /// </summary>
        /// <param name="offer">offer to create</param>
        /// <returns>Returns the created offer</returns>
        /// <seealso cref="https://ghost.org/docs/admin-api/#creating-an-offer"/>
        public Offer CreateOffer(Offer offer)
        {
            var request = CreateOfferRequest(offer, Method.Post);
            return Execute<OfferRequest>(request).Offers[0];
        }

        /// <summary>
        /// Update an offer
        /// (only Name, Code, DisplayTitle and DisplayDescription are editable)
        /// </summary>
        /// <param name="offer">Tier to update</param>
        /// <returns>Returns the updated tier</returns>
        /// <seealso cref="https://ghost.org/docs/admin-api/#updating-an-offer"/>
        public Offer UpdateOffer(Offer offer)
        {
            var request = CreateOfferRequest(offer, Method.Put, offer.ID);
            return Execute<OfferRequest>(request).Offers[0];
        }

        /// <summary>
        /// Creates a new RestRequest for an offer.
        /// </summary>
        /// <param name="offer">The offer.</param>
        /// <param name="method">The HTTP method.</param>
        /// <param name="id">The optional id parameter.</param>
        /// <returns>The created RestRequest.</returns>
        private RestRequest CreateOfferRequest(Offer offer, Method method, string id = null)
        {
            var serializedOffer = JsonConvert.SerializeObject(
               new OfferRequest { Offers = new List<Offer> { offer } },
               new JsonSerializerSettings { ContractResolver = GetContractResolver(method) }
            );

            var request = CreateRequest("offers", method, id);
            request.AddJsonBody(serializedOffer);
            return request;
        }


        /// <summary>
        /// Gets the appropriate ContractResolver based on the HTTP method.
        /// </summary>
        /// <param name="method">The HTTP method.</param>
        /// <returns>The appropriate ContractResolver.</returns>
        private IContractResolver GetContractResolver(Method method)
        {
            return method == Method.Post ? CreateOfferContractResolver.Instance : UpdateOfferContractResolver.Instance;
        }
    }
}
