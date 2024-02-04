using GhostLyzer.Module.GhostApi.Models;

namespace GhostLyzer.Module.GhostApi.Exceptions
{
    /// <summary>
    /// An exception representing a failure while using the API.
    /// </summary>
    public class GhostApiException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:GhostLyzer.Module.GhostApi.ExceptionHandling.GhostApiException"/> class
        /// with a message.
        /// </summary>
        /// <param name="message">An error message.</param>
        public GhostApiException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:GhostLyzer.Module.GhostApi.ExceptionHandling.GhostApiException"/> class
        /// with a message and exception.
        /// </summary>
        /// <param name="message">An error message.</param>
        /// <param name="innerException">The original exception.</param>
        public GhostApiException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:GhostLyzer.Module.GhostApi.ExceptionHandling.GhostApiException"/> class
        /// with a list of errors, deserialized from the Ghost API response.
        /// </summary>
        /// <param name="errors">A list of Ghost API errors.</param>
        public GhostApiException(List<GhostError> errors)
        {
            message = string.Join(Environment.NewLine, errors);
            this.errors = errors;
        }

        readonly string message;
        /// <summary>
        /// Get a concatenation of all errors, if any, or the underlying Exception message if none.
        /// </summary>
        /// <value>The message.</value>
        public override string Message => message ?? base.Message;

        readonly List<GhostError> errors;

        /// <summary>
        /// Get the list of errors, if any. If no errors, then the list is empty.
        /// </summary>
        /// <value>Returns a list of errors, or an empty list.</value>
        public List<GhostError> Errors => errors ?? [];

        public override string ToString() => Message;
    }
}
