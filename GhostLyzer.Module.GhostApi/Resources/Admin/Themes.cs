using GhostLyzer.Module.GhostApi.Models;
using RestSharp;

namespace GhostLyzer.Module.GhostApi.Services
{
    public partial class GhostAdminAPI
    {
        /// <summary>
        /// Uploads a theme to the site.
        /// </summary>
        /// <param name="theme">The theme to upload.</param>
        /// <returns>Returns metadata about the uploaded theme.</returns>
        public Theme UploadTheme(ThemeRequest theme)
        {
            var request = PrepareThemeUploadRequest(theme);
            return Execute<ThemeResponse>(request).Themes[0];
        }

        /// <summary>
        /// Uploads a theme to the site asynchronously.
        /// </summary>
        /// <param name="theme">The theme to upload.</param>
        /// <returns>Returns metadata about the uploaded theme.</returns>
        public async Task<Theme> UploadThemeAsync(ThemeRequest theme)
        {
            var request = PrepareThemeUploadRequest(theme);
            var response = await ExecuteAsync<ThemeResponse>(request);
            return response.Themes[0];
        }

        /// <summary>
        /// Activates a theme with the given name on the site.
        /// </summary>
        /// <param name="name">The name of the theme to activate.</param>
        /// <returns>Returns metadata about the activated theme.</returns>
        public Theme ActivateTheme(string name)
        {
            var request = PrepareThemeActivationRequest(name);
            return Execute<ThemeResponse>(request).Themes[0];
        }

        /// <summary>
        /// Activates a theme with the given name on the site asynchronously.
        /// </summary>
        /// <param name="name">The name of the theme to activate.</param>
        /// <returns>Returns metadata about the activated theme.</returns>
        public async Task<Theme> ActivateThemeAsync(string name)
        {
            var request = PrepareThemeActivationRequest(name);
            var response = await ExecuteAsync<ThemeResponse>(request);
            return response.Themes[0];
        }

        /// <summary>
        /// Prepares a RestRequest for uploading a theme.
        /// </summary>
        /// <param name="theme">The theme to upload.</param>
        /// <returns>A RestRequest that can be used to upload the theme.</returns>
        private RestRequest PrepareThemeUploadRequest(ThemeRequest theme)
        {
            var request = CreateRequest(Method.Post, "themes/upload");

            if (theme.FilePath != null)
                request.AddFile("file", theme.FilePath, "application/zip");
            else
                request.AddFile("file", theme.File, theme.FileName, "application/zip");

            return request;
        }

        /// <summary>
        /// Prepares a RestRequest for activating a theme.
        /// </summary>
        /// <param name="name">The name of the theme to activate.</param>
        /// <returns>A RestRequest that can be used to activate the theme.</returns>
        private RestRequest PrepareThemeActivationRequest(string name)
        {
            var request = CreateRequest(Method.Put, $"themes/{name}/activate")
                .AddUrlSegment("themename", name);

            return request;
        }
    }
}
