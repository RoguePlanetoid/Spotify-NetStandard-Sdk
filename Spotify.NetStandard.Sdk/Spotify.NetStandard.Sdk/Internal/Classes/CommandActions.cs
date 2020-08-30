using System;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Command Actions
    /// </summary>
    public class CommandActions
    {
        #region Categories
        /// <summary>
        /// Category Command Action
        /// </summary>
        public Action<CategoryResponse> Category { get; set; }
        #endregion Categories

        #region Artists
        /// <summary>
        /// Artist Command Action
        /// </summary>
        public Action<ArtistResponse> Artist { get; set; }
        #endregion Artists

        #region Albums
        /// <summary>
        /// Album Command Action
        /// </summary>
        public Action<AlbumResponse> Album { get; set; }
        #endregion Albums

        #region Tracks
        /// <summary>
        /// Track Command Action
        /// </summary>
        public Action<TrackResponse> Track { get; set; }
        #endregion Tracks

        #region Audio Analysis
        /// <summary>
        /// Get Audio Analysis Command Action
        /// </summary>
        public Action<TrackResponse> GetAudioAnalysis { get; set; }
        #endregion Audio Analysis

        #region Audio Features
        /// <summary>
        /// Get Audio Features Command Action
        /// </summary>
        public Action<TrackResponse> GetAudioFeatures { get; set; }
        #endregion Audio Features

        #region Playlist
        /// <summary>
        /// Playlist Command Action
        /// </summary>
        public Action<PlaylistResponse> Playlist { get; set; }

        /// <summary>
        /// Upload a Custom Playlist Cover Image Command Action
        /// </summary>
        public Action<PlaylistResponse> SetPlaylistImage { get; set; }

        /// <summary>
        /// Change a Playlist's Details Command Action
        /// </summary>
        public Action<PlaylistResponse> SetPlaylist { get; set; }

        /// <summary>
        /// Get Playlist Image Command Action
        /// </summary>
        public Action<PlaylistImageResponse> GetPlaylistImage { get; set; }
        #endregion Playlist

        #region Playlist Item
        /// <summary>
        /// Add Playlist Item Command Action
        /// </summary>
        public Action<IPlayItemResponse> AddPlaylistItem { get; set; }

        /// <summary>
        /// Remove Playlist Item Command Action
        /// </summary>
        public Action<PlaylistItemResponse> RemovePlaylistItem { get; set; }
        #endregion Playlist Item

        #region Show
        /// <summary>
        /// Show Command Action
        /// </summary>
        public Action<ShowResponse> Show { get; set; }
        #endregion Show

        #region Episode
        /// <summary>
        /// Episode Command Action
        /// </summary>
        public Action<EpisodeResponse> Episode { get; set; }
        #endregion Episode

        #region User
        /// <summary>
        /// User Command Action
        /// </summary>
        public Action<UserResponse> User { get; set; }
        #endregion User

        #region Current User
        /// <summary>
        /// Current User Command Action
        /// </summary>
        public Action<CurrentUserResponse> CurrentUser { get; set; }
        #endregion Current User

        #region Recommendation Genre
        /// <summary>
        /// Recommendation Genre Command Action
        /// </summary>
        public Action<RecommendationGenreResponse> RecommendationGenre { get; set; }
        #endregion Recomendation Genre

        #region Currently Playing
        /// <summary>
        /// Currently Playing Command Action
        /// </summary>
        public Action<CurrentlyPlayingResponse> CurrentlyPlaying { get; set; }
        #endregion Currently Playing

    }
}
