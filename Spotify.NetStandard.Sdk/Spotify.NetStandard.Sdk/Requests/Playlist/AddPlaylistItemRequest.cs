namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Add Playlist Item Request
    /// </summary>
    public class AddPlaylistItemRequest
    {
        /// <summary>
        /// Track or Episode
        /// </summary>
        public PlayItemType PlayItemType { get; set; }

        /// <summary>
        /// Spotify Track or Episode Id
        /// </summary>
        public string Id { get; set; }
    }
}
