using GhostLyzer.Module.GhostApi.Models;
using GhostLyzer.Module.GhostApi.QueryParams;
using RestSharp;

namespace GhostLyzer.Module.GhostApi.Services
{
    public partial class GhostAPI
    {
        /// <summary>
        /// Gets all pages.
        /// </summary>
        /// <param name="queryParams">Optional query parameters.</param>
        /// <returns>A response containing all pages.</returns>
        public PageResponse GetPages(PostQueryParams queryParams = null)
        {
            var request = CreateRequest(Method.Get, "pages");
            ApplyPageQueryParams(request, queryParams);
            return Execute<PageResponse>(request);
        }

        /// <summary>
        /// Gets all pages async.
        /// </summary>
        /// <param name="queryParams">Optional query parameters.</param>
        /// <returns>A response containing all pages.</returns>
        public async Task<PageResponse> GetPagesAsync(PostQueryParams queryParams = null)
        {
            var request = CreateRequest(Method.Get, "pages");
            ApplyPageQueryParams(request, queryParams);
            return await ExecuteAsync<PageResponse>(request);
        }

        /// <summary>
        /// Gets a page by its ID.
        /// </summary>
        /// <param name="id">The ID of the page.</param>
        /// <param name="queryParams">Optional query parameters.</param>
        /// <returns>The page with the given ID.</returns>
        public Post GetPageById(string id, PostQueryParams queryParams = null)
        {
            var request = CreateRequest(Method.Get, "pages", id);
            ApplyPageQueryParams(request, queryParams);
            return Execute<PageResponse>(request)?.Pages?.Single();
        }

        /// <summary>
        /// Gets a page by its ID async.
        /// </summary>
        /// <param name="id">The ID of the page.</param>
        /// <param name="queryParams">Optional query parameters.</param>
        /// <returns>The page with the given ID.</returns>
        public async Task<Post> GetPageByIdAsync(string id, PostQueryParams queryParams = null)
        {
            var request = CreateRequest(Method.Get, "pages", id);
            ApplyPageQueryParams(request, queryParams);
            var response = await ExecuteAsync<PageResponse>(request);
            return response?.Pages?.Single();
        }

        /// <summary>
        /// Gets a page by its slug.
        /// </summary>
        /// <param name="slug">The slug of the page.</param>
        /// <param name="queryParams">Optional query parameters.</param>
        /// <returns>The page with the given slug.</returns>
        public Post GetPageBySlug(string slug, PostQueryParams queryParams = null)
        {
            var request = CreateRequest(Method.Get, "pages/slug", slug);
            ApplyPageQueryParams(request, queryParams);
            return Execute<PageResponse>(request)?.Pages?.Single();
        }

        /// <summary>
        /// Gets a page by its slug sync.
        /// </summary>
        /// <param name="slug">The slug of the page.</param>
        /// <param name="queryParams">Optional query parameters.</param>
        /// <returns>The page with the given slug.</returns>
        public async Task<Post> GetPageBySlugAsync(string slug, PostQueryParams queryParams = null)
        {
            var request = CreateRequest(Method.Get, "pages/slug", slug);
            ApplyPageQueryParams(request, queryParams);
            var response = await ExecuteAsync<PageResponse>(request);
            return response.Pages?.Single();
        }

        /// <summary>
        /// Applies any specified parameters to the page request.
        /// </summary>
        /// <param name="request">A page REST request.</param>
        /// <param name="queryParams">Query parameters.</param>
        void ApplyPageQueryParams(RestRequest request, PostQueryParams queryParams)
        {
            ApplyPostQueryParams(request, queryParams);
        }
    }
}
