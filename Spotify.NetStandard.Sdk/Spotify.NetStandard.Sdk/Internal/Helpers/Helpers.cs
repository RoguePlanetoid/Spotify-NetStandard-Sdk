using Spotify.NetStandard.Enums;
using Spotify.NetStandard.Requests;
using Spotify.NetStandard.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Spotify.NetStandard.Sdk.Internal
{
    internal static class Helpers
    {
        #region Private Readonly Members
        private static readonly string[] audio_features_keys = { "C", "C♯", "D", "D♯", "E", "F", "F♯", "G", "G♯", "A", "A♯", "B" };
        private static readonly string[] audio_features_meter = { "1/4", "2/4", "3/4", "4/4", "5/4", "6/4", "7/4" };
        #endregion Private Readonly Members

        #region Public Methods
        /// <summary>
        /// Get List from String
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static List<string> GetListFromString(string value) =>
            !string.IsNullOrEmpty(value) ? new List<string> { value } : null;

        /// <summary>
        /// Get Page From Limit
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static Page GetPageFromLimit(int? limit) => 
            limit != null ? new Page() { Limit = limit.Value } : null;

        /// <summary>
        /// Get Page from Navigation Request
        /// </summary>
        /// <param name="navigationRequest">Navigation Request</param>
        /// <returns>Page</returns>
        public static Page GetPageFromNavigationRequest(NavigationRequest navigationRequest)
            => navigationRequest != null ? new Page()
            {
                Offset = navigationRequest.Offset,
                Limit = navigationRequest.Limit
            } : null;

        /// <summary>
        /// Get Page
        /// </summary>
        /// <param name="navigationRequest">Navigation Request</param>
        /// <param name="limit">Limit</param>
        /// <returns>Page</returns>
        public static Page GetPage(NavigationRequest navigationRequest, int? limit) =>
            navigationRequest != null ? 
            GetPageFromNavigationRequest(navigationRequest) : 
            GetPageFromLimit(limit);

        /// <summary>
        /// Get Cursor From Limit
        /// </summary>
        /// <param name="limit">Limit</param>
        /// <returns>Cursor</returns>
        public static Cursor GetCursorFromLimit(int? limit) =>
            limit != null ? new Cursor() { Limit = limit.Value } : null;

        /// <summary>
        /// Get Cursor from Navigation Request
        /// </summary>
        /// <param name="navigationRequest">Navigation Request</param>
        /// <returns>Cursor</returns>
        public static Cursor GetCursorFromNavigationRequest(NavigationRequest navigationRequest)
            => navigationRequest != null ? new Cursor()
            {
                Offset = navigationRequest.Offset,
                Limit = navigationRequest.Limit
            } : null;

        /// <summary>
        /// Get Cursor
        /// </summary>
        /// <param name="navigationRequest">Navigation Request</param>
        /// <param name="limit">Limit</param>
        /// <returns>Cursor</returns>
        public static Cursor GetCursor(NavigationRequest navigationRequest, int? limit) =>
            navigationRequest != null ? 
            GetCursorFromNavigationRequest(navigationRequest) : 
            GetCursorFromLimit(limit);

        /// <summary>
        /// Get User Top Time
        /// </summary>
        /// <param name="userTopTimeRangeType">User Top Time Range </param>
        /// <returns></returns>
        public static TimeRange? GetUserTopTimeRange(UserTopTimeRangeType? userTopTimeRangeType)
            => userTopTimeRangeType != null ? 
            (TimeRange)(userTopTimeRangeType) : 
            (TimeRange?)null;

        /// <summary>
        /// Get Api Follow Type
        /// </summary>
        /// <param name="followType">Follow Type</param>
        /// <returns></returns>
        public static Enums.FollowType GetApiFollowType(FollowType followType)
        {
            switch(followType)
            {
                case FollowType.Artist:
                    return Enums.FollowType.Artist;
                case FollowType.User:
                    return Enums.FollowType.User;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
            
        /// <summary>
        /// Get Search Type
        /// </summary>
        /// <param name="artist"></param>
        /// <param name="album"></param>
        /// <param name="track"></param>
        /// <param name="playlist"></param>
        /// <param name="show"></param>
        /// <param name="episode"></param>
        /// <returns></returns>
        public static SearchType GetSearchType(
            bool artist = false, bool album = false,
            bool track = false, bool playlist = false,
            bool show = false, bool episode = false) =>
            new SearchType()
            {
                Album = album,
                Artist = artist,
                Track = track,
                Playlist = playlist,
                Show = show,
                Episode = episode
            };

        /// <summary>
        /// Search Albums
        /// </summary>
        /// <returns></returns>
        public static SearchType SearchAlbums() => 
            GetSearchType(album: true);

        /// <summary>
        /// Search Artists
        /// </summary>
        /// <returns></returns>
        public static SearchType SearchArtists() => 
            GetSearchType(artist: true);

        /// <summary>
        /// Search Tracks
        /// </summary>
        /// <returns></returns>
        public static SearchType SearchTracks() => 
            GetSearchType(track: true);

        /// <summary>
        /// Search Playlists
        /// </summary>
        /// <returns></returns>
        public static SearchType SearchPlaylists() => 
            GetSearchType(playlist: true);

        /// <summary>
        /// Search Shows
        /// </summary>
        /// <returns></returns>
        public static SearchType SearchShows() => 
            GetSearchType(show: true);

        /// <summary>
        /// Search Episodes
        /// </summary>
        /// <returns></returns>
        public static SearchType SearchEpisodes() => 
            GetSearchType(episode: true);

        /// <summary>
        /// Search All
        /// </summary>
        /// <returns></returns>
        public static SearchType SearchAll() => 
            GetSearchType(
            artist: true, album: true, 
            track: true, playlist: true, 
            show: true, episode: true);

        /// <summary>
        /// Get Devices Request
        /// </summary>
        /// <param name="deviceId">Device Id</param>
        /// <param name="play">True to Ensure Playback, False to maintain current Playback State</param>
        /// <returns>Devices Request</returns>
        public static DevicesRequest GetDevicesRequest(
            string deviceId, bool? 
            play = null) =>
            new DevicesRequest() { DeviceIds = new List<string> { deviceId }, Play = play };

        /// <summary>
        /// Get Navigation Type
        /// </summary>
        /// <param name="navigationType">Navigation Type</param>
        /// <returns>Navigate Type</returns>
        public static NavigateType GetNavigationType(NavigationType navigationType) =>
            (NavigateType)(navigationType);

        /// <summary>
        /// Is Navigation Valid
        /// </summary>
        /// <typeparam name="TResponse">Response Type</typeparam>
        /// <param name="navigationResponse">Navigation Response</param>
        /// <param name="navigateType">Navigate Type</param>
        /// <returns>True if Valid, False if Not</returns>
        public static bool IsNavigationValid<TResponse>(
            NavigationResponse<TResponse> navigationResponse, 
            NavigateType navigateType)
        {
            switch (navigateType)
            {
                case NavigateType.Previous:
                    return navigationResponse.Back != null;
                case NavigateType.Next:
                    return navigationResponse.Next != null;
                default:
                    return navigationResponse.Href != null;
            }
        }

        /// <summary>
        /// Get Uri
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="id">Spotify Id</param>
        /// <returns></returns>
        private static string GetUri(string type, string id) =>
            $"spotify:{type}:{id}";

        /// <summary>
        /// Get Artist Uri
        /// </summary>
        /// <param name="id">Spotify Id</param>
        /// <returns></returns>
        private static string GetArtistUri(string id) =>
            GetUri("artist", id);

        /// <summary>
        /// Get Album Uri
        /// </summary>
        /// <param name="id">Spotify Id</param>
        /// <returns></returns>
        private static string GetAlbumUri(string id) =>
            GetUri("album", id);

        /// <summary>
        /// Get Playlist Uri
        /// </summary>
        /// <param name="id">Spotify Id</param>
        /// <returns></returns>
        private static string GetPlaylistUri(string id) =>
            GetUri("playlist", id);

        /// <summary>
        /// Get Track Uri
        /// </summary>
        /// <param name="id">Spotify Id</param>
        /// <returns></returns>
        private static string GetTrackUri(string id) =>
            GetUri("track", id);

        /// <summary>
        /// Get Episode Uri
        /// </summary>
        /// <param name="id">Spotify Id</param>
        /// <returns></returns>
        private static string GetEpisodeUri(string id) =>
            GetUri("episode", id);

        /// <summary>
        /// Get Show Uri
        /// </summary>
        /// <param name="id">Spotify Id</param>
        /// <returns></returns>
        private static string GetShowUri(string id) =>
            GetUri("show", id);

        /// <summary>
        /// Get Playback Start Request
        /// </summary>
        /// <param name="playbackStartType">Playlist Start Type</param>
        /// <param name="id">Spotify Id</param>
        /// <param name="position">(Optional) Indicates from what position to start playback. Must be a positive number. Passing in a position that is greater than the length of the track will cause the player to start playing the next song.</param>
        /// <param name="offsetId">(Optional) Only available for PlaybackStartType.Album, PlaybackStartType.Artist and PlaybackStartType.Playlist. Only use either Position or OffsetId. Offset Id indicates from where in the context playback should start.</param>
        /// <returns>Playback Request</returns>
        /// <exception cref="ArgumentException">Thrown when Position and OffsetId are Provided</exception>
        public static PlaybackRequest GetPlaybackStartRequest(
            PlaybackStartType playbackStartType, 
            string id, 
            int? position = null,
            string offsetId = null)
        {
            PlaybackRequest playbackRequest = new PlaybackRequest(); 
            switch (playbackStartType)
            {
                case PlaybackStartType.Track:
                    playbackRequest.Position = position;
                    playbackRequest.Uris = new List<string> { GetTrackUri(id) };
                    break;
                case PlaybackStartType.Episode:
                    playbackRequest.Position = position;
                    playbackRequest.Uris = new List<string> { GetEpisodeUri(id) };
                    break;
                case PlaybackStartType.Album:
                    if (offsetId != null && position != null)
                        throw new ArgumentException($"Set {nameof(offsetId)} or {nameof(position)}");
                    if (position != null && offsetId == null)
                        playbackRequest.Offset = new PositionRequest() { Position = position };
                    if (offsetId != null && position == null)
                        playbackRequest.Offset = new UriRequest { Uri = GetTrackUri(offsetId) };
                    playbackRequest.ContextUri = GetAlbumUri(id);
                    break;
                case PlaybackStartType.Artist:
                    if (offsetId != null && position != null)
                        throw new ArgumentException($"Set {nameof(offsetId)} or {nameof(position)}");
                    if (position != null && offsetId == null)
                        playbackRequest.Offset = new PositionRequest() { Position = position };
                    if (offsetId != null && position == null)
                        playbackRequest.Offset = new UriRequest { Uri = GetTrackUri(offsetId) };
                    playbackRequest.ContextUri = GetArtistUri(id);
                    break;
                case PlaybackStartType.Playlist:
                    if (offsetId != null && position != null)
                        throw new ArgumentException($"Set {nameof(offsetId)} or {nameof(position)}");
                    if (position != null && offsetId == null)
                        playbackRequest.Offset = new PositionRequest() { Position = position };
                    if (offsetId != null && position == null)
                        playbackRequest.Offset = new UriRequest { Uri = GetTrackUri(offsetId) };
                    playbackRequest.ContextUri = GetPlaylistUri(id);
                    break;
                case PlaybackStartType.Show:
                    if (offsetId != null && position != null)
                        throw new ArgumentException($"Set {nameof(offsetId)} or {nameof(position)}");
                    if (position != null && offsetId == null)
                        playbackRequest.Offset = new PositionRequest() { Position = position };
                    if (offsetId != null && position == null)
                        playbackRequest.Offset = new UriRequest { Uri = GetEpisodeUri(offsetId) };
                    playbackRequest.ContextUri = GetShowUri(id);
                    break;
            }
            return playbackRequest;
        }

        /// <summary>
        /// Get Playback Queue Uri
        /// </summary>
        /// <param name="itemType">Playlist Item Type</param>
        /// <param name="id">Spotify Id</param>
        /// <returns>String</returns>
        public static string GetPlaybackQueueUri(PlayItemType itemType, string id)
        {
            string result = null;
            switch (itemType)
            {
                case PlayItemType.Track:
                    result = GetTrackUri(id);
                    break;
                case PlayItemType.Episode:
                    result = GetEpisodeUri(id);
                    break;
            }
            return result;
        }

        /// <summary>
        /// List Navigation Requests
        /// </summary>
        /// <param name="navigationResponse"></param>
        /// <returns>List of Navigation Request</returns>
        public static List<NavigationRequest> ListNavigationRequests<TResponse>(NavigationResponse<TResponse> navigationResponse)
        {
            List<NavigationRequest> navigationRequests = null;
            if (navigationResponse?.Total > 0 && navigationResponse?.Limit > 0)
            {
                navigationRequests = new List<NavigationRequest>();
                var total = navigationResponse.Total;
                var limit = navigationResponse.Limit;
                // Get Count
                var count = (int)Math.Ceiling((double)total / limit);
                for (int index = 0; index < count; index++)
                {
                    // Get Offset
                    var offset = index * limit;
                    NavigationRequest navigationRequest = new NavigationRequest()
                    {
                        Offset = offset,
                        Limit = limit
                    };
                    navigationRequests.Add(navigationRequest);
                }
            }
            return navigationRequests;
        }

        /// <summary>
        /// Get Bool Response
        /// </summary>
        /// <param name="navigationResponse">Navigation Response of bool</param>
        /// <returns>Bool Response</returns>
        public static BoolResponse GetBoolResponse(NavigationResponse<bool> navigationResponse) => 
            navigationResponse == null
            ? null
            : new BoolResponse()
            {
                Error = navigationResponse?.Error,
                Value = navigationResponse?.Items?.FirstOrDefault() ?? false
            };

        /// <summary>
        /// Get Bool Response
        /// </summary>
        /// <param name="value">Boolean Value</param>
        /// <returns>Bool Response</returns>
        public static BoolResponse GetBoolResponse(bool value) =>
            new BoolResponse()
            {
                Value = value
            };

        /// <summary>
        /// Get Playlist Item Uri
        /// </summary>
        /// <param name="playItemType">Playlist Item Type</param>
        /// <param name="id">Item Id</param>
        /// <returns>Playlist Item Uri</returns>
        public static string GetPlaylistItemUri(PlayItemType playItemType, string id) =>
            playItemType == PlayItemType.Track ? GetTrackUri(id) : GetEpisodeUri(id);

        /// <summary>
        /// Get Uri List Request
        /// </summary>
        /// <param name="playlistItemRequests">Playlist Item Requests</param>
        /// <returns>UriListRequest</returns>
        public static UriListRequest GetUriListRequest(List<AddPlaylistItemRequest> playlistItemRequests) =>
            new UriListRequest()
            {
                Uris = playlistItemRequests.Select(item => 
                    GetPlaylistItemUri(item.PlayItemType, item.Id)).ToList()
            };

        /// <summary>
        /// Get Uri Request List
        /// </summary>
        /// <param name="itemType">Play Item Type</param>
        /// <param name="multipleIds">Multiple Spotify Item Ids</param>
        /// <returns></returns>
        public static List<UriRequest> GetUriRequestList(PlayItemType itemType, List<string> multipleIds) =>
            multipleIds.Select(id => new UriRequest() 
            { 
                Uri = GetPlaylistItemUri(itemType, id)
            })
            .ToList();

        /// <summary>
        /// Get Playlist Tracks Request
        /// </summary>
        /// <param name="requests">Remove Playlist Item Requests</param>
        /// <param name="snapshotId">Snapshot Id</param>
        /// <returns></returns>
        public static PlaylistTracksRequest GetPlaylistTracksRequest(
            List<RemovePlaylistItemRequest> requests = null, 
            string snapshotId = null) => 
            new PlaylistTracksRequest()
            {
                Tracks = requests.Select(item =>
                    new PositionUriRequest()
                    {
                        Uri = GetPlaylistItemUri(item.PlayItemType, item.Id),
                        Positions = item.Positions
                    }).ToList(),
                SnapshotId = snapshotId,
            };

        /// <summary>
        /// Get Playlist Request
        /// </summary>
        /// <param name="name">(Required) The new name for the playlist, for example "My New Playlist Title"</param>
        /// <param name="description">(Optional) Value for playlist description as displayed in Spotify Clients and in the Web API</param>
        /// <param name="isCollaborative">(Optional) If true , the playlist will become collaborative and other users will be able to modify the playlist in their Spotify client. Note: You can only set collaborative to true on non-public playlists.</param>
        /// <param name="isPublic">(Optional) If true the playlist will be public, if false it will be private.</param>
        /// <returns></returns>
        public static PlaylistRequest GetPlaylistRequest(
            string name,
            string description,
            bool? isCollaborative,
            bool? isPublic) =>
            new PlaylistRequest()
            {
                Name = name,
                Description = description,
                IsCollaborative = isCollaborative,
                IsPublic = isPublic 
            };

        /// <summary>
        /// Get Playlist Reorder Request
        /// </summary>
        /// <param name="rangeStart">(Required) Position of the first track to be reordered</param>
        /// <param name="insertBefore">(Required) Position where the tracks should be inserted. To reorder the tracks to the end of the playlist, simply set insertBefore to the position after the last track.</param>
        /// <param name="rangeLength">(Optional) Amount of tracks to be reordered. Defaults to 1 if not set. The range of tracks to be reordered begins from the rangeStart position, and includes the rangeLength subsequent tracks.</param>
        /// <param name="snapshotId">(Optional) Playlist’s snapshot ID against which you want to make the changes.</param>
        /// <returns>PlaylistReorderRequest</returns>
        public static PlaylistReorderRequest GetPlaylistReorderRequest(
            int rangeStart,
            int insertBefore,
            int? rangeLength = null,
            string snapshotId = null) =>
            new PlaylistReorderRequest()
            {
                RangeStart = rangeStart,
                InsertBefore = insertBefore,
                RangeLength = rangeLength,
                SnapshotId = snapshotId
            };

        /// <summary>
        /// Get Status Response
        /// </summary>
        /// <param name="success">Success</param>
        /// <returns></returns>
        public static StatusResponse GetStatusResponse(bool success) =>
            new StatusResponse() { Success = success };

        /// <summary>
        /// Get Bools
        /// </summary>
        /// <param name="values">List of Bool</param>
        /// <returns>Bolls Object</returns>
        public static Bools GetBools(List<bool> values)
        {
            if (values == null)
                return null;
            var bools = new Bools();
            bools.AddRange(values);
            return bools;
        }

        /// <summary>
        /// Is Repeat State Off
        /// </summary>
        /// <param name="repeatState">Repeat State</param>
        /// <returns>True if is, False if Not</returns>
        public static bool IsRepeatStateOff(string repeatState) =>
            !string.IsNullOrEmpty(repeatState) && 
            repeatState.ToLower() == "off";

        /// <summary>
        /// Is Repeat State Track
        /// </summary>
        /// <param name="repeatState">Repeat State</param>
        /// <returns>True if is, False if Not</returns>
        public static bool IsRepeatStateTrack(string repeatState) =>
            !string.IsNullOrEmpty(repeatState) && 
            repeatState.ToLower() == "track";

        /// <summary>
        /// Is Repeat State Context
        /// </summary>
        /// <param name="repeatState">Repeat State</param>
        /// <returns>True if is, False if Not</returns>
        public static bool IsRepeatStateContext(string repeatState) =>
            !string.IsNullOrEmpty(repeatState) && 
            repeatState.ToLower() == "context";

        /// <summary>
        /// Get Audio Key
        /// </summary>
        /// <param name="value">Key Index</param>
        /// <returns>Audio Features Key</returns>
        public static string GetAudioKey(int? value) => 
            value != null ? 
                value.Value >= 0 && value.Value < audio_features_keys.Count() ? 
                    audio_features_keys[value.Value] : 
                        string.Empty : 
                null;

        /// <summary>
        /// Get Audio Percentage
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetAudioPercentage(float? value) =>
            (int)((value ?? 0) * 100);

        /// <summary>
        /// Get Audio Mode
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Major, Minor or Empty String</returns>
        public static string GetAudioMode(int? value) =>
            value != null ? 
                value.Value >= 0 ? 
                    value.Value == 0 ? 
                        "Minor" : 
                    "Major" :
                    string.Empty : 
            null;

        /// <summary>
        /// Get Audio Meter
        /// </summary>
        /// <param name="value">Key Index</param>
        /// <returns>Audio Features Key</returns>
        public static string GetAudioMeter(int? value) =>
            value != null ?
                value.Value >= 0 && value.Value < audio_features_meter.Count() ?
                    audio_features_meter[value.Value] :
                        string.Empty :
                null;

        /// <summary>
        /// Get Audio Value
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Rounded Value</returns>
        public static int GetAudioValue(float? value) =>
            value != null ? (int)value.Value : 0;

        /// <summary>
        /// Is Premium
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>True if is, False if Not</returns>
        public static bool IsPremium(string product) =>
            product == "premium";
        #endregion Public Methods
    }
}
