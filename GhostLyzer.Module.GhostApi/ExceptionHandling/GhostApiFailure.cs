using GhostLyzer.Module.GhostApi.Models;

namespace GhostLyzer.Module.GhostApi.ExceptionHandling
{
    /// <summary>
    /// Represents a collection of errors returned by the Ghost API.
    /// </summary>
    class GhostApiFailure
    {
        public List<GhostError> Errors { get; set; }
    }
}
