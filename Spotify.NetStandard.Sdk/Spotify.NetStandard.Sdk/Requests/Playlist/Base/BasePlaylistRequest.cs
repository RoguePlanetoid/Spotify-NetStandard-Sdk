namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Base Playlist Request
    /// </summary>
    public abstract class BasePlaylistRequest
    {
        /// <summary>
        /// (Required) The new name for the playlist, for example "My New Playlist Title"
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// (Required) Value for playlist description as displayed in Spotify Clients and in the Web API
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// (Optional) If true, the playlist will become collaborative and other users will be able to modify the playlist in their Spotify client. Note: You can only set collaborative to true on non-public playlists
        /// </summary>
        public bool IsCollaborative { get; set; }

        /// <summary>
        /// (Optional) If true the playlist will be public, if false it will be private
        /// </summary>
        public bool IsPublic { get; set; }
    }
}
