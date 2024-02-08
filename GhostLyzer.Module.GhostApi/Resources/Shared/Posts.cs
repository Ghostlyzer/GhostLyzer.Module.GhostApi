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
            var request = PrepareGetPostsRequest(queryParams);
            return Execute<PostResponse>(request);
        }

        /// <summary>
        /// Gets all posts asynchronously.
        /// </summary>
        /// <param name="queryParams">Optional query parameters.</param>
        /// <returns>A response containing all posts.</returns>
        public async Task<PostResponse> GetPostsAsync(PostQueryParams queryParams = null)
        {
            var request = PrepareGetPostsRequest(queryParams);
            return await ExecuteAsync<PostResponse>(request);
        }

        /// <summary>
        /// Gets a post by its ID.
        /// </summary>
        /// <param name="id">The ID of the post.</param>
        /// <param name="queryParams">Optional query parameters.</param>
        /// <returns>The post with the given ID.</returns>
        public Post GetPostById(string id, PostQueryParams queryParams = null)
        {
            var request = PrepareGetSinglePostRequest("posts", id, queryParams);
            return Execute<PostResponse>(request)?.Posts?.Single();
        }

        /// <summary>
        /// Gets a post by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the post.</param>
        /// <param name="queryParams">Optional query parameters.</param>
        /// <returns>The post with the given ID.</returns>
        public async Task<Post> GetPostByIdAsync(string id, PostQueryParams queryParams = null)
        {
            var request = PrepareGetSinglePostRequest("posts", id, queryParams);
            var response = await ExecuteAsync<PostResponse>(request);
            return response?.Posts?.Single();
        }

        /// <summary>
        /// Gets a post by its slug.
        /// </summary>
        /// <param name="slug">The slug of the post.</param>
        /// <param name="queryParams">Optional query parameters.</param>
        /// <returns>The post with the given slug.</returns>
        public Post GetPostBySlug(string slug, PostQueryParams queryParams = null)
        {
            var request = PrepareGetSinglePostRequest("posts/slug", slug, queryParams);
            return Execute<PostResponse>(request)?.Posts?.Single();
        }

        /// <summary>
        /// Gets a post by its slug asynchronously.
        /// </summary>
        /// <param name="slug">The slug of the post.</param>
        /// <param name="queryParams">Optional query parameters.</param>
        /// <returns>The post with the given slug.</returns>
        public async Task<Post> GetPostBySlugAsync(string slug, PostQueryParams queryParams = null)
        {
            var request = PrepareGetSinglePostRequest("posts/slug", slug, queryParams);
            var response = await ExecuteAsync<PostResponse>(request);
            return response?.Posts?.Single();
        }

        /// <summary>
        /// Applies any specified parameters to the post request.
        /// </summary>
        /// <param name="request">A post REST request.</param>
        /// <param name="queryParams">Query parameters.</param>
        //private void ApplyPostQueryParams(RestRequest request, PostQueryParams queryParams)
        //{
        //    if (queryParams != null)
        //    {
        //        if (queryParams.IncludeAuthors && queryParams.IncludeTags)
        //            request.AddQueryParameter("include", "authors,tags");
        //        else if (queryParams.IncludeAuthors)
        //            request.AddQueryParameter("include", "authors");
        //        else if (queryParams.IncludeTags)
        //            request.AddQueryParameter("include", "tags");

        //        if (queryParams.Fields != 0)
        //            request.AddQueryParameter("fields", StringExtensions.GetQueryStringFromFlagsEnum<PostFields>(queryParams.Fields));

        //        if (queryParams.Fields2 != 0)
        //            request.AddQueryParameter("fields", StringExtensions.GetQueryStringFromFlagsEnum<PostFields2>(queryParams.Fields));

        //        if (!string.IsNullOrWhiteSpace(queryParams.Filter))
        //            request.AddQueryParameter("filter", queryParams.Filter);

        //        if (queryParams.Formats != 0)
        //            request.AddQueryParameter("formats", StringExtensions.GetQueryStringFromFlagsEnum<PostFormat>(queryParams.Formats));

        //        if (queryParams.NoLimit)
        //            request.AddQueryParameter("limit", "all");
        //        else if (queryParams.Limit > 0)
        //            request.AddQueryParameter("limit", queryParams.Limit);

        //        if (queryParams.Page > 0)
        //            request.AddQueryParameter("page", queryParams.Page);

        //        if (queryParams.Order?.Any() == true)
        //            request.AddQueryParameter("order", StringExtensions.GetOrderQueryString(queryParams.Order));
        //    }
        //}

        private void ApplyPostQueryParams(RestRequest request, PostQueryParams queryParams)
        {
            if (queryParams == null) return;

            AddIncludeParameter(request, queryParams);
            AddFieldsParameter(request, queryParams);
            AddFilterParameter(request, queryParams);
            AddFormatsParameter(request, queryParams);
            AddLimitParameter(request, queryParams);
            AddPageParameter(request, queryParams);
            AddOrderParameter(request, queryParams);
        }

        private void AddIncludeParameter(RestRequest request, PostQueryParams queryParams)
        {
            if (queryParams.IncludeAuthors && queryParams.IncludeTags)
                request.AddQueryParameter("include", "authors,tags");
            else if (queryParams.IncludeAuthors)
                request.AddQueryParameter("include", "authors");
            else if (queryParams.IncludeTags)
                request.AddQueryParameter("include", "tags");
        }

        private void AddFieldsParameter(RestRequest request, PostQueryParams queryParams)
        {
            if (queryParams.Fields != 0)
                request.AddQueryParameter("fields", StringExtensions.GetQueryStringFromFlagsEnum<PostFields>(queryParams.Fields));

            if (queryParams.Fields2 != 0)
                request.AddQueryParameter("fields", StringExtensions.GetQueryStringFromFlagsEnum<PostFields2>(queryParams.Fields));
        }

        private void AddFilterParameter(RestRequest request, PostQueryParams queryParams)
        {
            if (!string.IsNullOrWhiteSpace(queryParams.Filter))
                request.AddQueryParameter("filter", queryParams.Filter);
        }

        private void AddFormatsParameter(RestRequest request, PostQueryParams queryParams)
        {
            if (queryParams.Formats != 0)
                request.AddQueryParameter("formats", StringExtensions.GetQueryStringFromFlagsEnum<PostFormat>(queryParams.Formats));
        }

        private void AddLimitParameter(RestRequest request, PostQueryParams queryParams)
        {
            if (queryParams.NoLimit)
                request.AddQueryParameter("limit", "all");
            else if (queryParams.Limit > 0)
                request.AddQueryParameter("limit", queryParams.Limit.ToString());
        }

        private void AddPageParameter(RestRequest request, PostQueryParams queryParams)
        {
            if (queryParams.Page > 0)
                request.AddQueryParameter("page", queryParams.Page.ToString());
        }

        private void AddOrderParameter(RestRequest request, PostQueryParams queryParams)
        {
            if (queryParams.Order?.Any() == true)
                request.AddQueryParameter("order", StringExtensions.GetOrderQueryString(queryParams.Order));
        }

        /// <summary>
        /// Prepares a RestRequest for getting all posts.
        /// </summary>
        /// <param name="queryParams">Optional query parameters.</param>
        /// <returns>A RestRequest that can be used to get all posts.</returns>
        private RestRequest PrepareGetPostsRequest(PostQueryParams queryParams = null)
        {
            var request = CreateRequest(Method.Get, "posts");
            ApplyPostQueryParams(request, queryParams);
            return request;
        }

        /// <summary>
        /// Prepares a RestRequest for getting a single post.
        /// </summary>
        /// <param name="resource">The resource endpoint.</param>
        /// <param name="identifier">The identifier of the post.</param>
        /// <param name="queryParams">Optional query parameters.</param>
        /// <returns>A RestRequest that can be used to get a single post.</returns>
        private RestRequest PrepareGetSinglePostRequest(string resource, string identifier, PostQueryParams queryParams)
        {
            var request = CreateRequest(Method.Get, resource, identifier);
            ApplyPostQueryParams(request, queryParams);
            return request;
        }
    }
}
