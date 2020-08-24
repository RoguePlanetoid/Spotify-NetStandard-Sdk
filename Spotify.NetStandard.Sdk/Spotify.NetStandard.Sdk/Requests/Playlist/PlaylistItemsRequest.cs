namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Playlist Items Request
    /// </summary>
    public class PlaylistItemsRequest : BaseRequest
    {
        /// <summary>
        /// (Required) Spotify Playlist Id
        /// </summary>
        public string PlaylistId { get; set; }

        /// <summary>
        /// (Optional) Filters for the query: a comma-separated list of the fields to return. If omitted, all fields are returned
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// (Optional) Overrides Client Country as ISO 3166-1 alpha-2 country code e.g. GB
        /// </summary>
        public string Country { get; set; }
    }
}
