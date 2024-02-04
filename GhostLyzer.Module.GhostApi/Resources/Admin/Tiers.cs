using GhostLyzer.Module.GhostApi.ContractResolvers;
using GhostLyzer.Module.GhostApi.Models;
using GhostLyzer.Module.GhostApi.QueryParams;
using Newtonsoft.Json;
using RestSharp;

namespace GhostLyzer.Module.GhostApi.Services
{
    public partial class GhostAdminAPI
    {
        /// <summary>
        /// Get all tiers
        /// </summary>
        /// <returns>Returns all available tiers</returns>
        /// <seealso cref="https://ghost.org/docs/content-api/#usage"/>
        public new TierResponse GetTiers(TierQueryParams queryParams = null)
        {
            return base.GetTiers(queryParams);
        }

        /// <summary>
        /// Get all tiers asynchronously.
        /// </summary>
        /// <returns>Returns all available tiers</returns>
        /// <seealso cref="https://ghost.org/docs/content-api/#usage"/>
        public new async Task<TierResponse> GetTiersAsync(TierQueryParams queryParams = null)
        {
            return await base.GetTiersAsync(queryParams);
        }

        /// <summary>
        /// Prepares a RestRequest for creating a tier.
        /// </summary>
        /// <param name="tier">The tier to create.</param>
        /// <returns>A RestRequest that can be used to create the tier.</returns>
        private RestRequest PrepareTierCreateRequest(Tier tier)
        {
            var request = CreateRequest(Method.Post, "tiers");
            request.AddJsonBody(new TierRequest { Tiers = new List<Tier> { tier } });
            return request;
        }

        /// <summary>
        /// Creates a tier.
        /// </summary>
        /// <param name="tier">The tier to create.</param>
        /// <returns>Returns the created tier.</returns>
        public Tier CreateTier(Tier tier)
        {
            var request = PrepareTierCreateRequest(tier);
            return Execute<TierRequest>(request).Tiers[0];
        }

        /// <summary>
        /// Creates a tier asynchronously.
        /// </summary>
        /// <param name="tier">The tier to create.</param>
        /// <returns>Returns the created tier.</returns>
        public async Task<Tier> CreateTierAsync(Tier tier)
        {
            var request = PrepareTierCreateRequest(tier);
            var response = await ExecuteAsync<TierRequest>(request);
            return response.Tiers[0];
        }

        /// <summary>
        /// Prepares a RestRequest for updating a tier.
        /// </summary>
        /// <param name="tier">The tier to update.</param>
        /// <returns>A RestRequest that can be used to update the tier.</returns>
        private RestRequest PrepareTierUpdateRequest(Tier tier)
        {
            var serializedTier = JsonConvert.SerializeObject(
                new TierRequest { Tiers = new List<Tier> { tier } },
                new JsonSerializerSettings { ContractResolver = UpdateTierContractResolver.Instance }
            );

            var request = CreateRequest(Method.Post, "tiers", tier.ID);
            request.AddJsonBody(serializedTier);
            return request;
        }

        /// <summary>
        /// Updates a tier.
        /// </summary>
        /// <param name="tier">The tier to update.</param>
        /// <returns>Returns the updated tier.</returns>
        public Tier UpdateTier(Tier tier)
        {
            var request = PrepareTierUpdateRequest(tier);
            return Execute<TierRequest>(request).Tiers[0];
        }

        /// <summary>
        /// Updates a tier asynchronously.
        /// </summary>
        /// <param name="tier">The tier to update.</param>
        /// <returns>Returns the updated tier.</returns>
        public async Task<Tier> UpdateTierAsync(Tier tier)
        {
            var request = PrepareTierUpdateRequest(tier);
            var response = await ExecuteAsync<TierRequest>(request);
            return response.Tiers[0];
        }
    }
}
