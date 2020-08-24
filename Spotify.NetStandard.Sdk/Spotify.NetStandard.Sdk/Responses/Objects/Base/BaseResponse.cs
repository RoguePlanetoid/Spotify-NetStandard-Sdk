namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Base Response
    /// </summary>
    public abstract class BaseResponse : IErrorResponse
    {
        /// <summary>
        /// Error Object
        /// </summary>
        public ErrorResponse Error { get; set; }

        /// <summary>
        /// Is Success
        /// </summary>
        public bool IsSuccess => Error == null;
    }
}
