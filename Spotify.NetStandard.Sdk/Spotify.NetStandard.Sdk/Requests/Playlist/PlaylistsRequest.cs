namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Playlists Request
    /// </summary>
    public class PlaylistsRequest : BaseRequest
    {
        /// <summary>
        /// (Required) Playlist Type 
        /// </summary>
        public PlaylistType PlaylistType { get; set; }

        /// <summary>
        /// (Required) Only for PlaylistType.Search - Playlist Search Term, PlaylistType.Category - Category Id, and PlaylistType.User - User Id
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// (Optional) Only for PlaylistType.Search, If true the response will include any relevant audio content that is hosted externally.
        /// </summary>
        public bool? SearchIsExternal { get; set; }

        /// <summary>
        /// (Optional) Only for PlaylistType.Search, PlaylistType.Featured and PlaylistType.Category - Overrides Client Country as ISO 3166-1 alpha-2 country code e.g. GB
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// (Optional) Only for PlaylistType.Featured - Override Client Locale as ISO 639-1 language code and an ISO 3166-1 alpha-2 country code, joined by an underscore e.g. en_GB
        /// </summary>
        public string Locale { get; set; }
    }
}
