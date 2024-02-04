using GhostLyzer.Module.GhostApi.Models;
using GhostLyzer.Module.GhostApi.QueryParams;

namespace GhostLyzer.Module.GhostApi.Services
{
    public partial class GhostContentAPI
    {
        /// <summary>
        /// Get a collection of published posts,
        /// including meta data about pagination so you can retrieve data in chunks.
        /// </summary>
        /// <returns>The posts.</returns>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        public new PostResponse GetPosts(PostQueryParams queryParams = null)
        {
            return base.GetPosts(queryParams);
        }

        /// <summary>
        /// Get a collection of published posts asynchronously,
        /// including meta data about pagination so you can retrieve data in chunks.
        /// </summary>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the posts.</returns>
        public new async Task<PostResponse> GetPostsAsync(PostQueryParams queryParams = null)
        {
            return await base.GetPostsAsync(queryParams);
        }

        /// <summary>
        /// Get a specific post based on its ID.
        /// </summary>
        /// <returns>The post matching the given ID. By default, returns HTML format.</returns>
        /// <param name="id">The ID of the post to retrieve.</param>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        public new Post GetPostById(string id, PostQueryParams queryParams = null)
        {
            return base.GetPostById(id, queryParams);
        }

        /// <summary>
        /// Get a specific post based on its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the post to retrieve.</param>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the post matching the given ID. By default, returns HTML format.</returns>
        public new async Task<Post> GetPostByIdAsync(string id, PostQueryParams queryParams = null)
        {
            return await base.GetPostByIdAsync(id, queryParams);
        }

        /// <summary>
        /// Get a specific post based on its slug.
        /// </summary>
        /// <returns>The post matching the given slug. By default, returns HTML format.</returns>
        /// <param name="slug">The slug of the post to retrieve.</param>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        public new Post GetPostBySlug(string slug, PostQueryParams queryParams = null)
        {
            return base.GetPostBySlug(slug, queryParams);
        }

        /// <summary>
        /// Get a specific post based on its slug asynchronously.
        /// </summary>
        /// <param name="slug">The slug of the post to retrieve.</param>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the post matching the given slug. By default, returns HTML format.</returns>
        public new async Task<Post> GetPostBySlugAsync(string slug, PostQueryParams queryParams = null)
        {
            return await base.GetPostBySlugAsync(slug, queryParams);
        }
    }
}
