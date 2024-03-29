﻿using Newtonsoft.Json;

namespace GhostLyzer.Module.GhostApi.Models
{
    /// <summary>
    /// Response representing authors and any meta data.
    /// </summary>
    public class AuthorResponse
    {
        /// <summary>
        /// Collection of authors.
        /// </summary>
        [JsonProperty("authors")]
        public List<Author> Authors { get; set; }

        /// <summary>
        /// Meta data regarding the response.
        /// </summary>
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
