using System;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Response Error Arguments
    /// </summary>
    public class ResponseErrorArgs : EventArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="error">Status</param>
        public ResponseErrorArgs(ErrorResponse error) =>
            Error = error;

        /// <summary>
        /// Error Response
        /// </summary>
        public ErrorResponse Error { get; set; }
    }
}
