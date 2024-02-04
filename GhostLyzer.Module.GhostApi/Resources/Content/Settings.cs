using GhostLyzer.Module.GhostApi.Models;
using RestSharp;

namespace GhostLyzer.Module.GhostApi.Services
{
    public partial class GhostContentAPI
    {
        /// <summary>
        /// Get the settings for the blog, including title, description,
        /// code injected into the header or footer (if any), etc...
        /// </summary>
        /// <returns>The blog settings.</returns>
        public Settings GetSettings()
        {
            var request = PrepareGetSettingsRequest();
            return Execute<SettingsResponse>(request)?.Settings;
        }

        /// <summary>
        /// Get the settings for the blog asynchronously, including title, description,
        /// code injected into the header or footer (if any), etc...
        /// </summary>
        /// <returns>The blog settings.</returns>
        public async Task<Settings> GetSettingsAsync()
        {
            var request = PrepareGetSettingsRequest();
            var response = await ExecuteAsync<SettingsResponse>(request);
            return response?.Settings;
        }

        /// <summary>
        /// Prepares a GET request for the blog settings
        /// </summary>
        /// <returns>A <see cref="RestRequest"/> to get the settings for the blog.</returns>
        private RestRequest PrepareGetSettingsRequest()
        {
            var request = CreateRequest(Method.Get, "settings");
            return request;
        }
    }
}
