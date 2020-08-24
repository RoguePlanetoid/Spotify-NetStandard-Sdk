using System;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Status Failed Arguments
    /// </summary>
    public class StatusFailedArgs : EventArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="status">Status</param>
        public StatusFailedArgs(StatusResponse status) =>
            Status = status;

        /// <summary>
        /// Status Response
        /// </summary>
        public StatusResponse Status { get; set; }
    }
}
