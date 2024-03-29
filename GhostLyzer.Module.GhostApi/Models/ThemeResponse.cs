﻿using Newtonsoft.Json;

namespace GhostLyzer.Module.GhostApi.Models
{
    /// <summary>
    /// Response representing a theme
    /// </summary>
    public class ThemeResponse
    {
        /// <summary>
        /// Theme
        /// </summary>
        [JsonProperty("themes")]
        public List<Theme> Themes { get; set; }
    }
}
