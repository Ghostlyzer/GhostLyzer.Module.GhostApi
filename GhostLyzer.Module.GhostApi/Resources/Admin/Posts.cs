using GhostLyzer.Module.GhostApi.ContractResolvers;
using GhostLyzer.Module.GhostApi.Models;
using GhostLyzer.Module.GhostApi.QueryParams;
using Newtonsoft.Json;
using RestSharp;

namespace GhostLyzer.Module.GhostApi.Services
{
    public partial class GhostAdminAPI
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
        /// <returns>The posts.</returns>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        public new async Task<PostResponse> GetPostsAsync(PostQueryParams queryParams = null)
        {
            return await base.GetPostsAsync(queryParams);
        }

        /// <summary>
        /// Get a specific post based on its ID.
        /// </summary>
        /// <returns>The post matching the given ID. By default, returns MobileDoc format and author and tag data.</returns>
        /// <param name="id">The ID of the post to retrieve.</param>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        public new Post GetPostById(string id, PostQueryParams queryParams = null)
        {
            return base.GetPostById(id, queryParams);
        }

        /// <summary>
        /// Get a specific post based on its ID asynchronously.
        /// </summary>
        /// <returns>The post matching the given ID. By default, returns MobileDoc format and author and tag data.</returns>
        /// <param name="id">The ID of the post to retrieve.</param>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        public new async Task<Post> GetPostByIdAsync(string id, PostQueryParams queryParams = null)
        {
            return await base.GetPostByIdAsync(id, queryParams);
        }

        /// <summary>
        /// Get a specific post based on its slug.
        /// </summary>
        /// <returns>The post matching the given slug. By default, returns MobileDoc format and author and tag data.</returns>
        /// <param name="slug">The slug of the post to retrieve.</param>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        public new Post GetPostBySlug(string slug, PostQueryParams queryParams = null)
        {
            return base.GetPostBySlug(slug, queryParams);
        }

        /// <summary>
        /// Get a specific post based on its slug asynchronously.
        /// </summary>
        /// <returns>The post matching the given slug. By default, returns MobileDoc format and author and tag data.</returns>
        /// <param name="slug">The slug of the post to retrieve.</param>
        /// <param name="queryParams">Parameters that affect the resultset.</param>
        public new async Task<Post> GetPostBySlugAsync(string slug, PostQueryParams queryParams = null)
        {
            return await base.GetPostBySlugAsync(slug, queryParams);
        }

        /// <summary>
        /// Create a post.
        /// </summary>
        /// <param name="post">Post to create</param>
        /// <returns>Returns the created post</returns>
        public Post CreatePost(Post post)
        {
            var request = PrepareCreatePostRequest(post);
            return Execute<PostRequest>(request).Posts[0];
        }

        /// <summary>
        /// Create a post asynchronously.
        /// </summary>
        /// <param name="post">Post to create</param>
        /// <returns>Returns the created post</returns>
        public async Task<Post> CreatePostAsync(Post post)
        {
            var request = PrepareCreatePostRequest(post);
            return (await ExecuteAsync<PostRequest>(request)).Posts[0];
        }

        /// <summary>
        /// Update a post.
        /// </summary>
        /// <param name="post">Post to update</param>
        /// <returns>Returns the updated post</returns>
        public Post UpdatePost(Post updatedPost)
        {
            var request = PreparePostUpdateRequest(updatedPost);
            return Execute<PostRequest>(request).Posts[0];
        }

        /// <summary>
        /// Update a post asynchronously.
        /// </summary>
        /// <param name="post">Post to update</param>
        /// <returns>Returns the updated post</returns>
        public async Task<Post> UpdatePostAsync(Post updatedPost)
        {
            var request = PreparePostUpdateRequest(updatedPost);
            return (await ExecuteAsync<PostRequest>(request)).Posts[0];
        }

        /// <summary>
        /// Delete a post
        /// </summary>
        /// <param name="id">The ID of the post to delete</param>
        /// <returns>True if the delete succeeded; otherwise False</returns>
        public bool DeletePost(string id)
        {
            var request = CreateRequest(Method.Delete, "posts", id);

            return Execute(request);
        }

        /// <summary>
        /// Deletes a post asynchronously.
        /// </summary>
        /// <param name="id">The ID of the post to delete.</param>
        /// <returns>A task representing the asynchronous operation. The task result indicates whether the post was deleted successfully.</returns>
        public async Task<bool> DeletePostAsync(string id)
        {
            var request = PrepareDeletePostRequest(id);
            return await ExecuteAsync(request);
        }

        #region Helpers

        /// <summary>
        /// Prepares a request to create a post.
        /// </summary>
        /// <param name="post">The post to create.</param>
        /// <returns>A RestRequest object representing the request.</returns>
        private RestRequest PrepareCreatePostRequest(Post post)
        {
            var request = CreateRequest(Method.Post, "posts");
            request.AddJsonBody(new PostRequest { Posts = new List<Post> { post } });
            AddHtmlSourceParameterIfRequired(post, request);
            return request;
        }

        /// <summary>
        /// Prepares a request to update a post.
        /// </summary>
        /// <param name="updatedPost">The updated post.</param>
        /// <returns>A RestRequest object representing the request.</returns>
        private RestRequest PreparePostUpdateRequest(Post updatedPost)
        {
            // Per the docs, the UpdatedAt field is used to avoid collision detection
            // If an update fails, it might be that someone updated it more recently on site,
            // and you should re-get it and re-apply your changes to it... otherwise you
            // risk unintentionally overwriting later changes on the site.
            // Ref: https://ghost.org/docs/admin-api/#updating-a-post

            var serializedPost = JsonConvert.SerializeObject(
               new PostRequest { Posts = new List<Post> { updatedPost } },
               new JsonSerializerSettings { ContractResolver = UpdatePostContractResolver.Instance }
            );

            var request = CreateRequest(Method.Put, "posts", updatedPost.Id);
            request.AddJsonBody(serializedPost);
            AddHtmlSourceParameterIfRequired(updatedPost, request);
            return request;
        }

        /// <summary>
        /// Prepares a request to delete a post.
        /// </summary>
        /// <param name="id">The ID of the post to delete.</param>
        /// <returns>A RestRequest object representing the request.</returns>
        private RestRequest PrepareDeletePostRequest(string id)
        {
            return CreateRequest(Method.Delete, "posts", id);
        }

        /// <summary>
        /// Adds the HTML source parameter to a request if required.
        /// </summary>
        /// <param name="post">The post.</param>
        /// <param name="request">The request.</param>
        private void AddHtmlSourceParameterIfRequired(Post post, RestRequest request)
        {
            if (!string.IsNullOrEmpty(post.Html))
                request.AddQueryParameter("source", "html");
        }

        #endregion
    }
}
