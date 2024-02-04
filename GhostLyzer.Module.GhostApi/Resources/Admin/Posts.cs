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
        /// Create a post
        /// </summary>
        /// <param name="post">Post to create</param>
        /// <returns>Returns the created post</returns>
        public Post CreatePost(Post post)
        {
            var request = CreateRequest(Method.Post, "posts");
            request.AddJsonBody(new PostRequest { Posts = new List<Post> { post } });

            // To use HTML as the source for your content instead of mobiledoc, use the source parameter.
            // Ref: https://ghost.org/docs/admin-api/#source-html
            if (!string.IsNullOrEmpty(post.Html))
                request.AddQueryParameter("source", "html");

            return Execute<PostRequest>(request).Posts[0];
        }

        /// <summary>
        /// Update a post
        /// </summary>
        /// <param name="post">Post to update</param>
        /// <returns>Returns the updated post</returns>
        public Post UpdatePost(Post updatedPost)
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

            // To use HTML as the source for your content instead of mobiledoc, use the source parameter.
            // Ref: https://ghost.org/docs/admin-api/#source-html
            if (!string.IsNullOrEmpty(updatedPost.Html))
                request.AddQueryParameter("source", "html");

            return Execute<PostRequest>(request).Posts[0];
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
    }
}
