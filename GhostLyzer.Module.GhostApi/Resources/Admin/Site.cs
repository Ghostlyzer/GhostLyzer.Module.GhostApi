using GhostLyzer.Module.GhostApi.Models;
using RestSharp;

namespace GhostLyzer.Module.GhostApi.Services
{
    public partial class GhostAdminAPI
    {
        /// <summary>
        /// Retrieve basic information about a site.
        /// </summary>
        /// <returns>Basic information about a site. (i.e. title, version, URL, etc...)</returns>
        public Site GetSite()
        {
            var request = CreateRequest(Method.Get, "site");
            return Execute<SiteResponse>(request).Site;
        }

        /// <summary>
        /// Retrieve basic information about a site async.
        /// </summary>
        /// <returns>Basic information about a site. (i.e. title, version, URL, etc...)</returns>
        public async Task<Site> GetSiteAsync()
        {
            var request = CreateRequest(Method.Get, "site");
            var response = await ExecuteAsync<SiteResponse>(request);
            return response.Site;
        }
    }
}
