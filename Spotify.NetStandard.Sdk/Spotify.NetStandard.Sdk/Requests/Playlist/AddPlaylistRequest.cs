namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Add Playlist Request
    /// </summary>
    public class AddPlaylistRequest : BasePlaylistRequest
    {
        /// <summary>
        /// (Required) Spotify User Id
        /// </summary>
        public string UserId { get; set; }
    }
}
