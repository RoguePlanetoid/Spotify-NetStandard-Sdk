namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Search Response
    /// </summary>
    public class SearchResponse : BaseResponse
    {
        /// <summary>
        /// Albums
        /// </summary>
        public NavigationResponse<AlbumResponse> Albums { get; set; }

        /// <summary>
        /// Artist
        /// </summary>
        public NavigationResponse<ArtistResponse> Artists { get; set; }

        /// <summary>
        /// Playlist
        /// </summary>
        public NavigationResponse<PlaylistResponse> Playlists { get; set; }

        /// <summary>
        /// Track
        /// </summary>
        public NavigationResponse<TrackResponse> Tracks { get; set; }

        /// <summary>
        /// Show
        /// </summary>
        public NavigationResponse<ShowResponse> Shows { get; set; }

        /// <summary>
        /// Episode
        /// </summary>
        public NavigationResponse<EpisodeResponse> Episodes { get; set; }
    }
}
