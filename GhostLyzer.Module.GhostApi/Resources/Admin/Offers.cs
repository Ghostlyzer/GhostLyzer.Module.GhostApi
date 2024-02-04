using GhostLyzer.Module.GhostApi.ContractResolvers;
using GhostLyzer.Module.GhostApi.Models;
using Newtonsoft.Json;
using RestSharp;

namespace GhostLyzer.Module.GhostApi.Services
{
    public partial class GhostAdminAPI
    {
        #region Get

        /// <summary>
        /// Get all offers
        /// </summary>
        /// <returns>Returns all available offers</returns>
        /// <seealso cref="https://ghost.org/docs/admin-api/#offers"/>
        public OfferResponse GetOffers()
        {
            var request = PrepareGetOffersRequest();
            return Execute<OfferResponse>(request);
        }

        /// <summary>
        /// Get all offers asynchronously
        /// </summary>
        /// <returns>Returns all available offers</returns>
        /// <seealso cref="https://ghost.org/docs/admin-api/#offers"/>
        public async Task<OfferResponse> GetOffersAsync()
        {
            var request = PrepareGetOffersRequest();
            return await ExecuteAsync<OfferResponse>(request);
        }

        #endregion

        #region Create

        /// <summary>
        /// Create an offer
        /// </summary>
        /// <param name="offer">Offer to create</param>
        /// <returns>Returns the created offer</returns>
        /// <seealso cref="https://ghost.org/docs/admin-api/#creating-an-offer"/>
        public Offer CreateOffer(Offer offer)
        {
            var request = PrepareCreateOfferRequest(offer);
            return Execute<OfferRequest>(request).Offers[0];
        }

        /// <summary>
        /// Create an offer asynchronously
        /// </summary>
        /// <param name="offer">Offer to create</param>
        /// <returns>Returns the created offer</returns>
        /// <seealso cref="https://ghost.org/docs/admin-api/#creating-an-offer"/>
        public async Task<Offer> CreateOfferAsync(Offer offer)
        {
            var request = PrepareCreateOfferRequest(offer);
            var response = await ExecuteAsync<OfferRequest>(request);
            return response.Offers[0];
        }

        #endregion

        #region Update

        /// <summary>
        /// Update an offer
        /// (only Name, Code, DisplayTitle and DisplayDescription are editable)
        /// </summary>
        /// <param name="offer">Offer to update</param>
        /// <returns>Returns the updated offer</returns>
        /// <seealso cref="https://ghost.org/docs/admin-api/#updating-an-offer"/>
        public Offer UpdateOffer(Offer offer)
        {
            var request = PrepareUpdateOfferRequest(offer);
            return Execute<OfferRequest>(request).Offers[0];
        }

        /// <summary>
        /// Update an offer asynchronously
        /// (only Name, Code, DisplayTitle and DisplayDescription are editable)
        /// </summary>
        /// <param name="offer">Offer to update</param>
        /// <returns>Returns the updated offer</returns>
        /// <seealso cref="https://ghost.org/docs/admin-api/#updating-an-offer"/>
        public async Task<Offer> UpdateOfferAsync(Offer offer)
        {
            var request = PrepareUpdateOfferRequest(offer);
            var response = await ExecuteAsync<OfferRequest>(request);
            return response.Offers[0];
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Prepares a RestRequest for updating an offer.
        /// </summary>
        /// <param name="offer">The offer to update.</param>
        /// <returns>A RestRequest that can be used to update an offer.</returns>
        private RestRequest PrepareUpdateOfferRequest(Offer offer)
        {
            var serializedOffer = JsonConvert.SerializeObject(
               new OfferRequest { Offers = new List<Offer> { offer } },
               new JsonSerializerSettings { ContractResolver = UpdateOfferContractResolver.Instance }
            );

            var request = CreateRequest(Method.Post, "offers", offer.ID);
            request.AddJsonBody(serializedOffer);
            return request;
        }

        /// <summary>
        /// Prepares a RestRequest for creating an offer.
        /// </summary>
        /// <param name="offer">The offer to create.</param>
        /// <returns>A RestRequest that can be used to create an offer.</returns>
        private RestRequest PrepareCreateOfferRequest(Offer offer)
        {
            var serializedOffer = JsonConvert.SerializeObject(
               new OfferRequest { Offers = new List<Offer> { offer } },
               new JsonSerializerSettings { ContractResolver = CreateOfferContractResolver.Instance }
            );

            var request = CreateRequest(Method.Post, "offers");
            request.AddJsonBody(serializedOffer);
            return request;
        }

        /// <summary>
        /// Prepares a RestRequest for getting all offers.
        /// </summary>
        /// <returns>A RestRequest that can be used to get all offers.</returns>
        private RestRequest PrepareGetOffersRequest()
        {
            return CreateRequest(Method.Get, "offers");
        }

        #endregion
    }
}
