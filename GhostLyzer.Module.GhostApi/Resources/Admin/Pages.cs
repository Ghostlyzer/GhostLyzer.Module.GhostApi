using GhostLyzer.Module.GhostApi.ContractResolvers;
using GhostLyzer.Module.GhostApi.Models;
using GhostLyzer.Module.GhostApi.QueryParams;
using Newtonsoft.Json;
using RestSharp;

namespace GhostLyzer.Module.GhostApi.Services
{
    public partial class GhostAdminAPI
    {
        #region Create

        /// <summary>
        /// Create a page
        /// </summary>
        /// <param name="page">Page to create</param>
        /// <returns>Returns the same page, along with whatever other data Ghost appended to it (like default values)</returns>
        public Post CreatePage(Post page)
        {
            var request = PreparePageCreateRequest(page);
            return Execute<PageRequest>(request).Pages[0];
        }

        /// <summary>
        /// Create a page async
        /// </summary>
        /// <param name="page">Page to create</param>
        /// <returns>Returns the same page, along with whatever other data Ghost appended to it (like default values)</returns>
        public async Task<Post> CreatePageAsync(Post page)
        {
            var request = PreparePageCreateRequest(page);
            var response = await ExecuteAsync<PageRequest>(request);
            return response.Pages[0];
        }

        #endregion

        #region Read

        /// <summary>
        /// Get a collection of published pages,
        /// including meta data about pagination so you can retrieve data in chunks.
        /// </summary>
        /// <returns>The pages.</returns>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        public new PageResponse GetPages(PostQueryParams queryParams = null)
        {
            return base.GetPages(queryParams);
        }

        /// <summary>
        /// Get a collection of published pages async,
        /// including meta data about pagination so you can retrieve data in chunks.
        /// </summary>
        /// <returns>The pages.</returns>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        public new async Task<PageResponse> GetPagesAsync(PostQueryParams queryParams = null)
        {
            return await base.GetPagesAsync(queryParams);
        }

        /// <summary>
        /// Get a specific page based on its ID.
        /// </summary>
        /// <returns>The page matching the given ID. By default, returns MobileDoc format and author and tag data.</returns>
        /// <param name="id">The ID of the page to retrieve.</param>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        public new Post GetPageById(string id, PostQueryParams queryParams = null)
        {
            return base.GetPageById(id, queryParams);
        }

        /// <summary>
        /// Get a specific page based on its ID async.
        /// </summary>
        /// <returns>The page matching the given ID. By default, returns MobileDoc format and author and tag data.</returns>
        /// <param name="id">The ID of the page to retrieve.</param>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        public new async Task<Post> GetPageByIdAsync(string id, PostQueryParams queryParams = null)
        {
            return await base.GetPageByIdAsync(id, queryParams);
        }

        /// <summary>
        /// Get a specific page based on its slug.
        /// </summary>
        /// <returns>The page matching the given slug. By default, returns MobileDoc format and author and tag data.</returns>
        /// <param name="slug">The slug of the page to retrieve.</param>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        public new Post GetPageBySlug(string slug, PostQueryParams queryParams = null)
        {
            return base.GetPageBySlug(slug, queryParams);
        }

        /// <summary>
        /// Get a specific page based on its slug async.
        /// </summary>
        /// <returns>The page matching the given slug. By default, returns MobileDoc format and author and tag data.</returns>
        /// <param name="slug">The slug of the page to retrieve.</param>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        public new async Task<Post> GetPageBySlugAsync(string slug, PostQueryParams queryParams = null)
        {
            return await base.GetPageBySlugAsync(slug, queryParams);
        }

        #endregion

        #region Update

        /// <summary>
        /// Update a page
        /// </summary>
        /// <param name="post">Page to update</param>
        /// <returns>Returns the updated page</returns>
        public Post UpdatePage(Post updatedPage)
        {
            var request = PreparePageUpdateRequest(updatedPage);
            var response = Execute<PageRequest>(request);
            return response.Pages[0];
        }

        /// <summary>
        /// Update a page async
        /// </summary>
        /// <param name="post">Page to update</param>
        /// <returns>Returns the updated page</returns>
        public async Task<Post> UpdatePageAsync(Post updatedPage)
        {
            var request = PreparePageUpdateRequest(updatedPage);
            var response = await ExecuteAsync<PageRequest>(request);
            return response.Pages[0];
        }

        #endregion

        #region Delete

        /// <summary>
        /// Delete a page
        /// </summary>
        /// <param name="id">The ID of the page to delete</param>
        /// <returns>True if the delete succeeded; otherwise False</returns>
        public bool DeletePage(string id)
        {
            var request = CreateRequest(Method.Delete, "pages", id);

            return Execute(request);
        }

        /// <summary>
        /// Delete a page async
        /// </summary>
        /// <param name="id">The ID of the page to delete</param>
        /// <returns>True if the delete succeeded; otherwise False</returns>
        public async Task<bool> DeletePageAsync(string id)
        {
            var request = CreateRequest(Method.Delete, "pages", id);

            return await ExecuteAsync(request);
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Prepares a RestRequest for updating a page.
        /// </summary>
        /// <param name="updatedPage">The page to update.</param>
        /// <returns>A RestRequest that can be used to update the page.</returns>
        private RestRequest PreparePageUpdateRequest(Post updatedPage)
        {
            // Per the docs, the UpdatedAt field is used to avoid collision detection
            // If an update fails, it might be that someone updated it more recently on site,
            // and you should re-get it and re-apply your changes to it... otherwise you
            // risk unintentionally overwriting later changes on the site.
            // Ref: https://ghost.org/docs/admin-api/#updating-a-post
            var serializedPage = JsonConvert.SerializeObject(
                new PageRequest { Pages = new List<Post> { updatedPage } },
                new JsonSerializerSettings { ContractResolver = UpdatePageContractResolver.Instance }
            );

            // Create the requets object and add the just serialized page to the body
            var request = CreateRequest(Method.Put, "pages", updatedPage.Id);
            request.AddJsonBody(serializedPage);

            // To use HTML as the source for your content instead of mobiledoc, use the source parameter.
            // Ref: https://ghost.org/docs/admin-api/#source-html
            if (!string.IsNullOrEmpty(updatedPage.Html))
                request.AddQueryParameter("source", "html");

            return request;
        }

        /// <summary>
        /// Prepares a RestRequest for creating a page.
        /// </summary>
        /// <param name="page">The page to create.</param>
        /// <returns>A RestRequest that can be used to create the page.</returns>
        private RestRequest PreparePageCreateRequest(Post page)
        {
            var serializedPage = JsonConvert.SerializeObject(
                new PageRequest { Pages = new List<Post> { page } },
                new JsonSerializerSettings
                {
                    ContractResolver = CreatePageContractResolver.Instance,
                    NullValueHandling = NullValueHandling.Ignore
                }
            );

            var request = CreateRequest(Method.Post, "pages");
            request.AddJsonBody(serializedPage);

            if (!string.IsNullOrEmpty(page.Html))
                request.AddQueryParameter("source", "html");

            return request;
        }

        #endregion
    }
}
