using System.Net;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Status Response
    /// </summary>
    public class StatusResponse : BaseResponse
    {
        /// <summary>
        /// Status Code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        public int Code => (int)StatusCode;

        /// <summary>
        /// Success
        /// </summary>
        public bool Success { get; set; }
    }
}
