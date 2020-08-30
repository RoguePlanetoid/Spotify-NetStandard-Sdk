namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Error Response
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// The HTTP status code
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// A short description of the cause of the error
        /// </summary>
        public string Message { get; set; }
    }
}
