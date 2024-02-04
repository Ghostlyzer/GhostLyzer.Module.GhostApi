﻿using Newtonsoft.Json;

namespace GhostLyzer.Module.GhostApi.Models
{
    /// <summary>
    /// Response representing newsletters
    /// </summary>
    public class NewsletterResponse
    {
        /// <summary>
        /// Represents your publication's newsletters
        /// </summary>
        [JsonProperty("newsletters")]
        public List<Newsletter> Newsletters { get; set; }

        /// <summary>
        /// Meta data regarding the response.
        /// </summary>
        [JsonProperty("meta")]
        public NewsletterMeta Meta { get; set; }
    }
}
