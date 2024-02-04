using GhostLyzer.Module.GhostApi.ContractResolvers;
using GhostLyzer.Module.GhostApi.Models;
using GhostLyzer.Module.GhostApi.QueryParams;
using Newtonsoft.Json;
using RestSharp;

namespace GhostLyzer.Module.GhostApi.Services
{
    public partial class GhostAdminAPI
    {
        #region Read

        /// <summary>
        /// Gets all newsletters.
        /// </summary>
        /// <param name="queryParams">Optional query parameters.</param>
        /// <returns>A response containing all newsletters.</returns>
        public NewsletterResponse GetNewsletters(NewsletterQueryParams queryParams = null)
        {
            var request = PrepareGetNewslettersRequest(queryParams);
            return Execute<NewsletterResponse>(request);
        }

        /// <summary>
        /// Gets all newsletters asynchronously.
        /// </summary>
        /// <param name="queryParams">Optional query parameters.</param>
        /// <returns>A response containing all newsletters.</returns>
        public async Task<NewsletterResponse> GetNewslettersAsync(NewsletterQueryParams queryParams = null)
        {
            var request = PrepareGetNewslettersRequest(queryParams);
            return await ExecuteAsync<NewsletterResponse>(request);
        }

        #endregion

        #region Create

        /// <summary>
        /// Creates a newsletter.
        /// </summary>
        /// <param name="newsletter">The newsletter to create.</param>
        /// <param name="optInExisting">When set to true, existing members with a subscription to one or more active newsletters are also subscribed to this newsletter.</param>
        /// <returns>The created newsletter.</returns>
        public Newsletter CreateNewsletter(Newsletter newsletter, bool optInExisting = false)
        {
            var request = PrepareCreateNewsletterRequest(newsletter, optInExisting);
            return Execute<NewsletterRequest>(request).Newsletters[0];
        }

        /// <summary>
        /// Creates a newsletter asynchronously.
        /// </summary>
        /// <param name="newsletter">The newsletter to create.</param>
        /// <param name="optInExisting">When set to true, existing members with a subscription to one or more active newsletters are also subscribed to this newsletter.</param>
        /// <returns>The created newsletter.</returns>
        public async Task<Newsletter> CreateNewsletterAsync(Newsletter newsletter, bool optInExisting = false)
        {
            var request = PrepareCreateNewsletterRequest(newsletter, optInExisting);
            var response = await ExecuteAsync<NewsletterRequest>(request);
            return response.Newsletters[0];
        }

        #endregion

        #region Update

        /// <summary>
        /// Updates a newsletter.
        /// </summary>
        /// <param name="newsletter">The newsletter to update.</param>
        /// <returns>The updated newsletter.</returns>
        public Newsletter UpdateNewsletter(Newsletter newsletter)
        {
            var request = PrepareUpdateNewsletterRequest(newsletter);
            return Execute<NewsletterRequest>(request).Newsletters[0];
        }

        /// <summary>
        /// Updates a newsletter asynchronously.
        /// </summary>
        /// <param name="newsletter">The newsletter to update.</param>
        /// <returns>The updated newsletter.</returns>
        public async Task<Newsletter> UpdateNewsletterAsync(Newsletter newsletter)
        {
            var request = PrepareUpdateNewsletterRequest(newsletter);
            var response = await ExecuteAsync<NewsletterRequest>(request);
            return response.Newsletters[0];
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Applies any specified parameters to the request.
        /// </summary>
        /// <param name="request">REST request.</param>
        /// <param name="queryParams">Query parameters.</param>
        private static void ApplyNewsletterQueryParams(RestRequest request, NewsletterQueryParams queryParams)
        {
            if (queryParams is { NoLimit: true })
                request.AddQueryParameter(nameof(queryParams.Limit), "all");
            else if (queryParams?.Limit > 0)
                request.AddQueryParameter(nameof(queryParams.Limit), queryParams.Limit.ToString());
        }

        /// <summary>
        /// Prepares a RestRequest for getting all newsletters.
        /// </summary>
        /// <param name="queryParams">Optional query parameters.</param>
        /// <returns>A RestRequest that can be used to get all newsletters.</returns>
        private RestRequest PrepareGetNewslettersRequest(NewsletterQueryParams queryParams = null)
        {
            var request = CreateRequest(Method.Get, "newsletters");
            ApplyNewsletterQueryParams(request, queryParams);
            return request;
        }

        /// <summary>
        /// Prepares a RestRequest for updating a newsletter.
        /// </summary>
        /// <param name="newsletter">The newsletter to update.</param>
        /// <returns>A RestRequest that can be used to update a newsletter.</returns>
        private RestRequest PrepareUpdateNewsletterRequest(Newsletter newsletter)
        {
            var serializedPost = JsonConvert.SerializeObject(
               new NewsletterRequest { Newsletters = new List<Newsletter> { newsletter } },
               new JsonSerializerSettings { ContractResolver = UpdatePostContractResolver.Instance }
            );

            var request = CreateRequest(Method.Put, "newsletters", newsletter.ID);
            request.AddJsonBody(serializedPost);
            return request;
        }

        /// <summary>
        /// Prepares a RestRequest for creating a newsletter.
        /// </summary>
        /// <param name="newsletter">The newsletter to create.</param>
        /// <param name="optInExisting">When set to true, existing members with a subscription to one or more active newsletters are also subscribed to this newsletter.</param>
        /// <returns>A RestRequest that can be used to create a newsletter.</returns>
        private RestRequest PrepareCreateNewsletterRequest(Newsletter newsletter, bool optInExisting = false)
        {
            var request = CreateRequest(Method.Post, "newsletters");
            request.AddJsonBody(new NewsletterRequest { Newsletters = new List<Newsletter> { newsletter } });
            if (optInExisting)
                request.AddQueryParameter(nameof(optInExisting), optInExisting.ToString());
            return request;
        }

        #endregion
    }
}
