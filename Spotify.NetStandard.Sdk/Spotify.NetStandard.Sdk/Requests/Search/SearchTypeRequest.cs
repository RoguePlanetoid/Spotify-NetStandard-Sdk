namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Search Type Request
    /// </summary>
    public class SearchTypeRequest
    {
        /// <summary>
        /// Album
        /// </summary>
        public bool? Album { get; set; }

        /// <summary>
        /// Artist
        /// </summary>
        public bool? Artist { get; set; }

        /// <summary>
        /// Playlist
        /// </summary>
        public bool? Playlist { get; set; }

        /// <summary>
        /// Track
        /// </summary>
        public bool? Track { get; set; }

        /// <summary>
        /// Show
        /// </summary>
        public bool? Show { get; set; }

        /// <summary>
        /// Episode
        /// </summary>
        public bool? Episode { get; set; }
    }
}
