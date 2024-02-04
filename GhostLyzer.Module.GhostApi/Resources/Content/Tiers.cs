using GhostLyzer.Module.GhostApi.Models;
using GhostLyzer.Module.GhostApi.QueryParams;

namespace GhostLyzer.Module.GhostApi.Services
{
    public partial class GhostContentAPI
    {
        /// <summary>
        /// Retrieves tiers synchronously.
        /// </summary>
        /// <param name="queryParams">Optional query parameters.</param>
        /// <returns>The tier response.</returns>
        public new TierResponse GetTiers(TierQueryParams queryParams = null)
        {
            return base.GetTiers(queryParams);
        }

        /// <summary>
        /// Retrieves tiers asynchronously.
        /// </summary>
        /// <param name="queryParams">Optional query parameters.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the tier response.</returns>
        public new async Task<TierResponse> GetTiersAsync(TierQueryParams queryParams = null)
        {
            return await base.GetTiersAsync(queryParams);
        }
    }
}