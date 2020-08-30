using System;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Client Exception Arguments
    /// </summary>
    public class ClientExceptionArgs : EventArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="exception">Exception</param>
        public ClientExceptionArgs(Exception exception) =>
            Exception = exception;

        /// <summary>
        /// Exception
        /// </summary>
        public Exception Exception { get; set; }
    }
}
