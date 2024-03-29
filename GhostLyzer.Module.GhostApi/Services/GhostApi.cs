﻿using GhostLyzer.Module.GhostApi.Enums;
using GhostLyzer.Module.GhostApi.Exceptions;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System.Net;

namespace GhostLyzer.Module.GhostApi.Services
{
    public partial class GhostAPI
    {
        internal string key;
        private readonly APIType apiType;
        private readonly string minimumVersion;
        public RestClient Client { internal get; set; }

        internal GhostAPI(string host, string key, ExceptionLevel exceptionLevel, string baseUrl, APIType apiType, string minimumVersion)
            : this(host, exceptionLevel, baseUrl, apiType, minimumVersion)
        {
            this.key = key;
        }

        internal GhostAPI(string host, ExceptionLevel exceptionLevel, string baseUrl, APIType apiType, string minimumVersion)
        {
            this.apiType = apiType;
            this.minimumVersion = minimumVersion;
            Client = new RestClient(
                new Uri(new Uri(host), baseUrl).ToString(),
                configureSerialization: s => s.UseNewtonsoftJson());
            ExceptionLevel = exceptionLevel;
        }

        /// <summary>
        /// Specify which exceptions to rethrow, if any. Default is All.
        /// </summary>
        public ExceptionLevel ExceptionLevel { private get; set; }

        /// <summary>
        /// Gets the last exception that was thrown.
        /// </summary>
        /// <value>The last exception.</value>
        public Exception LastException { get; internal set; }

        /// <summary>
        /// Calls the Ghost API and returns the response data.
        /// If exceptions are suppressed, returns null on failure.
        /// </summary>
        /// <returns>The API response.</returns>
        /// <param name="request">A RestRequest representing the resource being requested.</param>
        /// <typeparam name="T">The type of object being requested</typeparam>
        internal T Execute<T>(RestRequest request) where T : new()
        {
            if (!string.IsNullOrEmpty(key))
                AuthorizeRequest(request);

            request.AddOrUpdateHeader("Accept-Version", $@"v{minimumVersion ?? "5.0"}");

            try
            {
                var response = Client.Execute<T>(request);
                TestResponseForErrors(response, request);
                return response.Data;
            }
            catch (GhostApiException)
            {
                if (ExceptionLevel == ExceptionLevel.Ghost || ExceptionLevel == ExceptionLevel.All)
                    throw;

                return default;
            }
            catch
            {
                if (ExceptionLevel == ExceptionLevel.NonGhost || ExceptionLevel == ExceptionLevel.All)
                    throw;

                return default;
            }
        }

        internal async Task<T> ExecuteAsync<T>(RestRequest request) where T : new()
        {
            if (!string.IsNullOrEmpty(key))
                AuthorizeRequest(request);

            request.AddOrUpdateHeader("Accept-Version", $@"v{minimumVersion ?? "5.0"}");

            try
            {
                var response = await Client.ExecuteAsync<T>(request);
                TestResponseForErrors(response, request);
                return response.Data;
            }
            catch (GhostApiException)
            {
                if (ExceptionLevel == ExceptionLevel.Ghost || ExceptionLevel == ExceptionLevel.All)
                    throw;

                return default;
            }
            catch
            {
                if (ExceptionLevel == ExceptionLevel.NonGhost || ExceptionLevel == ExceptionLevel.All)
                    throw;

                return default;
            }
        }

        /// <summary>
        /// Calls the Ghost API and returns the response data.
        /// If exceptions are suppressed, returns null on failure.
        /// </summary>
        /// <returns>The API response.</returns>
        /// <param name="request">A RestRequest representing the resource being requested.</param>
        internal bool Execute(RestRequest request)
        {
            AuthorizeRequest(request);

            try
            {
                var response = Client.Execute(request);
                TestResponseForErrors(response, request);
                return response.StatusCode == HttpStatusCode.NoContent;
            }
            catch (GhostApiException)
            {
                if (ExceptionLevel == ExceptionLevel.Ghost || ExceptionLevel == ExceptionLevel.All)
                    throw;

                return default;
            }
            catch
            {
                if (ExceptionLevel == ExceptionLevel.NonGhost || ExceptionLevel == ExceptionLevel.All)
                    throw;

                return default;
            }
        }

        /// <summary>
        /// Calls the Ghost API and returns the response data.
        /// If exceptions are suppressed, returns null on failure.
        /// </summary>
        /// <returns>The API response.</returns>
        /// <param name="request">A RestRequest representing the resource being requested.</param>
        internal async Task<bool> ExecuteAsync(RestRequest request)
        {
            AuthorizeRequest(request);

            try
            {
                var response = await Client.ExecuteAsync(request);
                TestResponseForErrors(response, request);
                return response.StatusCode == HttpStatusCode.NoContent;
            }
            catch (GhostApiException)
            {
                if (ExceptionLevel == ExceptionLevel.Ghost || ExceptionLevel == ExceptionLevel.All)
                    throw;

                return default;
            }
            catch
            {
                if (ExceptionLevel == ExceptionLevel.NonGhost || ExceptionLevel == ExceptionLevel.All)
                    throw;

                return default;
            }
        }

        /// <summary>
        /// Creates a new RestRequest object for use with the request to Ghost API.
        /// </summary>
        /// <param name="resource">The resource endpoint.</param>
        /// <param name="method">The HTTP method.</param>
        /// <param name="id">The optional id parameter.</param>
        /// <returns>The created RestRequest.</returns>
        internal RestRequest CreateRequest(Method method, string resource, string identifier = null)
        {
            return new RestRequest($"{resource}/{identifier}", method);
        }

        /// <summary>
        /// If response.Content has one or more error messages (returned from Ghost),
        /// or response.Exception contains an exception (some other exception thrown during request),
        /// create and throw a GhostSharpException with the details.
        /// </summary>
        /// <param name="response">The API response</param>
        private void TestResponseForErrors(RestResponse response, RestRequest request)
        {
            var apiFailure = JsonConvert.DeserializeObject<GhostApiFailure>(response.Content);
            if (apiFailure != null && apiFailure.Errors != null)
            {
                var ex = new GhostApiException(apiFailure.Errors);
                LastException = ex;
                throw ex;
            }

            if (response.ErrorException != null)
            {
                var ex = new GhostApiException($"Unable to {request.Method} /{request.Resource}: {response.ResponseStatus}", response.ErrorException);
                LastException = ex;
                throw ex;
            }
        }

        /// <summary>
        /// Add the key as a query parameter or authorization token as a header, depending on the API being used.
        /// </summary>
        /// <param name="request">The request being made</param>
        private void AuthorizeRequest(RestRequest request)
        {
            switch (apiType)
            {
                case APIType.Content:
                    request.AddQueryParameter("key", key);
                    break;
                case APIType.Admin:
                    request.AddHeader("Authorization", $"Ghost {key}");
                    break;
            }
        }
    }
}
