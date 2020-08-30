namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Context Response
    /// </summary>
    public interface IContextResponse : IErrorResponse
    {
        /// <summary>
        /// The object type of the object
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// A link to the Web API endpoint providing full details of the object
        /// </summary>
        string Href { get; set; }

        /// <summary>
        /// Known external URLs for this object.
        /// </summary>
        ExternalUrlResponse ExternalUrls { get; set; }

        /// <summary>
        /// The Spotify URI for the object
        /// </summary>
        string Uri { get; set; }
    }
}
