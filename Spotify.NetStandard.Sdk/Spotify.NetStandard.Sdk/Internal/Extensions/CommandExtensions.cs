namespace Spotify.NetStandard.Sdk.Internal
{
    /// <summary>
    /// Attach Command Extension Methods
    /// </summary>
    internal static class CommandExtensions
    {
        #region Private Methods
        /// <summary>
        /// Get Config Value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="overrideValue"></param>
        /// <returns></returns>
        private static bool GetConfig(bool value, bool? overrideValue) => 
            overrideValue != null ? overrideValue.Value : value;
        #endregion Private Methods

        #region Public Methods
        /// <summary>
        /// Attach Get Category Commands
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Artist Response</param>
        /// <param name="overrideIsAttach">Override Is Attach?</param>
        public static void AttachGetCategoryCommands(
            this ISpotifySdkClient client,
            CategoryResponse response,
            bool? overrideIsAttach = null)
        {
            var isAttach = GetConfig(client.Config.IsAttachGetCategoryCommands, overrideIsAttach);
            if (isAttach && response != null)
            {
                // Category Command
                if (client.CommandActions.Category != null)
                    response.Command = new GenericCommand<CategoryResponse>(
                        client.CommandActions.Category);
            }
        }

        /// <summary>
        /// Attach List Categories Commands
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="responses">Category Responses</param>
        public static void AttachListCategoriesCommands(
            this ISpotifySdkClient client,
            NavigationResponse<CategoryResponse> responses)
        {
            if (client.Config.IsAttachListCategoriesCommands && responses?.Items != null)
                responses.Items.ForEach(item => client.AttachGetCategoryCommands(item, client.Config.IsAttachListCategoriesCommands));
        }

        /// <summary>
        /// Attach Get Artist Commands
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Artist Response</param>
        /// <param name="overrideIsAttach">Override Is Attach?</param>
        public static void AttachGetArtistCommands(
            this ISpotifySdkClient client,
            ArtistResponse response,
            bool? overrideIsAttach = null)
        {
            var isAttach = GetConfig(client.Config.IsAttachGetArtistCommands, overrideIsAttach);
            if (isAttach && response != null)
            {
                // Artist Command
                if (client.CommandActions.Artist != null)
                    response.Command = new GenericCommand<ArtistResponse>(
                        client.CommandActions.Artist);
                // Add User Playback Command
                response.AddUserPlaybackCommand = new GenericCommand<IPlaybackResponse>(
                    client.AddUserPlaybackHandler);
            }
        }

        /// <summary>
        /// Attach List Artists Commands
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="responses">Artist Responses</param>
        public static void AttachListArtistsCommands(
            this ISpotifySdkClient client,
            NavigationResponse<ArtistResponse> responses)
        {
            if (client.Config.IsAttachListArtistsCommands && responses?.Items != null)
                responses.Items.ForEach(item => client.AttachGetArtistCommands(item, client.Config.IsAttachListArtistsCommands));
        }

        /// <summary>
        /// Attach Get Album Commands
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Album Response</param>
        /// <param name="overrideIsAttach">Override Is Attach?</param>
        public static void AttachGetAlbumCommands(
            this ISpotifySdkClient client,
            AlbumResponse response,
            bool? overrideIsAttach = null)
        {
            var isAttach = GetConfig(client.Config.IsAttachGetAlbumCommands, overrideIsAttach);
            if (isAttach && response != null)
            {
                // Album Command
                if (client.CommandActions.Album != null)
                    response.Command = new GenericCommand<AlbumResponse>(
                        client.CommandActions.Album);
                // Add User Playback Command
                response.AddUserPlaybackCommand = new GenericCommand<IPlaybackResponse>(
                    client.AddUserPlaybackHandler);
                // Artist Commands
                if (response?.Artists != null)
                    response.Artists.ForEach(item => client.AttachGetArtistCommands(item, isAttach));
                if (response?.Artist != null)
                    client.AttachGetArtistCommands(response?.Artist, isAttach);
                // Track Commands
                if (response?.Tracks?.Items != null)
                    response.Tracks.Items.ForEach(item => client.AttachGetTrackCommands(item, isAttach));
            }
        }

        /// <summary>
        /// Attach Albums Commands
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="responses">Album Responses</param>
        public static void AttachListAlbumsCommands(
            this ISpotifySdkClient client,
            NavigationResponse<AlbumResponse> responses)
        {
            if (client.Config.IsAttachListAlbumsCommands && responses?.Items != null)
                responses.Items.ForEach(item => client.AttachGetAlbumCommands(item, client.Config.IsAttachListAlbumsCommands));
        }

        /// <summary>
        /// Attach Get Track Commands
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Track Response</param>
        /// <param name="overrideIsAttach">Override Is Attach?</param>
        public static void AttachGetTrackCommands(
            this ISpotifySdkClient client,
            TrackResponse response,
            bool? overrideIsAttach = null)
        {
            var isAttach = GetConfig(client.Config.IsAttachGetTrackCommands, overrideIsAttach);
            if (isAttach && response != null)
            {
                // Track Command
                if (client.CommandActions.Track != null)
                    response.Command = new GenericCommand<TrackResponse>(
                        client.CommandActions.Track);
                // Add User Playback Command
                response.AddUserPlaybackCommand = new GenericCommand<IPlaybackResponse>(
                    client.AddUserPlaybackHandler);
                // Add User Playback Queue Command
                response.AddUserPlaybackQueueCommand = new GenericCommand<IPlayItemResponse>(
                    client.AddUserPlaybackQueueHandler);
                // Add Playlist Item Command
                if (client.CommandActions.AddPlaylistItem != null)
                    response.AddPlaylistItemCommand = new GenericCommand<IPlayItemResponse>(
                        client.CommandActions.AddPlaylistItem);
                // Album Commands
                if (response?.Album != null)
                    client.AttachGetAlbumCommands(response.Album, isAttach);
                // Artist Commands
                if (response?.Artists != null)
                    response.Artists.ForEach(item => client.AttachGetArtistCommands(item, isAttach));
                if (response?.Artist != null)
                    client.AttachGetArtistCommands(response?.Artist, isAttach);
            }
        }

        /// <summary>
        /// Attach List Tracks Commands
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="responses">Track Responses</param>
        public static void AttachListTracksCommands(
            this ISpotifySdkClient client,
            NavigationResponse<TrackResponse> responses)
        {
            if (client.Config.IsAttachListTracksCommands && responses?.Items != null)
                responses.Items.ForEach(item => client.AttachGetTrackCommands(item, client.Config.IsAttachListTracksCommands));
        }

        /// <summary>
        /// Attach Get Playlist Command
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Playlist Response</param>
        /// <param name="overrideIsAttach">Override Is Attach?</param>
        public static void AttachGetPlaylistCommands(
            this ISpotifySdkClient client,
            PlaylistResponse response,
            bool? overrideIsAttach = null)
        {
            var isAttach = GetConfig(client.Config.IsAttachGetPlaylistCommands, overrideIsAttach);
            if (isAttach && response != null)
            {
                // Playlist Command
                if (client.CommandActions.Playlist != null)
                    response.Command = new GenericCommand<PlaylistResponse>(
                        client.CommandActions.Playlist);
                // Change a Playlist's Details Command
                if (client.CommandActions.SetPlaylist != null)
                    response.SetPlaylistCommand = new GenericCommand<PlaylistResponse>(
                        client.CommandActions.SetPlaylist);
                // Upload a Custom Playlist Cover Image Command
                if (client.CommandActions.SetPlaylistImage != null)
                    response.SetPlaylistImageCommand = new GenericCommand<PlaylistResponse>(
                        client.CommandActions.SetPlaylistImage);
                // Add User Playback Command
                response.AddUserPlaybackCommand = new GenericCommand<IPlaybackResponse>(
                    client.AddUserPlaybackHandler);
                // User Commands
                client.AttachGetUserCommands(response.Owner, isAttach);
            }
        }

        /// <summary>
        /// Attach List Playlist Commands
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="responses">Playlist Responses</param>
        public static void AttachListPlaylistsCommands(
            this ISpotifySdkClient client,
            NavigationResponse<PlaylistResponse> responses)
        {
            if (client.Config.IsAttachListPlaylistsCommands && responses?.Items != null)
                responses.Items.ForEach(item => client.AttachGetPlaylistCommands(item, client.Config.IsAttachListPlaylistsCommands));
        }

        /// <summary>
        /// Attach Get Playlist Item Commands
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Playlist Item Response</param>
        /// <param name="isAttach">Is Attach?</param>
        public static void AttachGetPlaylistItemCommands(
            this ISpotifySdkClient client,
            PlaylistItemResponse response,
            bool isAttach)
        {
            if (response != null)
            {
                switch (response.PlayItemType)
                {
                    case PlayItemType.Track:
                        // Track Commands
                        client.AttachGetTrackCommands(response.Track, isAttach);
                        break;
                    case PlayItemType.Episode:
                        // Episode Commands
                        client.AttachGetEpisodeCommands(response.Episode, isAttach);
                        break;
                }
                // Remove Playlist Item Command
                if (client.CommandActions.RemovePlaylistItem != null)
                    response.RemovePlaylistItemCommand = new GenericCommand<PlaylistItemResponse>(
                        client.CommandActions.RemovePlaylistItem);
            }
        }

        /// <summary>
        /// Attach List Playlist Items Commands
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="responses">Playlist Responses</param>
        public static void AttachListPlaylistItemsCommands(
            this ISpotifySdkClient client,
            NavigationResponse<PlaylistItemResponse> responses)
        {
            if (client.Config.IsAttachListPlaylistItemsCommands && responses?.Items != null)
                responses.Items.ForEach(item => client.AttachGetPlaylistItemCommands(item, client.Config.IsAttachListPlaylistItemsCommands));
        }

        /// <summary>
        /// Attach Get Show Commands
        /// </summary>
        /// <param name="client">Spotify SDK Client</param>
        /// <param name="response">Show Response</param>
        /// <param name="overrideIsAttach">Override Is Attach?</param>
        public static void AttachGetShowCommands(
            this ISpotifySdkClient client,
            ShowResponse response,
            bool? overrideIsAttach = null)
        {
            var isAttach = GetConfig(client.Config.IsAttachGetShowCommands, overrideIsAttach);
            if (response != null)
            {
                // Show Command
                if (client.CommandActions.Show != null)
                    response.Command = new GenericCommand<ShowResponse>(
                        client.CommandActions.Show);
                // Episode Commands
                if (response?.Episodes?.Items != null)
                    response.Episodes.Items.ForEach(item => client.AttachGetEpisodeCommands(item));
                // Add User Playback Command
                response.AddUserPlaybackCommand = new GenericCommand<IPlaybackResponse>(
                    client.AddUserPlaybackHandler);
            }
        }

        /// <summary>
        /// Attach List Shows Commands
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="responses">Show Responses</param>
        public static void AttachListShowsCommands(
            this ISpotifySdkClient client,
            NavigationResponse<ShowResponse> responses)
        {
            if (client.Config.IsAttachListShowsCommands && responses?.Items != null)
                responses.Items.ForEach(item => client.AttachGetShowCommands(item, client.Config.IsAttachListShowsCommands));
        }

        /// <summary>
        /// Attach Get Episode Commands
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Episode Response</param>
        /// <param name="overrideIsAttach">Override Is Attach?</param>
        public static void AttachGetEpisodeCommands(
            this ISpotifySdkClient client,
            EpisodeResponse response,
            bool? overrideIsAttach = null)
        {
            var isAttach = GetConfig(client.Config.IsAttachGetEpisodeCommands, overrideIsAttach);
            if (response != null)
            {
                // Episode Command
                if (client.CommandActions.Episode != null)
                    response.Command = new GenericCommand<EpisodeResponse>(
                        client.CommandActions.Episode);
                // Add User Playback Command
                response.AddUserPlaybackCommand = new GenericCommand<IPlaybackResponse>(
                    client.AddUserPlaybackHandler);
                // Add User Playback Queue Command
                response.AddUserPlaybackQueueCommand = new GenericCommand<IPlayItemResponse>(
                    client.AddUserPlaybackQueueHandler);
                // Add Playlist Item Command
                if (client.CommandActions.AddPlaylistItem != null)
                    response.AddPlaylistItemCommand = new GenericCommand<IPlayItemResponse>(
                        client.CommandActions.AddPlaylistItem);
                // Show Command
                if (response?.Show != null)
                    client.AttachGetShowCommands(response.Show, isAttach);
            }
        }

        /// <summary>
        /// Attach List Episode Commands
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="responses">Episode Responses</param>
        public static void AttachListEpisodesCommands(
            this ISpotifySdkClient client,
            NavigationResponse<EpisodeResponse> responses)
        {
            if (client.Config.IsAttachListEpisodesCommands && responses?.Items != null)
                responses.Items.ForEach(item => client.AttachGetEpisodeCommands(item, client.Config.IsAttachListEpisodesCommands));
        }

        /// <summary>
        /// Attach Get Current User Commands
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Current User Response</param>
        public static void AttachGetCurrentUserCommands(
            this ISpotifySdkClient client,
            CurrentUserResponse response)
        {
            if (client.Config.IsAttachGetCurrentUserCommands && response != null)
            {
                // Current User Command
                if (client.CommandActions.CurrentUser != null)
                    response.Command = new GenericCommand<CurrentUserResponse>(
                        client.CommandActions.CurrentUser);
            }
        }

        /// <summary>
        /// Attach Get User Commands
        /// </summary>
        /// <param name="client">Spotify SDK Client</param>
        /// <param name="response">User Response</param>
        /// <param name="overrideIsAttach">Override Is Attach?</param>
        public static void AttachGetUserCommands(
            this ISpotifySdkClient client,
            UserResponse response,
            bool? overrideIsAttach = null)
        {
            var isAttach = GetConfig(client.Config.IsAttachGetUserCommands, overrideIsAttach);
            if (response != null)
            {
                // User Command
                if (client.CommandActions.User != null)
                    response.Command = new GenericCommand<UserResponse>(
                        client.CommandActions.User);
            }
        }

        /// <summary>
        /// Attach Get Recommendation Genre Commands
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Recommendation Genre Response</param>
        /// <param name="isAttach">Is Attach?</param>
        public static void AttachGetRecommendationGenreCommands(
            this ISpotifySdkClient client,
            RecommendationGenreResponse response,
            bool isAttach)
        {
            if (isAttach && response != null)
            {
                // Recommendation Genre Command
                if (client.CommandActions.RecommendationGenre != null)
                    response.Command = new GenericCommand<RecommendationGenreResponse>(
                        client.CommandActions.RecommendationGenre);
            }
        }

        /// <summary>
        /// Attach Recommendation Genre Commands
        /// </summary>
        /// <param name="client">Spotify SDK Client</param>
        /// <param name="responses">Navigation Response of Recommendation Genre Response</param>
        public static void AttachListRecommendationGenresCommands(
            this ISpotifySdkClient client,
            NavigationResponse<RecommendationGenreResponse> responses)
        {
            if (client.Config.IsAttachListRecommendationGenreCommands && responses?.Items != null)
                responses.Items.ForEach(item => client.AttachGetRecommendationGenreCommands(item, client.Config.IsAttachListRecommendationGenreCommands));
        }

        /// <summary>
        /// Attach Get Device Commands
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Device Response</param>
        /// <param name="isAttach">Is Attach?</param>
        public static void AttachGetDeviceCommands(
            this ISpotifySdkClient client,
            DeviceResponse response,
            bool isAttach)
        {
            if (isAttach && response != null)
            {
                // Transfer User Playback Command
                response.TransferUserPlaybackCommand = new GenericCommand<DeviceResponse>(
                    client.TransferUserPlaybackHandler);
            }
        }

        /// <summary>
        /// Attach List Devices Commands
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="responses">Navigation Response of Device Response</param>
        public static void AttachListDevicesCommands(
            this ISpotifySdkClient client,
            NavigationResponse<DeviceResponse> responses)
        {
            if (client.Config.IsAttachListDevicesCommands && responses?.Items != null)
                responses.Items.ForEach(item => client.AttachGetDeviceCommands(item, client.Config.IsAttachListDevicesCommands));
        }

        /// <summary>
        /// Attach Get Playlist Image Commands
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Playlist Image Response</param>
        public static void AttachGetPlaylistImageCommands(
            this ISpotifySdkClient client,
            PlaylistImageResponse response)
        {
            if (client.Config.IsAttachGetPlaylistImageCommands && response != null)
            {
                // Get Playlist Image Command
                if (client.CommandActions.GetPlaylistImage != null)
                    response.Command = new GenericCommand<PlaylistImageResponse>(
                        client.CommandActions.GetPlaylistImage);
            }
        }

        /// <summary>
        /// Attach User Currently Playing Item Commands
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Currently Playing Item Response</param>
        /// <param name="overrideIsAttach">Override Is Attach?</param>
        public static void AttachUserCurrentlyPlayingItemCommands(
            this ISpotifySdkClient client,
            CurrentlyPlayingItemResponse response,
            bool? overrideIsAttach = null)
        {
            var isAttach = GetConfig(client.Config.IsAttachGetUserCurrentlyPlayingItemCommands, overrideIsAttach);
            if (isAttach && response != null)
            {
                switch (response.PlayItemType)
                {
                    case PlayItemType.Track:
                        // Track Commands
                        client.AttachGetTrackCommands(response.Track, isAttach);
                        break;
                    case PlayItemType.Episode:
                        // Episode Commands
                        client.AttachGetEpisodeCommands(response.Episode, isAttach);
                        break;
                }
                // Pause a User's Playback
                response.UserPlaybackPauseCommand = new GenericCommand<CurrentlyPlayingResponse>(
                    client.UserPlaybackPauseHandler);
                // Resume a User's Playback
                response.UserPlaybackResumeCommand = new GenericCommand<CurrentlyPlayingResponse>(
                    client.UserPlaybackResumeHandler);
                // Skip User’s Playback To Next Track
                response.UserPlaybackNextCommand = new GenericCommand<CurrentlyPlayingResponse>(
                    client.UserPlaybackNextHandler);
                // Skip User’s Playback To Previous Track
                response.UserPlaybackPreviousCommand = new GenericCommand<CurrentlyPlayingResponse>(
                    client.UserPlaybackPreviousHandler);
            }
        }

        /// <summary>
        /// Attach Get User Currently Playing Commands
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Currently Playing Response</param>
        public static void AttachGetUserCurrentlyPlayingCommands(
            this ISpotifySdkClient client,
            CurrentlyPlayingResponse response)
        {
            var isAttach = client.Config.IsAttachGetUserCurrentlyPlayingCommands;
            if (isAttach && response != null)
            {
                // Attach User Currently Playing Item Commands
                client.AttachUserCurrentlyPlayingItemCommands(response, isAttach);
                // Attach Device Commands
                client.AttachGetDeviceCommands(response.Device, isAttach);
                // Toggle Shuffle For User’s Playback
                response.UserPlaybackShuffleCommand = new GenericCommand<CurrentlyPlayingResponse>(
                    client.UserPlaybackShuffleHandler);
                // Set Repeat Mode On User’s Playback
                response.UserPlaybackRepeatCommand = new GenericCommand<CurrentlyPlayingResponse>(
                    client.UserPlaybackRepeatHandler);
                // Set Repeat Off For User’s Playback
                response.UserPlaybackRepeatOffCommand = new GenericCommand<CurrentlyPlayingResponse>(
                    client.UserPlaybackRepeatOffHandler);
                // Set Repeat Track For User’s Playback
                response.UserPlaybackRepeatTrackCommand = new GenericCommand<CurrentlyPlayingResponse>(
                    client.UserPlaybackRepeatTrackHandler);
                // Set Repeat Context For User’s Playback
                response.UserPlaybackRepeatContextCommand = new GenericCommand<CurrentlyPlayingResponse>(
                    client.UserPlaybackRepeatContextHandler);
                // Set Seek For User's Playback
                response.UserPlaybackSeekCommand = new GenericCommand<int>(
                    client.UserPlaybackSeekHandler);
                // Set Volume For User's Playback
                response.UserPlaybackVolumeCommand = new GenericCommand<int>(
                    client.UserPlaybackVolumeHandler);
            }
        }
        #endregion Public Methods
    }
}
