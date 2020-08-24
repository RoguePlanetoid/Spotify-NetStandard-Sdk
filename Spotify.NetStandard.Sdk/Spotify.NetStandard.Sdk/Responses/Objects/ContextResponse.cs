namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Context Response
    /// </summary>
    public class ContextResponse : BaseResponse
    {
        /// <summary>
        /// The object type of the object
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// A link to the Web API endpoint providing full details of the object
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// Known external URLs for this object
        /// </summary>
        public ExternalUrlResponse ExternalUrls { get; set; }

        /// <summary>
        /// The Spotify URI for the object
        /// </summary>
        public string Uri { get; set; }
    }
}
