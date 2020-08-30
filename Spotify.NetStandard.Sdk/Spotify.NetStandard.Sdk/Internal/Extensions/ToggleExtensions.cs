using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.NetStandard.Sdk.Internal
{
    /// <summary>
    /// Toggle Extensions
    /// </summary>
    internal static class ToggleExtensions
    {
        #region Private Constants
        private const int max_toggles = 50;
        #endregion Private Constants

        #region Private Methods
        /// <summary>
        /// Attach Tracks Toggles
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="list">List of Track Response</param>
        private async static Task AttachTracksToggles(
            this ISpotifySdkClient client,
            List<TrackResponse> list)
        {
            if (list != null)
            {
                foreach(var batch in list.Batch(max_toggles))
                {
                    var multipleIds = batch.Select(s => s.Id).ToList();
                    // Toggle Favourites
                    var toggleFavourites = await client.ListTogglesAsync(
                        ToggleType.Favourites,
                        multipleIds,
                        null,
                        (byte)FavouriteType.Track);
                    if (toggleFavourites != null)
                    {
                        var index = 0;
                        foreach(var item in batch)
                        {
                            item.ToggleFavourite = toggleFavourites[index];
                            index++;
                        }
                    }
                    // Toggle Saved
                    var toggleSaved = await client.ListTogglesAsync(
                        ToggleType.Saved,
                        multipleIds,
                        null,
                        (byte)SavedType.Track);
                    if (toggleSaved != null)
                    {
                        var index = 0;
                        foreach (var item in batch)
                        {
                            item.ToggleSaved = toggleSaved[index];
                            index++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Attach Episodes Toggles
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="list">List of Track Response</param>
        private async static Task AttachEpisodesToggles(
            this ISpotifySdkClient client,
            List<EpisodeResponse> list)
        {
            if (list != null)
            {
                foreach (var batch in list.Batch(max_toggles))
                {
                    var multipleIds = batch.Select(s => s.Id).ToList();
                    // Toggle Favourites
                    var toggleFavourites = await client.ListTogglesAsync(
                    ToggleType.Favourites,
                    multipleIds,
                    null,
                    (byte)FavouriteType.Episode);
                    if (toggleFavourites != null)
                    {
                        var index = 0;
                        foreach (var item in batch)
                        {
                            item.ToggleFavourite = toggleFavourites[index];
                            index++;
                        }
                    }
                }
            }
        }
        #endregion Private Methods

        #region Public Methods
        /// <summary>
        /// Attach Get Artist Toggle
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Artist Response</param>
        public async static Task AttachGetArtistToggles(
            this ISpotifySdkClient client,
            ArtistResponse response)
        {
            if (client.Config.IsAttachGetArtistToggles && response != null)
            {
                // Toggle Favourites
                response.ToggleFavourite = await client.GetToggleAsync(
                    ToggleType.Favourites, response.Id, (byte)FavouriteType.Artist);
                // Toggle Follow
                response.ToggleFollow = await client.GetToggleAsync(
                    ToggleType.Follow, response.Id, (byte)FollowType.Artist);
            }
        }

        /// <summary>
        /// Attach List Artists Toggles
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Navigation Response of Artist Response</param>
        public async static Task AttachListArtistsToggles(
            this ISpotifySdkClient client,
            NavigationResponse<ArtistResponse> response)
        {
            if (client.Config.IsAttachListArtistsToggles && response?.Items != null)
            {
                foreach (var batch in response.Items.Batch(max_toggles))
                {
                    var multipleIds = batch.Select(s => s.Id).ToList();
                    // Toggle Favourites
                    var toggleFavourites = await client.ListTogglesAsync(
                        ToggleType.Favourites,
                        multipleIds,
                        null,
                        (byte)FavouriteType.Artist);
                    if (toggleFavourites != null)
                    {
                        int index = 0;
                        foreach(var item in batch)
                        {
                            item.ToggleFavourite = toggleFavourites[index];
                            index++;
                        }
                    }
                    // Toggle Follow
                    var toggleFollow = await client.ListTogglesAsync(
                        ToggleType.Follow,
                        multipleIds,
                        null,
                        (byte)FollowType.Artist);
                    if (toggleFollow != null)
                    {
                        int index = 0;
                        foreach (var item in batch)
                        {
                            item.ToggleFollow = toggleFollow[index];
                            index++;
                        }
                    }
                }          
            }
        }

        /// <summary>
        /// Attach Get Album Toggles
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Album Response</param>
        public static async Task AttachGetAlbumToggles(
            this ISpotifySdkClient client,
            AlbumResponse response)
        {
            if (client.Config.IsAttachGetAlbumToggles && response != null)
            {
                // Toggle Favourites
                response.ToggleFavourite = await client.GetToggleAsync(
                    ToggleType.Favourites, response.Id, (byte)FavouriteType.Album);
                // Toggle Saved
                response.ToggleSaved = await client.GetToggleAsync(
                    ToggleType.Saved, response.Id, (byte)SavedType.Album);
            }
        }

        /// <summary>
        /// Attach List Albums Toggles
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Navigation Response of Album Response</param>
        public async static Task AttachListAlbumsToggles(
            this ISpotifySdkClient client,
            NavigationResponse<AlbumResponse> response)
        {
            if (client.Config.IsAttachListAlbumsToggles && response?.Items != null)
            {
                foreach (var batch in response.Items.Batch(max_toggles))
                {
                    var multipleIds = batch.Select(s => s.Id).ToList();
                    // Toggle Favourites
                    var toggleFavourites = await client.ListTogglesAsync(
                    ToggleType.Favourites,
                    multipleIds,
                    null,
                    (byte)FavouriteType.Album);
                    if (toggleFavourites != null)
                    {
                        var index = 0;
                        foreach (var item in batch)
                        {
                            item.ToggleFavourite = toggleFavourites[index];
                            index++;
                        }
                    }
                    // Toggle Saved
                    var toggleSaved = await client.ListTogglesAsync(
                        ToggleType.Saved,
                        multipleIds,
                        null,
                        (byte)SavedType.Album);
                    if (toggleSaved != null)
                    {
                        var index = 0;
                        foreach (var item in batch)
                        {
                            item.ToggleSaved = toggleSaved[index];
                            index++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Attach Get Track Toggles
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Track Response</param>
        public static async Task AttachGetTrackToggles(
            this ISpotifySdkClient client,
            TrackResponse response)
        {
            if (client.Config.IsAttachGetTrackToggles && response != null)
            {
                // Toggle Favourites
                response.ToggleFavourite = await client.GetToggleAsync(
                ToggleType.Favourites, response.Id, (byte)FavouriteType.Track);
                // Toggle Saved
                response.ToggleSaved = await client.GetToggleAsync(
                    ToggleType.Saved, response.Id, (byte)SavedType.Track);
            }
        }

        /// <summary>
        /// Attach List Tracks Toggles
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Navigation Response of Track Response</param>
        public async static Task AttachListTracksToggles(
            this ISpotifySdkClient client,
            NavigationResponse<TrackResponse> response)
        {
            if (client.Config.IsAttachListTracksToggles && response?.Items != null)
                await client.AttachTracksToggles(response.Items);
        }

        /// <summary>
        /// Attach Get Playlist Toggles
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Playlist Response</param>
        public static async Task AttachGetPlaylistToggles(
            this ISpotifySdkClient client,
            PlaylistResponse response)
        {
            if (client.Config.IsAttachGetPlaylistToggles && response != null)
            {
                // Toggle Follow
                response.ToggleFollow = await client.GetToggleAsync(
                    ToggleType.Follow, response.Id, (byte)FollowType.Playlist);
            }
        }

        /// <summary>
        /// Attach Get Show Toggles
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Show Response</param>
        public static async Task AttachGetShowToggles(
            this ISpotifySdkClient client,
            ShowResponse response)
        {
            if (client.Config.IsAttachGetShowToggles && response != null)
            {
                // Toggle Favourites
                response.ToggleFavourite = await client.GetToggleAsync(
                    ToggleType.Favourites, response.Id, (byte)FavouriteType.Show);
                // Toggle Saved
                response.ToggleSaved = await client.GetToggleAsync(
                    ToggleType.Saved, response.Id, (byte)SavedType.Show);
            }
        }

        /// <summary>
        /// Attach List Shows Toggles
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Navigation Response of Show Response</param>
        public async static Task AttachListShowsToggles(
            this ISpotifySdkClient client,
            NavigationResponse<ShowResponse> response)
        {
            if (client.Config.IsAttachListShowsToggles && response?.Items != null)
            {
                foreach (var batch in response.Items.Batch(max_toggles))
                {
                    var multipleIds = batch.Select(s => s.Id).ToList();
                    // Toggle Favourites
                    var toggleFavourites = await client.ListTogglesAsync(
                    ToggleType.Favourites,
                    multipleIds,
                    null,
                    (byte)FavouriteType.Show);
                    if (toggleFavourites != null)
                    {
                        var index = 0;
                        foreach (var item in batch)
                        {
                            item.ToggleFavourite = toggleFavourites[index];
                            index++;
                        }
                    }
                    // Toggle Saved
                    var toggleSaved = await client.ListTogglesAsync(
                        ToggleType.Saved,
                        multipleIds,
                        null,
                        (byte)SavedType.Show);
                    if (toggleSaved != null)
                    {
                        var index = 0;
                        foreach (var item in batch)
                        {
                            item.ToggleSaved = toggleSaved[index];
                            index++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Attach Get Episode Toggles
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Show Response</param>
        public static async Task AttachGetEpisodeToggles(
            this ISpotifySdkClient client,
            EpisodeResponse response)
        {
            if (client.Config.IsAttachGetEpisodeToggles && response != null)
            {
                // Toggle Favourites
                response.ToggleFavourite = await client.GetToggleAsync(
                    ToggleType.Favourites, response.Id, (byte)FavouriteType.Episode);
            }
        }

        /// <summary>
        /// Attach List Episodes Toggles
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Navigation Response of Episode Response</param>
        public async static Task AttachListEpisodesToggles(
            this ISpotifySdkClient client,
            NavigationResponse<EpisodeResponse> response)
        {
            if(client.Config.IsAttachListEpisodesToggles && response?.Items != null)
                await client.AttachEpisodesToggles(response.Items);
        }

        /// <summary>
        /// Attach List Playlist Item Toggles
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Navigation Response of Play Item Response</param>
        public async static Task AttachListPlaylistItemsToggles(
            this ISpotifySdkClient client,
            NavigationResponse<PlaylistItemResponse> response)
        {
            if(client.Config.IsAttachListPlaylistItemsToggles && response != null)
            {
                // Track Toggles
                var tracks = response?.Items?
                    .Where(w => w.Track != null)?
                    .Select(s => s.Track)?
                    .ToList();
                await client.AttachTracksToggles(tracks);
                // Episode Toggles
                var episodes = response?.Items?
                    .Where(w => w.Episode != null)?
                    .Select(s => s.Episode)?
                    .ToList();
                await client.AttachEpisodesToggles(episodes);
            }
        }

        /// <summary>
        /// Attach Get User Toggles
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">User Response</param>
        public async static Task AttachGetUserToggles(
            this ISpotifySdkClient client,
            UserResponse response)
        {
            if (client.Config.IsAttachGetUserToggles && response != null)
            {
                // Toggle Follow
                response.ToggleFollow = await client.GetToggleAsync(
                    ToggleType.Follow, response.Id, (byte)FollowType.User);
            }
        }
        #endregion Public Methods
    }
}
