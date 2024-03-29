using GhostLyzer.Module.GhostApi.Models;
using GhostLyzer.Module.GhostApi.QueryParams;

namespace GhostLyzer.Module.GhostApi.Services
{
    public partial class GhostContentAPI
    {
        /// <summary>
        /// Get a collection of tags,
        /// including meta data about pagination so you can retrieve data in chunks.
        /// </summary>
        /// <returns>The tags.</returns>
        /// <param name="queryParams">Parameters that affect which tags are returned.</param>
        public new TagResponse GetTags(TagQueryParams queryParams = null)
        {
            return base.GetTags(queryParams);
        }

        /// <summary>
        /// Get a collection of tags asynchronously,
        /// including meta data about pagination so you can retrieve data in chunks.
        /// </summary>
        /// <returns>The tags.</returns>
        /// <param name="queryParams">Parameters that affect which tags are returned.</param>
        public new async Task<TagResponse> GetTagsAsync(TagQueryParams queryParams = null)
        {
            return await base.GetTagsAsync(queryParams);
        }

        /// <summary>
        /// Get a specific tag based on its ID.
        /// </summary>
        /// <returns>The tag matching the given ID.</returns>
        /// <param name="id">The ID of the tag to retrieve.</param>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        public new Tag GetTagById(string id, TagQueryParams queryParams = null)
        {
            return base.GetTagById(id, queryParams);
        }

        /// <summary>
        /// Get a specific tag based on its ID asynchronously.
        /// </summary>
        /// <returns>The tag matching the given ID.</returns>
        /// <param name="id">The ID of the tag to retrieve.</param>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        public new async Task<Tag> GetTagByIdAsync(string id, TagQueryParams queryParams = null)
        {
            return await base.GetTagByIdAsync(id, queryParams);
        }

        /// <summary>
        /// Get a specific tag based on its slug.
        /// </summary>
        /// <returns>The tag matching the given slug.</returns>
        /// <param name="slug">The slug of the tag to retrieve.</param>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        public new Tag GetTagBySlug(string slug, TagQueryParams queryParams = null)
        {
            return base.GetTagBySlug(slug, queryParams);
        }

        /// <summary>
        /// Get a specific tag based on its slug.
        /// </summary>
        /// <returns>The tag matching the given slug.</returns>
        /// <param name="slug">The slug of the tag to retrieve.</param>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        public new async Task<Tag> GetTagBySlugAsync(string slug, TagQueryParams queryParams = null)
        {
            return await base.GetTagBySlugAsync(slug, queryParams);
        }
    }
}