﻿using Newtonsoft.Json;

namespace GhostLyzer.Module.GhostApi.Models
{
    /// <summary>
    /// Holds meta information about the request, such as the 'page' of data that was requested.
    /// </summary>
    public class Meta
    {
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}
