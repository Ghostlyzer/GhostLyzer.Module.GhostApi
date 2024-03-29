﻿using GhostLyzer.Module.GhostApi.Enums;
using GhostLyzer.Module.GhostApi.Extensions;
using GhostLyzer.Module.GhostApi.Models;
using GhostLyzer.Module.GhostApi.QueryParams;
using RestSharp;

namespace GhostLyzer.Module.GhostApi.Services
{
    public partial class GhostAPI
    {
        public TagResponse GetTags(TagQueryParams queryParams = null)
        {
            var request = CreateRequest(Method.Get, "tags");
            ApplyTagQueryParams(request, queryParams);
            return Execute<TagResponse>(request);
        }

        public Tag GetTagById(string id, TagQueryParams queryParams = null)
        {
            var request = CreateRequest(Method.Get, "tags", id);
            ApplyTagQueryParams(request, queryParams);
            return Execute<TagResponse>(request)?.Tags?.Single();
        }

        public Tag GetTagBySlug(string slug, TagQueryParams queryParams = null)
        {
            var request = CreateRequest(Method.Get, "tags/slug", slug);
            ApplyTagQueryParams(request, queryParams);
            return Execute<TagResponse>(request)?.Tags?.Single();
        }

        /// <summary>
    /// Asynchronously retrieves all tags.
    /// </summary>
    /// <param name="queryParams">Query parameters.</param>
    /// <returns>A TagResponse object containing the tags.</returns>
    public async Task<TagResponse> GetTagsAsync(TagQueryParams queryParams = null)
    {
        var request = CreateRequest(Method.Get, "tags");
        ApplyTagQueryParams(request, queryParams);
        return await ExecuteAsync<TagResponse>(request);
    }

    /// <summary>
    /// Asynchronously retrieves a tag by its ID.
    /// </summary>
    /// <param name="id">The ID of the tag.</param>
    /// <param name="queryParams">Query parameters.</param>
    /// <returns>A Tag object.</returns>
    public async Task<Tag> GetTagByIdAsync(string id, TagQueryParams queryParams = null)
    {
        var request = CreateRequest(Method.Get, "tags", id);
        ApplyTagQueryParams(request, queryParams);
        return (await ExecuteAsync<TagResponse>(request))?.Tags?.Single();
    }

    /// <summary>
    /// Asynchronously retrieves a tag by its slug.
    /// </summary>
    /// <param name="slug">The slug of the tag.</param>
    /// <param name="queryParams">Query parameters.</param>
    /// <returns>A Tag object.</returns>
    public async Task<Tag> GetTagBySlugAsync(string slug, TagQueryParams queryParams = null)
    {
        var request = CreateRequest(Method.Get, "tags/slug", slug);
        ApplyTagQueryParams(request, queryParams);
        return (await ExecuteAsync<TagResponse>(request))?.Tags?.Single();
    }

        /// <summary>
        /// Applies any specified parameters to the tag request.
        /// </summary>
        /// <param name="request">A tag REST request.</param>
        /// <param name="queryParams">Query parameters.</param>
        void ApplyTagQueryParams(RestRequest request, TagQueryParams queryParams)
        {
            if (queryParams != null)
            {
                if (queryParams.IncludePostCount)
                    request.AddQueryParameter("include", "count.posts");

                if (queryParams.Fields != 0)
                    request.AddQueryParameter("fields", StringExtensions.GetQueryStringFromFlagsEnum<TagFields>(queryParams.Fields));

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
    }
}
