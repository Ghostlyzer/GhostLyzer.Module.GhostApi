using GhostLyzer.Module.GhostApi.Models;
using GhostLyzer.Module.GhostApi.QueryParams;
using RestSharp;

namespace GhostLyzer.Module.GhostApi.Services
{
    public partial class GhostAPI
    {
        /// <summary>
        /// Get all tiers.
        /// </summary>
        /// <returns>Returns all available tiers</returns>
        /// <seealso cref="https://ghost.org/docs/content-api/#usage"/>
        public TierResponse GetTiers(TierQueryParams queryParams = null)
        {
            var request = CreateRequest(Method.Get, "tiers");
            ApplyTierQueryParams(request, queryParams);
            return Execute<TierResponse>(request);
        }

        /// <summary>
        /// Get all tiers asynchronously.
        /// </summary>
        /// <returns>Returns all available tiers</returns>
        /// <seealso cref="https://ghost.org/docs/content-api/#usage"/>
        public async  Task<TierResponse> GetTiersAsync(TierQueryParams queryParams = null)
        {
            var request = CreateRequest(Method.Get, "tiers");
            ApplyTierQueryParams(request, queryParams);
            return await ExecuteAsync<TierResponse>(request);
        }

        /// <summary>
        /// Applies any specified parameters to the post request.
        /// </summary>
        /// <param name="request">A post REST request.</param>
        /// <param name="queryParams">Query parameters.</param>
        private static void ApplyTierQueryParams(RestRequest request, TierQueryParams queryParams)
        {
            if (queryParams != null)
            {
                var includeList = new List<string>();

                if (queryParams.IncludeBenefits)
                    includeList.Add("benefits");
                if (queryParams.IncludeMonthlyPrice)
                    includeList.Add("monthly_price");
                if (queryParams.IncludeYearlyPrice)
                    includeList.Add("yearly_price");

                if (includeList.Any())
                    request.AddQueryParameter("include", string.Join(",", includeList));
            }
        }
    }
}
