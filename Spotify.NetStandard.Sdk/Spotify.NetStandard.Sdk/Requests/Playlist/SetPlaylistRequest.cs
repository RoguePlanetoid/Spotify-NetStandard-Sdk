namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Set Playlist Request
    /// </summary>
    public class SetPlaylistRequest : BasePlaylistRequest
    {
        /// <summary>
        /// (Required) Spotify Playlist Id
        /// </summary>
        public string PlaylistId { get; set; }
    }
}
