using GhostLyzer.Module.GhostApi.Enums;
using GhostLyzer.Module.GhostApi.Extensions;
using GhostLyzer.Module.GhostApi.Models;
using GhostLyzer.Module.GhostApi.QueryParams;
using RestSharp;

namespace GhostLyzer.Module.GhostApi.Services
{
    public partial class GhostContentAPI
    {
        #region Read

        /// <summary>
        /// Get all authors.
        /// </summary>
        /// <param name="queryParams">Optional parameters for the request.</param>
        /// <returns>A response containing all authors.</returns>
        public AuthorResponse GetAuthors(AuthorQueryParams queryParams = null)
        {
            var request = PrepareGetAuthorsRequest(queryParams);
            return Execute<AuthorResponse>(request);
        }

        /// <summary>
        /// Get all authors asynchronously.
        /// </summary>
        /// <param name="queryParams">Optional parameters for the request.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a response with all authors.</returns>
        public async Task<AuthorResponse> GetAuthorsAsync(AuthorQueryParams queryParams = null)
        {
            var request = PrepareGetAuthorsRequest(queryParams);
            return await ExecuteAsync<AuthorResponse>(request);
        }

        /// <summary>
        /// Get an author by their ID.
        /// </summary>
        /// <param name="id">The ID of the author.</param>
        /// <param name="queryParams">Optional parameters for the request.</param>
        /// <returns>The author with the specified ID.</returns>
        public Author GetAuthorById(string id, AuthorQueryParams queryParams = null)
        {
            var request = PrepareGetAuthorByIdRequest(id, queryParams);
            return Execute<AuthorResponse>(request)?.Authors?.Single();
        }

        /// <summary>
        /// Get an author by their ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the author.</param>
        /// <param name="queryParams">Optional parameters for the request.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the author with the specified ID.</returns>
        public async Task<Author> GetAuthorByIdAsync(string id, AuthorQueryParams queryParams = null)
        {
            var request = PrepareGetAuthorByIdRequest(id, queryParams);
            var response = await ExecuteAsync<AuthorResponse>(request);
            return response?.Authors?.Single();
        }

        /// <summary>
        /// Get an author by their slug.
        /// </summary>
        /// <param name="slug">The slug of the author.</param>
        /// <param name="queryParams">Optional parameters for the request.</param>
        /// <returns>The author with the specified slug.</returns>
        public Author GetAuthorBySlug(string slug, AuthorQueryParams queryParams = null)
        {
            var request = PrepareGetAuthorBySlugRequest(slug, queryParams);
            return Execute<AuthorResponse>(request)?.Authors?.Single();
        }

        /// <summary>
        /// Get an author by their slug asynchronously.
        /// </summary>
        /// <param name="slug">The slug of the author.</param>
        /// <param name="queryParams">Optional parameters for the request.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the author with the specified slug.</returns>
        public async Task<Author> GetAuthorBySlugAsync(string slug, AuthorQueryParams queryParams = null)
        {
            var request = PrepareGetAuthorBySlugRequest(slug, queryParams);
            var response = await ExecuteAsync<AuthorResponse>(request);
            return response?.Authors?.Single();
        }

        #endregion

        #region Helpers

        private RestRequest PrepareGetAuthorsRequest(AuthorQueryParams queryParams = null)
        {
            var request = CreateRequest(Method.Get, "authors");
            ApplyAuthorQueryParams(request, queryParams);
            return request;
        }

        private RestRequest PrepareGetAuthorByIdRequest(string id, AuthorQueryParams queryParams = null)
        {
            var request = CreateRequest(Method.Get, "authors", id);
            ApplyAuthorQueryParams(request, queryParams);
            return request;
        }

        private RestRequest PrepareGetAuthorBySlugRequest(string slug, AuthorQueryParams queryParams = null)
        {
            var request = CreateRequest(Method.Get, "authors/slug", slug);
            ApplyAuthorQueryParams(request, queryParams);
            return request;
        }

        /// <summary>
        /// Applies any specified parameters to the user request.
        /// </summary>
        /// <param name="request">A user REST request.</param>
        /// <param name="queryParams">Query parameters.</param>
        private static void ApplyAuthorQueryParams(RestRequest request, AuthorQueryParams queryParams)
        {
            if (queryParams != null)
            {
                if (queryParams.IncludePostCount)
                    request.AddQueryParameter("include", "count.posts");

                if (queryParams.Fields != 0)
                    request.AddQueryParameter("fields", StringExtensions.GetQueryStringFromFlagsEnum<AuthorFields>(queryParams.Fields));

                if (!string.IsNullOrWhiteSpace(queryParams.Filter))
                    request.AddQueryParameter("filter", queryParams.Filter);

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

        #endregion 
    }
}
