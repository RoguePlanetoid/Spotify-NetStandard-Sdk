using AutoMapper;
using Spotify.NetStandard.Client.Interfaces;
using Spotify.NetStandard.Enums;
using Spotify.NetStandard.Responses;
using Spotify.NetStandard.Sdk.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.NetStandard.Sdk.Internal
{
    /// <summary>
    /// Response Extensions
    /// </summary>
    internal static class ResponseExtensions
    {
        #region Private Constants
        private const int zero_percent = 0;
        private const int percentage = 100;
        private const int max_ids = 50;
        #endregion Private Constants

        #region Private Methods
        /// <summary>
        /// Get Favourites
        /// </summary>
        /// <typeparam name="TResponse">Response Type: AlbumResponse, ArtistResponse, TrackResponse, ShowResponse, EpisodeResponse</typeparam>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="itemIds">Item Ids</param>
        /// <param name="total">Total Items</param>
        /// <param name="skip">Skip Items</param>
        /// <param name="take">Take Items</param>
        /// <param name="market">Market</param>
        /// <returns>Navigation Response of Response Type</returns>
        private static async Task<NavigationResponse<TResponse>> GetFavouritesAsync<TResponse>(
            this ISpotifySdkClient client,
            IMapper mapper,
            List<string> itemIds,
            int total,
            int skip,
            int take,
            string market = null)
        {
            NavigationResponse<TResponse> result;
            LookupResponse response;
            switch (typeof(TResponse))
            {
                // Get Favourite Albums
                case Type album when album == typeof(AlbumResponse):
                    response = await client.SpotifyClient.LookupAsync(
                        itemIds: itemIds, LookupType.Albums);
                    result = mapper.MapFromAlbumList(response?.Albums)
                        as NavigationResponse<TResponse>;
                    break;
                // Get Favourite Artists
                case Type artist when artist == typeof(ArtistResponse):
                    response = await client.SpotifyClient.LookupAsync(
                        itemIds: itemIds, LookupType.Artists);
                    result = mapper.MapFromArtistList(response?.Artists)
                        as NavigationResponse<TResponse>;
                    break;
                // Get Favourite Tracks
                case Type track when track == typeof(TrackResponse):
                    response = await client.SpotifyClient.LookupAsync(
                        itemIds: itemIds, LookupType.Tracks);
                    result = mapper.MapFromTrackList(response?.Tracks)
                        as NavigationResponse<TResponse>;
                    break;
                // Get Favourite Shows
                case Type show when show == typeof(ShowResponse):
                    response = await client.SpotifyClient.LookupAsync(
                        itemIds: itemIds, LookupType.Shows, market: market);
                    result = mapper.MapFromShowList(response?.Shows)
                        as NavigationResponse<TResponse>;
                    break;
                // Get Favourite Episodes
                case Type episode when episode == typeof(EpisodeResponse):
                    response = await client.SpotifyClient.LookupAsync(
                        itemIds: itemIds, LookupType.Episodes, market: market);
                    result = mapper.MapFromEpisodeList(response?.Episodes)
                        as NavigationResponse<TResponse>;
                    break;
                // Unsupported Response Type
                default:
                    throw new NotSupportedException();
            }
            if (result != null)
            {
                result.Next = $"offset={skip}&limit={take}";
                result.Total = total;
                result.Offset = skip;
                result.Limit = take;
            }
            return result;
        }

        /// <summary>
        /// Get Favourite Take
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <returns>Take Value</returns>
        private static int GetTake(this ISpotifySdkClient client)
            => (client.Limit == null || client?.Limit > max_ids) ?
            max_ids :
            client.Limit.Value;
        #endregion Private Methods

        #region Public Methods
        /// <summary>
        /// Large Image
        /// </summary>
        /// <param name="images"></param>
        /// <returns></returns>
        public static ImageResponse GetLargeImage(this IList<ImageResponse> images) =>
            images?.OrderByDescending(o => o.Height * o.Width)?.FirstOrDefault();

        /// <summary>
        /// Medium Image
        /// </summary>
        /// <param name="images"></param>
        /// <returns></returns>
        public static ImageResponse GetMediumImage(this IList<ImageResponse> images)
        {
            if (images != null)
            {
                var small = GetSmallImage(images);
                var large = GetLargeImage(images);
                var medium = images.FirstOrDefault
                    (f => f != small || f != large);
                return medium ?? large;
            }
            return null;
        }

        /// <summary>
        /// Small Image
        /// </summary>
        /// <param name="images"></param>
        /// <returns></returns>
        public static ImageResponse GetSmallImage(this IList<ImageResponse> images) =>
            images?.OrderBy(o => o.Height * o.Width)?.FirstOrDefault();

        /// <summary>
        /// Get Artist
        /// </summary>
        /// <param name="artists"></param>
        /// <returns>Artist</returns>
        public static ArtistResponse GetArtist(this IList<ArtistResponse> artists) =>
            artists?.FirstOrDefault();

        /// <summary>
        /// Set Type
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="navigationResponse"></param>
        /// <param name="navigationType">Navigation Type</param>
        /// <param name="responseType">Response Type</param>
        public static void SetTypes<TResponse>(this NavigationResponse<TResponse> navigationResponse, NavigationType navigationType, object responseType)
        {
            if (navigationResponse != null)
            {
                navigationResponse.NavigationType = navigationType;
                navigationResponse.Type = responseType;
            }
        }

        /// <summary>
        /// As TimeSpan
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>TimeSpan</returns>
        public static TimeSpan AsTimeSpan(this long value) =>
            TimeSpan.FromMilliseconds(value);

        /// <summary>
        /// As TimeSpan String
        /// </summary>
        /// <param name="value">TimeSpan</param>
        /// <returns>TimeSpan String</returns>
        public static string AsTimeSpanString(this TimeSpan value) =>
            value.TotalHours > 1
                ? value.ToString(@"hh\:mm")
                : value.ToString(@"mm\:ss");

        /// <summary>
        /// Get Release Year
        /// </summary>
        /// <param name="value">Date String</param>
        /// <returns>Year</returns>
        public static string GetReleaseYear(this string value) =>
            value?.Substring(0, 4);
 
        /// <summary>
        /// Get Current Device Id
        /// </summary>
        /// <param name="devicesResponse"></param>
        /// <returns></returns>
        public static string GetCurrentDeviceId(this NavigationResponse<DeviceResponse> devicesResponse)
            => devicesResponse?.Items?.FirstOrDefault(w => w.IsActive)?.Id;

        /// <summary>
        /// Lookup User Addable Playlists
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <returns>List of Simplified Playlist</returns>
        public static async Task<List<SimplifiedPlaylist>> AuthLookupUserAddablePlaylistsAsync(
            this ISpotifyClient client)
        {
            var results = new List<SimplifiedPlaylist>();
            var user = await client.AuthLookupUserProfileAsync();
            var playlists = await client.AuthLookupUserPlaylistsAsync();
            var loop = playlists?.Next != null;
            do
            {
                if (playlists?.Items != null)
                    results.AddRange(playlists.Items.Where(w => 
                        w.Collaborative || 
                        w.Owner.Id == user.Id));
                if (playlists?.Next != null)
                    playlists = await client.AuthGetAsync<CursorPaging<SimplifiedPlaylist>>(
                        new Uri(playlists.Next));
                else
                    loop = false;
            } 
            while (loop);
            return results;
        }

        /// <summary>
        /// Get Recommendations
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="country">Country</param>
        /// <param name="recommendationRequest">Recommendation Request</param>
        /// <returns>Navigation Response of Track Response</returns>
        public static async Task<NavigationResponse<TrackResponse>> GetRecommendationsAsync(
            this ISpotifyClient client,
            IMapper mapper,
            string country,
            RecommendationRequest recommendationRequest)
        {
            var recommended = await client.LookupRecommendationsAsync(
                seedArtists: recommendationRequest?.SeedArtistIds,
                seedGenres: 
                    Helpers.GetListFromString(recommendationRequest?.SeedGenre) 
                    ?? recommendationRequest?.SeedGenres,
                seedTracks: recommendationRequest?.SeedTrackIds,
                limit: recommendationRequest?.TargetTotal,
                market: country,
                minTuneableTrack: mapper.Map(recommendationRequest?.MinimumTuneableTrack),
                maxTuneableTrack: mapper.Map(recommendationRequest?.MaximumTuneableTrack),
                targetTuneableTrack: mapper.Map(recommendationRequest?.TargetTuneableTrack));
            return mapper.MapFromRecommendationResponse(recommended);
        }

        /// <summary>
        /// Set Playlist Extended Properties
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Playlist Response</param>
        public static void SetPlaylistExtended(this ISpotifySdkClient client, PlaylistResponse response)
        {
            if(response != null)
            {
                client.CurrentPlaylist = response;
                response.IsOwnPlaylist = client.IsPlaylistOwnedByCurrentUser(response);
                response.IsEditable = response.IsOwnPlaylist || response.Collaborative;
            }
        }

        /// <summary>
        /// Sey Playlists Extended
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Navigation Response of Playlist Response</param>
        public static void SetPlaylistsExtended(this ISpotifySdkClient client, NavigationResponse<PlaylistResponse> response)
        {
            if (response?.Items != null)
                response.Items.ForEach(f => client.SetPlaylistExtended(f));
        }

        /// <summary>
        /// Set Current User Extended Properties
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Current User Response</param>
        public static void SetCurrentUserExtended(this ISpotifySdkClient client, CurrentUserResponse response)
        {
            if (response != null)
                client.CurrentUser = response;
        }

        /// <summary>
        /// Set Playlist Image Extended Properties
        /// </summary>
        /// <param name="response">Playlist Image Response</param>
        /// <param name="playlistId">Playlist Id</param>
        public static void SetPlaylistImageExtended(this PlaylistImageResponse response, string playlistId)
        {
            if (response != null)
                response.Id = playlistId;
        }

        /// <summary>
        /// Set Current User Extended Properties
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Current User Response</param>
        public static void SetCurrentlyPlayingExtended(this ISpotifySdkClient client, CurrentlyPlayingResponse response)
        {
            if (response?.Device != null)
                client.CurrentDevice = response.Device;
        }

        /// <summary>
        /// Get Favourites
        /// </summary>
        /// <typeparam name="TResponse">Response Type: AlbumResponse, ArtistResponse, TrackResponse, ShowResponse, EpisodeResponse</typeparam>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="multipleIds">Multiple Ids</param>
        /// <param name="market">Market</param>
        /// <returns>Navigation Response of Response Type</returns>
        public static async Task<NavigationResponse<TResponse>> GetFavouritesAsync<TResponse>(
            this ISpotifySdkClient client, 
            IMapper mapper,
            List<string> multipleIds,
            string market = null)
        {
            if (multipleIds != null)
            {
                var skip = 0;
                var take = client.GetTake();
                var total = multipleIds.Count();
                var itemIds = multipleIds.Skip(skip).Take(take).ToList();
                return await client.GetFavouritesAsync<TResponse>(
                    mapper, itemIds, total, skip, take, market);
            }
            return null;
        }

        /// <summary>
        /// Get Favourites
        /// </summary>
        /// <typeparam name="TResponse">Response Type: AlbumResponse, ArtistResponse, TrackResponse, ShowResponse, EpisodeResponse</typeparam>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="response">Navigation Response of Response Type</param>
        /// <param name="multipleIds">Multiple Ids</param>
        /// <param name="market">Market</param>
        /// <returns>Navigation Response of Response Type</returns>
        public static async Task<NavigationResponse<TResponse>> GetFavouritesAsync<TResponse>(
            this ISpotifySdkClient client,
            IMapper mapper,
            NavigationResponse<TResponse> response,
            List<string> multipleIds,
            string market = null)
        {
            if (response != null && multipleIds != null)
            {
                var take = client.GetTake();
                var total = multipleIds.Count();
                var skip = response.Offset += take;
                var itemIds = multipleIds.Skip(skip).Take(take).ToList();
                return await client.GetFavouritesAsync<TResponse>(
                    mapper, itemIds, total, skip, take, market);
            }
            return null;
        }

        /// <summary>
        /// Get Progress Percentage
        /// </summary>
        /// <param name="response">Episode Response</param>
        /// <returns>Episode Progress</returns>
        public static int GetProgressPercentage(this EpisodeResponse response) =>
            response?.ResumePoint != null ?
                response.ResumePoint.FullyPlayed ?
                percentage :
                (int)((double)response.ResumePoint.ResumePosition / 
                    response.Duration * percentage)
            : zero_percent;
        #endregion Public Methods
    }
}