using GhostLyzer.Module.GhostApi.Models;
using GhostLyzer.Module.GhostApi.QueryParams;

namespace GhostLyzer.Module.GhostApi.Services
{
    public partial class GhostContentAPI
    {
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
        /// Get a collection of published pages asynchronously,
        /// including meta data about pagination so you can retrieve data in chunks.
        /// </summary>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the pages.</returns>
        public new async Task<PageResponse> GetPagesAsync(PostQueryParams queryParams = null)
        {
            return await base.GetPagesAsync(queryParams);
        }

        /// <summary>
        /// Get a specific page based on its ID.
        /// </summary>
        /// <returns>The page matching the given ID. By default, returns HTML format.</returns>
        /// <param name="id">The ID of the page to retrieve.</param>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        public new Post GetPageById(string id, PostQueryParams queryParams = null)
        {
            return base.GetPageById(id, queryParams);
        }

        /// <summary>
        /// Get a specific page based on its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the page to retrieve.</param>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the page matching the given ID. By default, returns HTML format.</returns>
        public new async Task<Post> GetPageByIdAsync(string id, PostQueryParams queryParams = null)
        {
            return await base.GetPageByIdAsync(id, queryParams);
        }

        /// <summary>
        /// Get a specific page based on its slug.
        /// </summary>
        /// <returns>The page matching the given slug. By default, returns HTML format.</returns>
        /// <param name="slug">The slug of the page to retrieve.</param>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        public new Post GetPageBySlug(string slug, PostQueryParams queryParams = null)
        {
            return base.GetPageBySlug(slug, queryParams);
        }

        /// <summary>
        /// Get a specific page based on its slug asynchronously.
        /// </summary>
        /// <param name="slug">The slug of the page to retrieve.</param>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the page matching the given slug. By default, returns HTML format.</returns>
        public new async Task<Post> GetPageBySlugAsync(string slug, PostQueryParams queryParams = null)
        {
            return await base.GetPageBySlugAsync(slug, queryParams);
        }
    }
}
