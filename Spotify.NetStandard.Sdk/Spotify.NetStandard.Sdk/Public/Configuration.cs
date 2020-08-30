namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Configuration
    /// </summary>
    public class Configuration
    {
        #region Attach Commands
        /// <summary>
        /// Attach Get Category Commands?
        /// </summary>
        public bool IsAttachGetCategoryCommands { get; set; }

        /// <summary>
        /// Attach List Categories Commands?
        /// </summary>
        public bool IsAttachListCategoriesCommands { get; set; }

        /// <summary>
        /// Attach Get Artist Commands?
        /// </summary>
        public bool IsAttachGetArtistCommands { get; set; }

        /// <summary>
        /// Attach List Artists Commands?
        /// </summary>
        public bool IsAttachListArtistsCommands { get; set; }

        /// <summary>
        /// Attach Get Album Commands?
        /// </summary>
        public bool IsAttachGetAlbumCommands { get; set; }

        /// <summary>
        /// Attach List Albums Commands?
        /// </summary>
        public bool IsAttachListAlbumsCommands { get; set; }

        /// <summary>
        /// Attach Get Track Commands?
        /// </summary>
        public bool IsAttachGetTrackCommands { get; set; }

        /// <summary>
        /// Attach List Tracks Commands?
        /// </summary>
        public bool IsAttachListTracksCommands { get; set; }

        /// <summary>
        /// Attach Get Playlist Commands?
        /// </summary>
        public bool IsAttachGetPlaylistCommands { get; set; }

        /// <summary>
        /// Attach List Playlists Commands?
        /// </summary>
        public bool IsAttachListPlaylistsCommands { get; set; }

        /// <summary>
        /// Attach List Playlist Items Commands?
        /// </summary>
        public bool IsAttachListPlaylistItemsCommands { get; set; }

        /// <summary>
        /// Attach Get Show Commands?
        /// </summary>
        public bool IsAttachGetShowCommands { get; set; }

        /// <summary>
        /// Attach List Shows Commands?
        /// </summary>
        public bool IsAttachListShowsCommands { get; set; }

        /// <summary>
        /// Attach Get Episode Commands?
        /// </summary>
        public bool IsAttachGetEpisodeCommands { get; set; }

        /// <summary>
        /// Attach List Episodes Commands?
        /// </summary>
        public bool IsAttachListEpisodesCommands { get; set; }

        /// <summary>
        /// Attach Get Current User Commands?
        /// </summary>
        public bool IsAttachGetCurrentUserCommands { get; set; }

        /// <summary>
        /// Attach Get User Commands?
        /// </summary>
        public bool IsAttachGetUserCommands { get; set; }

        /// <summary>
        /// Attach List Recommendation Genre Commands?
        /// </summary>
        public bool IsAttachListRecommendationGenreCommands { get; set; }

        /// <summary>
        /// Attach List Devices Commands?
        /// </summary>
        public bool IsAttachListDevicesCommands { get; set; }

        /// <summary>
        /// Attach Get Playlist Image Commands?
        /// </summary>
        public bool IsAttachGetPlaylistImageCommands { get; set; }

        /// <summary>
        /// Attach Get User Currently Playing Item Commands?
        /// </summary>
        public bool IsAttachGetUserCurrentlyPlayingItemCommands { get; set; }

        /// <summary>
        /// Attach Get User Currently Playing Commands?
        /// </summary>
        public bool IsAttachGetUserCurrentlyPlayingCommands { get; set; }
        #endregion Attach Commands

        #region Attach Toggles
        /// <summary>
        /// Attach Get Artist Toggles
        /// </summary>
        public bool IsAttachGetArtistToggles { get; set; }

        /// <summary>
        /// Attach List Artists Toggles
        /// </summary>
        public bool IsAttachListArtistsToggles { get; set; }

        /// <summary>
        /// Attach Get Album Toggles
        /// </summary>
        public bool IsAttachGetAlbumToggles { get; set; }

        /// <summary>
        /// Attach List Albums Toggles
        /// </summary>
        public bool IsAttachListAlbumsToggles { get; set; }

        /// <summary>
        /// Attach Get Track Toggles
        /// </summary>
        public bool IsAttachGetTrackToggles { get; set; }

        /// <summary>
        /// Attach List Tracks Toggles
        /// </summary>
        public bool IsAttachListTracksToggles { get; set; }

        /// <summary>
        /// Attach Get Playlist Toggles
        /// </summary>
        public bool IsAttachGetPlaylistToggles { get; set; }

        /// <summary>
        /// Attach Get Show Toggles
        /// </summary>
        public bool IsAttachGetShowToggles { get; set; }

        /// <summary>
        /// Attach List Shows Toggles
        /// </summary>
        public bool IsAttachListShowsToggles { get; set; }

        /// <summary>
        /// Attach Get Episode Toggles
        /// </summary>
        public bool IsAttachGetEpisodeToggles { get; set; }

        /// <summary>
        /// Attach List Episodes Toggles
        /// </summary>
        public bool IsAttachListEpisodesToggles { get; set; }

        /// <summary>
        /// Attach List Episodes Toggles
        /// </summary>
        public bool IsAttachListPlaylistItemsToggles { get; set; }

        /// <summary>
        /// Attach Get User Toggles
        /// </summary>
        public bool IsAttachGetUserToggles { get; set; }
        #endregion Attach Toggles

        #region Attach Track Audio
        /// <summary>
        /// Attach Get Track Audio Analysis
        /// </summary>
        public bool IsAttachGetTrackAudioAnalysis { get; set; }

        /// <summary>
        /// Attach Get Track Audio Features
        /// </summary>
        public bool IsAttachGetTrackAudioFeatures { get; set; }

        /// <summary>
        /// Attach List Tracks Audio Features
        /// </summary>
        public bool IsAttachListTracksAudioFeatures { get; set; }
        #endregion Attach Track Audio
    }
}
