﻿using Newtonsoft.Json;

namespace GhostLyzer.Module.GhostApi.Models
{
    /// <summary>
    /// Response from Ghost, representing posts and any meta data
    /// </summary>
    public class PostResponse
    {
        /// <summary>
        /// Collection of posts.
        /// </summary>
        [JsonProperty("posts")]
        public List<Post> Posts { get; set; }

        /// <summary>
        /// Meta data regarding the response.
        /// </summary>
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
