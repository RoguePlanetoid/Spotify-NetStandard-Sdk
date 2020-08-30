namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Error Response
    /// </summary>
    public interface IErrorResponse
    {
        /// <summary>
        /// Error Object
        /// </summary>
        ErrorResponse Error { get; set; }

        /// <summary>
        /// Is Success
        /// </summary>
        bool IsSuccess { get; }
    }
}
