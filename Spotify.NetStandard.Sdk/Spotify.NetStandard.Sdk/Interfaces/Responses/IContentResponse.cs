namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Content Response
    /// </summary>
    public interface IContentResponse : IContextResponse
    {
        /// <summary>
        /// The base-62 identifier that you can find at the end of the Spotify URI for the object
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// The name of the content
        /// </summary>
        string Name { get; set; }
    }
}
