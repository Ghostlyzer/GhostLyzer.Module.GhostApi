using GhostLyzer.Module.GhostApi.Enums;
using GhostLyzer.Module.GhostApi.Extensions;
using GhostLyzer.Module.GhostApi.Models;
using GhostLyzer.Module.GhostApi.QueryParams;
using RestSharp;

namespace GhostLyzer.Module.GhostApi.Services
{
    public partial class GhostAPI
    {

        /// <summary>
        /// Gets all posts.
        /// </summary>
        /// <param name="queryParams">Optional query parameters.</param>
        /// <returns>A response containing all posts.</returns>
        public PostResponse GetPosts(PostQueryParams queryParams = null)
        {
            var request = CreateRequest("posts", Method.Get);
            ApplyPostQueryParams(request, queryParams);
            return Execute<PostResponse>(request);
        }

        /// <summary>
        /// Gets a post by its ID.
        /// </summary>
        /// <param name="id">The ID of the post.</param>
        /// <param name="queryParams">Optional query parameters.</param>
        /// <returns>The post with the given ID.</returns>
        public Post GetPostById(string id, PostQueryParams queryParams = null)
        {
            return GetSinglePost($"posts", id, queryParams);
        }

        /// <summary>
        /// Gets a post by its slug.
        /// </summary>
        /// <param name="slug">The slug of the post.</param>
        /// <param name="queryParams">Optional query parameters.</param>
        /// <returns>The post with the given slug.</returns>
        public Post GetPostBySlug(string slug, PostQueryParams queryParams = null)
        {
            return GetSinglePost($"posts/slug", slug, queryParams);
        }

        /// <summary>
        /// Gets a single post for a given resource.
        /// </summary>
        /// <param name="resource">The resource endpoint.</param>
        /// <param name="queryParams">Optional query parameters.</param>
        /// <returns>A single post for the given resource.</returns>
        private Post GetSinglePost(string resource, string identifier, PostQueryParams queryParams)
        {
            var request = CreateRequest(resource, Method.Get, identifier);
            ApplyPostQueryParams(request, queryParams);
            return Execute<PostResponse>(request)?.Posts?.Single();
        }

        /// <summary>
        /// Applies any specified parameters to the post request.
        /// </summary>
        /// <param name="request">A post REST request.</param>
        /// <param name="queryParams">Query parameters.</param>
        private void ApplyPostQueryParams(RestRequest request, PostQueryParams queryParams)
        {
            if (queryParams != null)
            {
                if (queryParams.IncludeAuthors && queryParams.IncludeTags)
                    request.AddQueryParameter("include", "authors,tags");
                else if (queryParams.IncludeAuthors)
                    request.AddQueryParameter("include", "authors");
                else if (queryParams.IncludeTags)
                    request.AddQueryParameter("include", "tags");

                if (queryParams.Fields != 0)
                    request.AddQueryParameter("fields", StringExtensions.GetQueryStringFromFlagsEnum<PostFields>(queryParams.Fields));

                if (queryParams.Fields2 != 0)
                    request.AddQueryParameter("fields", StringExtensions.GetQueryStringFromFlagsEnum<PostFields2>(queryParams.Fields));

                if (!string.IsNullOrWhiteSpace(queryParams.Filter))
                    request.AddQueryParameter("filter", queryParams.Filter);

                if (queryParams.Formats != 0)
                    request.AddQueryParameter("formats", StringExtensions.GetQueryStringFromFlagsEnum<PostFormat>(queryParams.Formats));

                if (queryParams.NoLimit)
                    request.AddQueryParameter("limit", "all");
                else if (queryParams.Limit > 0)
                    request.AddQueryParameter("limit", queryParams.Limit);

                if (queryParams.Page > 0)
                    request.AddQueryParameter("page", queryParams.Page);

                if (queryParams.Order?.Any() == true)
                    request.AddQueryParameter("order", StringExtensions.GetOrderQueryString(queryParams.Order));
            }
        }
    }
}
