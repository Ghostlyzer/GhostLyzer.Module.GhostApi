﻿using Newtonsoft.Json;

namespace GhostLyzer.Module.GhostApi.Models
{
    /// <summary>
    /// Response representing tags and any meta data.
    /// </summary>
    public class TagResponse
    {
        /// <summary>
        /// Collection of tags.
        /// </summary>
        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }

        /// <summary>
        /// Meta data regarding the response.
        /// </summary>
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
