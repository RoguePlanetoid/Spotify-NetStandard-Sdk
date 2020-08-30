namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Configuration Extension Methods
    /// </summary>
    public static class ConfigExtensions
    {
        #region Attach Commands
        /// <summary>
        /// Attach All Get Commands
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public static void AttachAllGetCommands(this Configuration configuration)
        {
            configuration.IsAttachGetCategoryCommands = true;
            configuration.IsAttachGetAlbumCommands = true;
            configuration.IsAttachGetArtistCommands = true;
            configuration.IsAttachGetAlbumCommands = true;
            configuration.IsAttachGetTrackCommands = true;
            configuration.IsAttachGetPlaylistCommands = true;
            configuration.IsAttachGetShowCommands = true;
            configuration.IsAttachGetEpisodeCommands = true;
            configuration.IsAttachGetCurrentUserCommands = true;
            configuration.IsAttachGetUserCommands = true;
            configuration.IsAttachGetPlaylistImageCommands = true;
            configuration.IsAttachGetUserCurrentlyPlayingItemCommands = true;
            configuration.IsAttachGetUserCurrentlyPlayingCommands = true;
        }

        /// <summary>
        /// Attach All List Commands
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public static void AttachAllListCommands(this Configuration configuration)
        {
            configuration.IsAttachListCategoriesCommands = true;
            configuration.IsAttachListArtistsCommands = true;
            configuration.IsAttachListAlbumsCommands = true;
            configuration.IsAttachListTracksCommands = true;
            configuration.IsAttachListPlaylistsCommands = true;
            configuration.IsAttachListPlaylistItemsCommands = true;
            configuration.IsAttachListShowsCommands = true;
            configuration.IsAttachListEpisodesCommands = true;
            configuration.IsAttachListRecommendationGenreCommands = true;
            configuration.IsAttachListDevicesCommands = true;
        }

        /// <summary>
        /// Attach All Commands
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public static void AttachAllCommands(this Configuration configuration)
        {
            configuration.AttachAllGetCommands();
            configuration.AttachAllListCommands();
        }
        #endregion Attach Commands

        #region Attach Toggles
        /// <summary>
        /// Attach All Get Toggles
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public static void AttachAllGetToggles(this Configuration configuration)
        {
            configuration.IsAttachGetArtistToggles = true;
            configuration.IsAttachGetAlbumToggles = true;
            configuration.IsAttachGetTrackToggles = true;
            configuration.IsAttachGetPlaylistToggles = true;
            configuration.IsAttachGetShowToggles = true;
            configuration.IsAttachGetEpisodeToggles = true;
            configuration.IsAttachGetUserToggles = true;
        }

        /// <summary>
        /// Attach All Get Toggles
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public static void AttachAllListToggles(this Configuration configuration)
        {
            configuration.IsAttachListArtistsToggles = true;
            configuration.IsAttachListAlbumsToggles = true;
            configuration.IsAttachListTracksToggles = true;
            configuration.IsAttachListShowsToggles = true;
            configuration.IsAttachListEpisodesToggles = true;
            configuration.IsAttachListPlaylistItemsToggles = true;
        }

        /// <summary>
        /// Attach All Toggles
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public static void AttachAllToggles(this Configuration configuration)
        {
            configuration.AttachAllGetToggles();
            configuration.AttachAllListToggles();
        }
        #endregion Attach Toggles

        #region Attach Track Audio
        /// <summary>
        /// Attach All Get Track Audio
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public static void AttachAllGetTrackAudio(this Configuration configuration)
        {
            configuration.IsAttachGetTrackAudioAnalysis = true;
            configuration.IsAttachGetTrackAudioFeatures = true;
        }

        /// <summary>
        /// Attach All Get Track Audio
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public static void AttachAllListTrackAudio(this Configuration configuration)
        {
            configuration.IsAttachListTracksAudioFeatures = true;
        }

        /// <summary>
        /// Attach All Track Audio
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public static void AttachAllTrackAudio(this Configuration configuration)
        {
            configuration.AttachAllGetTrackAudio();
            configuration.AttachAllListTrackAudio();
        }
        #endregion Attach Track Audio

        #region Public Methods
        /// <summary>
        /// Attach All
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public static void AttachAll(this Configuration configuration)
        {
            configuration.AttachAllCommands();
            configuration.AttachAllToggles();
            configuration.AttachAllTrackAudio();
        }
        #endregion Public Methods
    }
}
