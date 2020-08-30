using Spotify.NetStandard.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Spotify SDK Client
    /// </summary>
    public interface ISpotifySdkClient
    {
        #region Public Properties
        /// <summary>
        /// Spotify Client
        /// </summary>
        ISpotifyClient SpotifyClient { get; }

        /// <summary>
        /// Authentication Redirect Uri
        /// </summary>
        Uri AuthenticationRedirectUri { get; set; }

        /// <summary>
        /// Authentication State
        /// </summary>
        string AuthenticationState { get; set; }

        /// <summary>
        /// ISO 3166-1 alpha-2 country code e.g. GB for Country and Market
        /// </summary>
        string Country { get; set; }

        /// <summary>
        /// ISO 639-1 language code and an ISO 3166-1 alpha-2 country code, joined by an underscore e.g. en_GB
        /// </summary>
        string Locale { get; set; }

        /// <summary>
        /// Number of items to return per request
        /// </summary>
        int? Limit { get; set; }

        /// <summary>
        /// Navigation Type (Default: NavigationType.Next)
        /// </summary>
        NavigationType NavigationType { get; set; }

        /// <summary>
        /// Is User Logged In
        /// </summary>
        bool IsUserLoggedIn { get; set; }

        /// <summary>
        /// Authentication Token
        /// </summary>
        AuthenticationTokenResponse AuthenticationToken { get; set; }

        /// <summary>
        /// Only for AuthenticationFlowType.AuthorisationCodeWithProofKeyForCodeExchange - Proof Key for Code Exchange (PKCE) Verifier
        /// </summary>
        string AuthenticationVerifier { get; set; }

        /// <summary>
        /// Configuration
        /// </summary>
        Configuration Config { get; }

        /// <summary>
        /// Favourites
        /// </summary>
        IFavourites Favourites { get; }

        /// <summary>
        /// Command Actions
        /// </summary>
        CommandActions CommandActions { get; }

        /// <summary>
        /// Current Device - Set by Get User Currently Playing
        /// </summary>
        DeviceResponse CurrentDevice { get; set; }

        /// <summary>
        /// Current Playlist - Set by Get Playlist
        /// </summary>
        PlaylistResponse CurrentPlaylist { get; set; }

        /// <summary>
        /// Current User - Set by Get Current User
        /// </summary>
        CurrentUserResponse CurrentUser { get; set; }
        #endregion Public Properties

        #region Public Methods
        /// <summary>
        /// Set
        /// </summary>
        /// <param name="cultureInfo">(Required) Culture Info</param>
        /// <returns>ISpotifySdkClient</returns>
        ISpotifySdkClient Set(CultureInfo cultureInfo);

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="country">(Optional) ISO 3166-1 alpha-2 country code e.g. GB</param>
        /// <param name="locale">(Optional) ISO 639-1 language code and an ISO 3166-1 alpha-2 country code, joined by an underscore e.g. en_GB</param>
        /// <returns>ISpotifySdkClient</returns>
        ISpotifySdkClient Set(
            string country = null,
            string locale = null);

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="favourites">Favourites</param>
        /// <returns>ISpotifySdkClient</returns>
        ISpotifySdkClient Set(IFavourites favourites);
        #endregion Public Methods

        #region Authentication Methods
        /// <summary>
        /// Get Authentication Uri
        /// </summary>
        /// <param name="authenticationFlowType">(Required) Only AuthenticationFlowType.AuthorisationCode or AuthenticationFlowType.ImplicitGrant supported</param>
        /// <param name="authenticationScope">(Optional) Authentication Scope</param>
        /// <param name="showAuthenticationDialog">(Optional) Whether or not to force the user to approve the app again if they’ve already done so.</param>
        /// <exception cref="ArgumentNullException">Only thrown when AuthenticationRedirectUri is not supplied</exception>
        /// <exception cref="ArgumentOutOfRangeException">Only thrown when AuthenticationFlowType unsupported</exception>
        Uri GetAuthenticationUri(
            AuthenticationFlowType authenticationFlowType,
            AuthenticationScopeRequest authenticationScope = null,
            bool showAuthenticationDialog = false);

        /// <summary>
        /// Get Authentication Token
        /// </summary>
        /// <param name="authenticationFlowType">(Required) Authentication Flow Type</param>
        /// <param name="authenticationResponseUri">(Required) Only for AuthenticationFlowType.AuthorisationCode or AuthenticationFlowType.ImplicitGrant - Authentication Response Uri</param>
        /// <returns>AuthenticationTokenResponse on Success, Null if Not</returns>
        /// <exception cref="ArgumentNullException">Thrown if authenticationResponseUri and AuthenticationRedirectUri aren't set</exception>
        /// <exception cref="AuthenticationAccessCodeNotFoundException">Only thrown for AuthenticationFlowType.AuthorisationCode if Authorisation Code not returned</exception>
        /// <exception cref="AuthenticationAccessTokenNotFoundException">Only thrown for AuthenticationFlowType.ImplicitGrant if Access Token was not returned</exception>
        /// <exception cref="AuthenticationStateNotMatchedException">Only thrown for AuthenticationFlowType.AuthorisationCode and AuthenticationFlowType.ImplicitGrant is State doesn't match</exception>
        Task<AuthenticationTokenResponse> GetAuthenticationTokenAsync(
            AuthenticationFlowType authenticationFlowType,
            Uri authenticationResponseUri = null);

        /// <summary>
        /// Set Authentication Token Client Credentials
        /// </summary>
        void SetAuthenticationTokenClientCredentialsAsync();

        /// <summary>
        /// Logout
        /// </summary>
        void Logout();
        #endregion Authentication Methods

        #region Public Events
        /// <summary>
        /// Authentication Token Required Event
        /// </summary>
        event EventHandler<AuthenticationTokenRequiredArgs> AuthenticationTokenRequired;

        /// <summary>
        /// Client Exception Event
        /// </summary>
        event EventHandler<ClientExceptionArgs> ClientException;

        /// <summary>
        /// Response Error Event
        /// </summary>
        event EventHandler<ResponseErrorArgs> ResponseError;

        /// <summary>
        /// Response User Playback Success
        /// </summary>
        event EventHandler<ResponseUserPlaybackArgs> ResponseUserPlaybackSuccess;
        #endregion Public Events

        #region Event Handlers
        /// <summary>
        /// Playlist Item Response Removed Handler
        /// </summary>
        /// <param name="response">Playlist Response</param>
        /// <param name="args">Playlist Item Response Removed Argument</param>
        void PlaylistItemResponseRemovedHandler(
            PlaylistResponse response,
            ResponseRemovedArgs<PlaylistItemResponse> args);

        /// <summary>
        /// Playlist Item Response Removed Handler
        /// </summary>
        /// <param name="response">Playlist Response</param>
        /// <param name="args">Playlist Item Response Removed Argument</param>
        void PlaylistItemResponseMovedHandler(
            PlaylistResponse response,
            ResponseMovedArgs args);
        #endregion Event Handlers

        #region Get Methods
        /// <summary>
        /// Get Category
        /// </summary>
        /// <param name="categoryId">(Required) Spotify Category Id</param>
        /// <returns>Category Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<CategoryResponse> GetCategoryAsync(string categoryId);

        /// <summary>
        /// Get Artist
        /// </summary>
        /// <param name="artistId">(Required) Spotify Artist Id</param>
        /// <returns>Artist Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<ArtistResponse> GetArtistAsync(string artistId);

        /// <summary>
        /// Get Playlist
        /// </summary>
        /// <param name="playlistId">(Required) Spotify Playlist Id</param>
        /// <param name="fields">(Optional) Filters for the query: a comma-separated list of the fields to return. If omitted, all fields are returned.</param>
        /// <returns>Playlist Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<PlaylistResponse> GetPlaylistAsync(
            string playlistId,
            string fields = null);

        /// <summary>
        /// Get Album
        /// </summary>
        /// <param name="albumId">(Required) Spotify Album Id</param>
        /// <returns>Album Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<AlbumResponse> GetAlbumAsync(string albumId);

        /// <summary>
        /// Get Track
        /// </summary>
        /// <param name="trackId">(Required) Spotify Track Id</param>
        /// <returns>Track Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<TrackResponse> GetTrackAsync(string trackId);

        /// <summary>
        /// Get Track Audio Analysis
        /// </summary>
        /// <param name="trackId">(Required) Spotify Track Id</param>
        /// <returns>Audio Analysis Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<AudioAnalysisResponse> GetTrackAudioAnalysisAsync(string trackId);

        /// <summary>
        /// Get Track Audio Features
        /// </summary>
        /// <param name="trackId">(Required) Spotify Track Id</param>
        /// <returns>Audio Features Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<AudioFeaturesResponse> GetTrackAudioFeaturesAsync(string trackId);

        /// <summary>
        /// Get Episode
        /// </summary>
        /// <param name="episodeId">(Required) Spotify Episode Id</param>
        /// <returns>Episode Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<EpisodeResponse> GetEpisodeAsync(string episodeId);

        /// <summary>
        /// Get Show
        /// </summary>
        /// <param name="showId">(Required) Spotify Show Id</param>
        /// <returns>Show Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<ShowResponse> GetShowAsync(string showId);

        /// <summary>
        /// Get Current User
        /// <para>Scopes: UserReadEmail, UserReadPrivate</para>
        /// </summary>
        /// <returns>Current User Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<CurrentUserResponse> GetCurrentUserAsync();

        /// <summary>
        /// Get User
        /// </summary>
        /// <param name="userId">(Required) Spotify User Id</param>
        /// <returns>User Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<UserResponse> GetUserAsync(string userId);

        /// <summary>
        /// Get Playlist Image
        /// </summary>
        /// <param name="playlistId">(Required) Spotify Playlist Id</param>
        /// <returns>Playlist Image Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<PlaylistImageResponse> GetPlaylistImageAsync(string playlistId);

        /// <summary>
        /// Get User Currently Playing Item
        /// <para>Scopes: ConnectReadCurrentlyPlaying, ConnectReadPlaybackState</para>
        /// </summary>
        /// <returns>Currently Playing Item Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<CurrentlyPlayingItemResponse> GetUserCurrentlyPlayingItemAsync();

        /// <summary>
        /// Get User Currently Playing
        /// <para>Scopes: ConnectReadPlaybackState</para>
        /// </summary>
        /// <returns>Currently Playing Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<CurrentlyPlayingResponse> GetUserCurrentlyPlayingAsync();

        /// <summary>
        /// Get Saved
        /// <para>Scopes: LibraryRead</para>
        /// </summary>
        /// <param name="savedType">(Required) Saved Type</param>
        /// <param name="id">(Required) Spotify Item Id</param>
        /// <returns>Bool Response</returns>
        Task<BoolResponse> GetSavedAsync(
            SavedType savedType,
            string id);

        /// <summary>
        /// Get Follow
        /// <para>Scopes: FollowType.FollowArtist FollowType.FollowUser - FollowRead, FollowType.FollowPlaylist - PlaylistReadPrivate</para>
        /// </summary>
        /// <param name="followType">(Required) Follow Type</param>
        /// <param name="id">(Required) Spotify Item Id</param>
        /// <param name="userId">(Required) Only for FollowType.FollowPlaylist</param>
        /// <returns>Bool Response</returns>
        Task<BoolResponse> GetFollowAsync(
            FollowType followType,
            string id,
            string userId = null);

        /// <summary>
        /// Get
        /// </summary>
        /// <typeparam name="TResponse">Response Type: CategoryResponse, ArtistResponse, PlaylistResponse, AlbumResponse, TrackResponse, AudioFeaturesResponse, AudioAnalysisResponse, EpisodeResponse, ShowResponse, CurrentUserResponse, UserResponse, PlaylistImageResponse, CurrentlyPlayingResponse, CurrentlyPlayingItemResponse</typeparam>
        /// <param name="id">Id</param>
        /// <returns>Response</returns>
        Task<TResponse> GetAsync<TResponse>(string id)
            where TResponse : class;
        #endregion Get Methods

            #region Is Methods
        /// <summary>
        /// Is Playlist Owned by Current User?
        /// <para>Prerequisite: GetCurrentUser</para>
        /// </summary>
        /// <param name="playlist">Playlist Response</param>
        /// <returns>True if Playlist Owned, False if Not</returns>
        bool IsPlaylistOwnedByCurrentUser(
            PlaylistResponse playlist);
        #endregion Is Methods

        #region List Methods
        /// <summary>
        /// List Categories
        /// </summary>
        /// <param name="categoriesRequest">(Optional) Categories Request</param>
        /// <returns>NavigationResponse of Category Responses</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<NavigationResponse<CategoryResponse>> ListCategoriesAsync(
            CategoriesRequest categoriesRequest = null);

        /// <summary>
        /// List Categories
        /// </summary>
        /// <param name="navigationResponse">(Required) NavigationResponse of Category Responses</param>
        /// <returns>NavigationResponse of Category Responses</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<NavigationResponse<CategoryResponse>> ListCategoriesAsync(
            NavigationResponse<CategoryResponse> navigationResponse);

        /// <summary>
        /// List Artists
        /// <para>Scopes: ArtistType.UserFollowed - FollowRead, UserFollowed.UserTop - LibraryRead</para>
        /// </summary>
        /// <param name="artistsRequest">(Required) Artists Request</param>
        /// <returns>Navigation Response of Artist Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<NavigationResponse<ArtistResponse>> ListArtistsAsync(
            ArtistsRequest artistsRequest);

        /// <summary>
        /// List Artists
        /// <para>Scopes: ArtistType.UserFollowed - FollowRead, UserFollowed.UserTop - LibraryRead</para>
        /// </summary>
        /// <param name="navigationResponse">(Required) Navigation Response of Artist Response</param>
        /// <returns>Navigation Response of Artist Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<NavigationResponse<ArtistResponse>> ListArtistsAsync(
            NavigationResponse<ArtistResponse> navigationResponse);

        /// <summary>
        /// List Albums
        /// <para>Scopes: AlbumType.UserSaved - LibraryRead</para>
        /// </summary>
        /// <param name="albumsRequest">(Required) Albums Request</param>
        /// <returns>Navigation Response of Album Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<NavigationResponse<AlbumResponse>> ListAlbumsAsync(
            AlbumsRequest albumsRequest);

        /// <summary>
        /// List Albums
        /// <para>Scopes: AlbumType.UserSaved - LibraryRead</para>
        /// </summary>
        /// <param name="navigationResponse">(Required) Navigation Response of Album Response</param>
        /// <returns>Navigation Response of Album Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<NavigationResponse<AlbumResponse>> ListAlbumsAsync(
            NavigationResponse<AlbumResponse> navigationResponse);

        /// <summary>
        /// List Tracks
        /// <para>Scopes: TrackType.UserRecentlyPlayed - ListeningRecentlyPlayed, TrackType.UserSaved - LibraryRead, TrackType.UserTop - ListeningTopRead</para>
        /// </summary>
        /// <param name="tracksRequest">(Required) Tracks Request</param>
        /// <returns>Navigation Response of Track Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<NavigationResponse<TrackResponse>> ListTracksAsync(
            TracksRequest tracksRequest);

        /// <summary>
        /// List Tracks
        /// <para>Scopes: TrackType.UserRecentlyPlayed - ListeningRecentlyPlayed, TrackType.UserSaved - LibraryRead, TrackType.UserTop - ListeningTopRead</para>
        /// </summary>
        /// <param name="navigationResponse">(Required) Navigation Response of Track Response</param>
        /// <returns>Navigation Response of Track Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<NavigationResponse<TrackResponse>> ListTracksAsync(
            NavigationResponse<TrackResponse> navigationResponse);

        /// <summary>
        /// List Playlists
        /// <para>Scopes: PlaylistType.CurrentUser - PlaylistReadPrivate, PlaylistReadCollaborative</para>
        /// </summary>
        /// <param name="playlistsRequest">(Required) Playlists Request</param>
        /// <returns>Navigation Response of Playlist Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<NavigationResponse<PlaylistResponse>> ListPlaylistsAsync(
            PlaylistsRequest playlistsRequest);

        /// <summary>
        /// List Playlists
        /// <para>Scopes: PlaylistType.CurrentUser - PlaylistReadPrivate, PlaylistReadCollaborative</para>
        /// </summary>
        /// <param name="navigationResponse">(Required) Navigation Response of Playlist Response</param>
        /// <returns>Navigation Response of Playlist Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<NavigationResponse<PlaylistResponse>> ListPlaylistsAsync(
            NavigationResponse<PlaylistResponse> navigationResponse);

        /// <summary>
        /// List Playlist Items
        /// </summary>
        /// <param name="playlistItemsRequest">(Required) Playlist Items Request</param>
        /// <returns>Navigation Response of Track Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<NavigationResponse<PlaylistItemResponse>> ListPlaylistItemsAsync(
            PlaylistItemsRequest playlistItemsRequest);

        /// <summary>
        /// List Playlist Items
        /// </summary>
        /// <param name="navigationResponse">(Required) Navigation Response of Playlist Item Response</param>
        /// <returns>Navigation Response of Playlist Item Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<NavigationResponse<PlaylistItemResponse>> ListPlaylistItemsAsync(
            NavigationResponse<PlaylistItemResponse> navigationResponse);

        /// <summary>
        /// List Episodes
        /// </summary>
        /// <param name="episodesRequest">(Required) Episodes Request</param>
        /// <returns>Navigation Response of Episode Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<NavigationResponse<EpisodeResponse>> ListEpisodesAsync(
            EpisodesRequest episodesRequest);

        /// <summary>
        /// List Episodes
        /// </summary>
        /// <param name="navigationResponse">(Required) Navigation Response of Episode Response</param>
        /// <returns>Navigation Response of Episode Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<NavigationResponse<EpisodeResponse>> ListEpisodesAsync(
            NavigationResponse<EpisodeResponse> navigationResponse);

        /// <summary>
        /// List Shows
        /// <para>Scopes: ShowType.UserSaved - LibraryRead</para>
        /// </summary>
        /// <param name="showsRequest">(Required) Shows Request</param>
        /// <returns>Navigation Response of Episode Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<NavigationResponse<ShowResponse>> ListShowsAsync(
            ShowsRequest showsRequest);

        /// <summary>
        /// List Shows
        /// <para>Scopes: ShowType.UserSaved - LibraryRead</para>
        /// </summary>
        /// <param name="navigationResponse">(Required) Navigation Response of Show Response</param>
        /// <returns>Navigation Response of Show Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<NavigationResponse<ShowResponse>> ListShowsAsync(
            NavigationResponse<ShowResponse> navigationResponse);

        /// <summary>
        /// List Recommendation Genres
        /// </summary>
        /// <returns>List of Recommendation Genre Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<NavigationResponse<RecommendationGenreResponse>> ListRecommendationGenresAsync();

        /// <summary>
        /// List Audio Features
        /// </summary>
        /// <param name="audioFeaturesRequest">(Required) Audio Features Request</param>
        /// <returns>List of Audio Features Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<NavigationResponse<AudioFeaturesResponse>> ListAudioFeaturesAsync(
            AudioFeaturesRequest audioFeaturesRequest);

        /// <summary>
        /// List User Devices
        /// <para>Scopes: ConnectReadPlaybackState</para>
        /// </summary>
        /// <returns>Navigation Response of Device Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        Task<NavigationResponse<DeviceResponse>> ListUserDevicesAsync();

        /// <summary>
        /// List Saved
        /// </summary>
        /// <para>Scopes: LibraryRead</para>
        /// <param name="savedType">(Required) Saved Type</param>
        /// <param name="multipleIds">(Required) SavedType.Album - Multiple Spotify Album Ids, SavedType.Track - Multiple Spotify Track Ids, SavedType.Show - Multiple Spotify Show Ids</param>
        /// <returns>Navigation Response of bool</returns>
        Task<NavigationResponse<bool>> ListSavedAsync(
            SavedType savedType,
            List<string> multipleIds);

        /// <summary>
        /// List Follow
        /// </summary>
        /// <para>Scopes: FollowType.FollowArtist FollowType.FollowUser : FollowRead, FollowType.FollowPlaylist : PlaylistReadPrivate</para>
        /// <param name="followType">(Required) FollowType Type</param>
        /// <param name="multipleIds">(Required) FollowType.FollowArtist - Multiple Spotify Artist Ids, FollowType.FollowUser and FollowType.Playlist - Multiple Spotify User Ids</param>
        /// <param name="playlistId">(Required) Only for FollowType.FollowPlaylist</param>
        /// <returns>Navigation Response of bool</returns>
        Task<NavigationResponse<bool>> ListFollowAsync(
            FollowType followType,
            List<string> multipleIds,
            string playlistId = null);

        /// <summary>
        /// List
        /// </summary>
        /// <typeparam name="TRequest">Request Type: CategoriesRequest, ArtistsRequest, PlaylistsRequest, PlaylistItemsRequest, AlbumsRequest, TracksRequest, AudioFeaturesRequest, EpisodesRequest, ShowsRequest</typeparam>
        /// <typeparam name="TResponse">Response Type: CategoryResponse, ArtistResponse, PlaylistResponse, PlaylistItemResponse, AlbumResponse, TrackResponse, AudioFeaturesResponse, EpisodeResponse, ShowResponse, DeviceResponse, RecommendationGenreResponse</typeparam>
        /// <param name="request">Request</param>
        /// <returns>Navigation Response of Response</returns>
        Task<NavigationResponse<TResponse>> ListAsync<TRequest, TResponse>(
            TRequest request)
            where TRequest : class
            where TResponse : class;

        /// <summary>
        /// List
        /// </summary>
        /// <typeparam name="TResponse">Response Type: CategoryResponse, ArtistResponse, PlaylistResponse, PlaylistItemResponse, AlbumResponse, TrackResponse, AudioFeaturesResponse, EpisodeResponse, ShowResponse</typeparam>
        /// <returns>Navigation Response of Response</returns>
        Task<NavigationResponse<TResponse>> ListAsync<TResponse>(
            NavigationResponse<TResponse> response)
            where TResponse : class;
        #endregion List Methods

            #region Search Method
        /// <summary>
        /// Search
        /// </summary>
        /// <param name="searchRequest">(Required) Search Request</param>
        /// <returns>Search Response</returns>
        Task<SearchResponse> SearchAsync(
            SearchRequest searchRequest);
        #endregion Search Method

        #region Set Methods
        /// <summary>
        /// Set User Playback
        /// <para>Scopes: ConnectModifyPlaybackState</para>
        /// </summary>
        /// <param name="playbackType">(Required) Playback Type</param>
        /// <param name="deviceId">(Optional) Spotify Device Id</param>
        /// <param name="option">(Required) Only for PlaybackType.Seek - Position in milliseconds to seek to and PlaybackType.Volume - Value from 0 to 100 inclusive</param>
        /// <returns>Status Response</returns>
        Task<StatusResponse> SetUserPlaybackAsync(
            PlaybackType playbackType,
            string deviceId = null,
            int? option = null);

        /// <summary>
        /// Set Saved
        /// <para>Scopes: LibraryModify</para>
        /// </summary>
        /// <param name="savedType">(Required) Saved Type</param>
        /// <param name="setType">(Required) Set Type</param>
        /// <param name="multipleIds">(Required) SavedType.Album - Multiple Spotify Album Ids, SavedType.Track - Multiple Spotify Track Ids, SavedType.Show - Multiple Spotify Show Ids</param>
        /// <returns>Status Response</returns>
        Task<StatusResponse> SetSavedAsync(
            SavedType savedType,
            SetType setType,
            List<string> multipleIds);

        /// <summary>
        /// Set Saved
        /// <para>Scopes: LibraryModify</para>
        /// </summary>
        /// <param name="savedType">(Required) Saved Type</param>
        /// <param name="setType">(Required) Set Type</param>
        /// <param name="id">(Required) Spotify Item Id</param>
        /// <returns>Status Response</returns>
        Task<StatusResponse> SetSavedAsync(
            SavedType savedType,
            SetType setType,
            string id);

        /// <summary>
        /// Set Follow
        /// <para>Scopes: FollowModify, FollowType.Playlist and SetType.Remove - PlaylistModifyPublic or PlaylistModifyPrivate</para>
        /// </summary>
        /// <param name="followType">(Required) Follow Type</param>
        /// <param name="setType">(Required) Set Type</param>
        /// <param name="multipleIds">(Required) Only for FollowType.Artist - Multiple Spotify Artist Ids, FollowType.User - Multiple Spotify User Ids</param>
        /// <param name="playlistId">(Required) Only for FollowType.Playlist</param>
        /// <returns>Status Response</returns>
        Task<StatusResponse> SetFollowAsync(
            FollowType followType,
            SetType setType,
            List<string> multipleIds,
            string playlistId = null);

        /// <summary>
        /// Set Follow
        /// <para>Scopes: FollowModify, FollowType.Playlist and SetType.Remove - PlaylistModifyPublic or PlaylistModifyPrivate</para>
        /// </summary>
        /// <param name="followType">(Required) Follow Type</param>
        /// <param name="setType">(Required) Set Type</param>
        /// <param name="id">(Required) FollowType.Artist - Spotify Artist Id, FollowType.User - Spotify User Id, FollowType.Playlist - Spotify Playlist Id</param>
        /// <returns>Status Response</returns>
        Task<StatusResponse> SetFollowAsync(
            FollowType followType,
            SetType setType,
            string id);

        /// <summary>
        /// Set Playlist
        /// <para>Scopes: PlaylistModifyPublic, PlaylistModifyPrivate</para>
        /// </summary>
        /// <param name="request">(Required) Set Playlist Request</param>
        /// <returns>Playlist Response</returns>
        Task<StatusResponse> SetPlaylistAsync(
            SetPlaylistRequest request);

        /// <summary>
        /// Set Playlist Items
        /// <para>Scopes: PlaylistModifyPublic, PlaylistModifyPrivate</para>
        /// </summary>
        /// <param name="playlistId">(Required) Spotify Playlist Id</param>
        /// <param name="addPlaylistItemRequests">(Required) The items to add in the Playlist</param>
        /// <returns>Status Response</returns>
        Task<StatusResponse> SetPlaylistItemsAsync(
            string playlistId,
            List<AddPlaylistItemRequest> addPlaylistItemRequests);

        /// <summary>
        /// Set Playlist Item
        /// <para>Scopes: PlaylistModifyPublic, PlaylistModifyPrivate</para>
        /// </summary>
        /// <param name="playlistId">(Required) Spotify Playlist Id</param>
        /// <param name="playItemType">Track or Episode</param>
        /// <param name="id">Spotify Track or Episode Id</param>
        /// <returns>Status Response</returns>
        Task<StatusResponse> SetPlaylistItemAsync(
            string playlistId,
            PlayItemType playItemType,
            string id);

        /// <summary>
        /// Set Playlist Item Order
        /// </summary>
        /// <param name="playlistId">(Required) Spotify Playlist Id</param>
        /// <param name="rangeStart">(Required) Position of the first item to be reordered</param>
        /// <param name="insertBefore">(Required) Position where the items should be inserted. To reorder the items to the end of the playlist, simply set insertBefore to the position after the last item.</param>
        /// <param name="rangeLength">(Optional) Amount of items to be reordered. Defaults to 1 if not set. The range of items to be reordered begins from the rangeStart position, and includes the rangeLength subsequent items.</param>
        /// <param name="snapshotId">(Optional) Playlist’s snapshot ID against which you want to make the changes.</param>
        /// <returns>Status Response</returns>
        Task<StatusResponse> SetPlaylistItemOrderAsync(
            string playlistId,
            int rangeStart,
            int insertBefore,
            int? rangeLength = null,
            string snapshotId = null);

        /// <summary>
        /// Set Playlist Image
        /// <para>Scopes: ImageUserGeneratedContentUpload</para>
        /// </summary>
        /// <param name="playlistId">(Required) Spotify Playlist Id</param>
        /// <param name="jpegFileBytes">(Required) JPEG Image File Bytes (256Kb Max File Size)</param>
        /// <returns>Status Response</returns>
        Task<StatusResponse> SetPlaylistImageAsync(
            string playlistId,
            byte[] jpegFileBytes);
        #endregion Set Methods

        #region Toggle Methods
        /// <summary>
        /// Toggle Saved
        /// <para>Scopes: LibraryModify</para>
        /// </summary>
        /// <param name="savedType">(Required) Saved Type</param>
        /// <param name="id">(Required) SavedType.Album - Spotify Album Id, SavedType.Track - Spotify Track Id, SavedType.Show - Spotify Show Id</param>
        /// <returns>Status Response</returns>
        Task<BoolResponse> ToggleSavedAsync(
            SavedType savedType,
            string id);

        /// <summary>
        /// Toggle Follow
        /// <para>Scopes: FollowType.FollowArtist FollowType.FollowUser - FollowRead and FollowModify, FollowType.FollowPlaylist - FollowModify and PlaylistModifyPublic or PlaylistModifyPrivate</para>
        /// </summary>
        /// <param name="followType">(Required) Follow Type</param>
        /// <param name="id">(Required) FollowType.Artist - Spotify Artist Id, FollowType.User - Spotify User Id, FollowType.Playlist - Spotify Playlist Id</param>
        /// <returns>Bool Response</returns>
        Task<BoolResponse> ToggleFollowAsync(
            FollowType followType,
            string id);

        /// <summary>
        /// Set Toggle
        /// </summary>
        /// <param name="toggle">Toggle</param>
        void SetToggleAsync(Toggle toggle);

        /// <summary>
        /// Get Toggle
        /// </summary>
        /// <param name="toggleType">Toggle Type</param>
        /// <param name="id">Toggle Id</param>
        /// <param name="itemType">Toggle Item Type</param>
        /// <returns>Toggle</returns>
        Task<Toggle> GetToggleAsync(
            ToggleType toggleType,
            string id,
            byte itemType);

        /// <summary>
        /// List Toggles
        /// </summary>
        /// <param name="toggleType">Toggle Type</param>
        /// <param name="multipleIds">Multiple Ids</param>
        /// <param name="playlistId">Playlist Id</param>
        /// <param name="itemType">Item Type</param>
        /// <returns>List of Toggle</returns>
        Task<List<Toggle>> ListTogglesAsync(
            ToggleType toggleType,
            List<string> multipleIds,
            string playlistId,
            byte itemType);
        #endregion Toggle Methods

        #region Add Methods
        /// <summary>
        /// Add User Playback
        /// <para>Scopes: ConnectModifyPlaybackState</para>
        /// </summary>
        /// <param name="playbackStartType">(Required) Playback Start Type</param>
        /// <param name="id">(Required) PlaybackStartType.Track - Spotify Track Id, PlaybackStartType.Episode - Spotify Episode Id, PlaybackStartType.Album - Spotify Album Id, PlaybackStartType.Artist - Spotify Artist Id, PlaybackStartType.Playlist - Spotify Playlist Id, PlaybackStartType.Show - Spotify Show Id</param>
        /// <param name="deviceId">(Optional) Spotify Device Id</param>
        /// <param name="position">(Optional) Indicates from what position to start playback. Must be a positive number. Passing in a position that is greater than the length of the track will cause the player to start playing the next song.</param>
        /// <param name="offsetId">(Optional) Only for PlaybackStartType.Album, PlaybackStartType.Artist, PlaybackStartType.Playlist and PlaybackStartType.Show. Only use either Position or OffsetId. Offset Id indicates from where in the context playback should start.</param>
        /// <exception cref="ArgumentException">Thrown when Position and OffsetId are Provided</exception>
        /// <returns>Status Response</returns>
        Task<StatusResponse> AddUserPlaybackAsync(
            PlaybackStartType playbackStartType,
            string id,
            string deviceId = null,
            int? position = null,
            string offsetId = null);

        /// <summary>
        /// Add User Playback Queue
        /// <para>Scopes: ConnectModifyPlaybackState</para>
        /// </summary>
        /// <param name="playItemType">(Required) Track or Episode</param>
        /// <param name="id">(Required) PlayItemType.Track - Spotify Track Id, PlayItemType.Episode - Spotify Episode Id</param>
        /// <param name="deviceId">(Optional) Spotify Device Id</param>
        /// <returns>Status Response</returns>
        Task<StatusResponse> AddUserPlaybackQueueAsync(
            PlayItemType playItemType,
            string id,
            string deviceId = null);

        /// <summary>
        /// Add Playlist
        /// <para>Scopes: PlaylistModifyPublic, PlaylistModifyPrivate</para>
        /// </summary>
        /// <param name="request">(Required) Add Playlist Request</param>
        /// <returns>Playlist Response</returns>
        Task<PlaylistResponse> AddPlaylistAsync(
            AddPlaylistRequest request);

        /// <summary>
        /// Add Playlist Items
        /// <para>Scopes: PlaylistModifyPublic, PlaylistModifyPrivate</para>
        /// </summary>
        /// <param name="playlistId">(Required) Spotify Playlist Id</param>
        /// <param name="requests">(Required) The items to add to the playlist</param>
        /// <param name="position">(Optional) The position to insert the items, a zero-based index</param>
        /// <returns>Snapshot Response</returns>
        Task<SnapshotResponse> AddPlaylistItemsAsync(
            string playlistId,
            List<AddPlaylistItemRequest> requests,
            int? position = null);

        /// <summary>
        /// Add Playlist Item
        /// <para>Scopes: PlaylistModifyPublic, PlaylistModifyPrivate</para>
        /// </summary>
        /// <param name="playlistId">(Required) Spotify Playlist Id</param>
        /// <param name="playItemType">(Required) Track or Episode</param>
        /// <param name="id">(Required) Spotify Track Id or Episode Id</param>
        /// <param name="position">(Optional) The positions to remove items by id, a zero-based index</param>
        /// <returns>Snapshot Response</returns>
        Task<SnapshotResponse> AddPlaylistItemAsync(
            string playlistId,
            PlayItemType playItemType,
            string id,
            int? position = null);
        #endregion Add Methods

        #region Remove Methods
        /// <summary>
        /// Remove Playlist Items
        /// <para>Scopes: PlaylistModifyPublic, PlaylistModifyPrivate</para>
        /// </summary>
        /// <param name="playlistId">(Required) Spotify Playlist Id</param>
        /// <param name="removePlaylistItemRequests">(Required) The items to remove from the Playlist</param>
        /// <param name="snapshotId">(Optional) The playlist’s snapshot ID against which you want to make the changes. The API will validate that the specified tracks exist and in the specified positions and make the changes, even if more recent changes have been made to the playlist</param>
        /// <returns>Snapshot Response</returns>
        Task<SnapshotResponse> RemovePlaylistItemsAsync(
            string playlistId,
            List<RemovePlaylistItemRequest> removePlaylistItemRequests,
            string snapshotId = null);

        /// <summary>
        /// Remove Playlist Item
        /// <para>Scopes: PlaylistModifyPublic, PlaylistModifyPrivate</para>
        /// </summary>
        /// <param name="playlistId">(Required) Spotify Playlist Id</param>
        /// <param name="playItemType">(Required) Track or Episode</param>
        /// <param name="id">(Required) Spotify Track Id or Episode Id</param>
        /// <param name="positions">(Optional) The positions to remove items by id, a zero-based index</param>
        /// <param name="snapshotId">(Optional) The playlist’s snapshot ID against which you want to make the changes. The API will validate that the specified tracks exist and in the specified positions and make the changes, even if more recent changes have been made to the playlist</param>
        /// <returns>Snapshot Response</returns>
        Task<SnapshotResponse> RemovePlaylistItemAsync(
            string playlistId,
            PlayItemType playItemType,
            string id,
            List<int> positions = null,
            string snapshotId = null);
        #endregion Remove Methods

        #region Favourite Methods
        /// <summary>
        /// Get Favourite
        /// </summary>
        /// <param name="favouriteType">(Required) Favourite Type</param>
        /// <param name="id">(Required) FavouriteType.Album - Spotify Album Id, FavouriteType.Artist - Spotify Artist Id, FavouriteType.Track - Spotify Track Id, FavouriteType.Show - Spotify Show Id, FavouriteType.Episode - Spotify Episode Id</param>
        /// <returns>Bool Response</returns>
        Task<BoolResponse> GetFavouriteAsync(
            FavouriteType favouriteType,
            string id);

        /// <summary>
        /// List Favourite
        /// </summary>
        /// <param name="favouriteType">(Required) Favourite Type</param>
        /// <param name="multipleIds">(Required) FavouriteType.Album - Multiple Spotify Album Ids, FavouriteType.Artist - Multiple Spotify Artist Ids, FavouriteType.Track - Multiple Spotify Track Ids, FavouriteType.Show - Multiple Spotify Show Ids, FavouriteType.Episode - Multiple Spotify Episode Ids</param>
        /// <returns>Navigation Response of Bool</returns>
        Task<NavigationResponse<bool>> ListFavouriteAsync(
            FavouriteType favouriteType,
            List<string> multipleIds);

        /// <summary>
        /// Set Favourite
        /// </summary>
        /// <param name="favouriteType">(Required) Favourite Type</param>
        /// <param name="setType">(Required) Set Type</param>
        /// <param name="id">(Required) FavouriteType.Album - Spotify Album Id, FavouriteType.Artist - Spotify Artist Id, FavouriteType.Track - Spotify Track Id, FavouriteType.Show - Spotify Show Id, FavouriteType.Episode - Spotify Episode Id</param>
        /// <returns>Status Response</returns>
        Task<StatusResponse> SetFavouriteAsync(
            FavouriteType favouriteType,
            SetType setType,
            string id);

        /// <summary>
        /// Set Favourite
        /// </summary>
        /// <param name="favouriteType">(Required) Favourite Type</param>
        /// <param name="setType">(Required) Set Type</param>
        /// <param name="multipleIds">(Required) FavouriteType.Album - Multiple Spotify Album Ids, FavouriteType.Artist - Multiple Spotify Artist Ids, FavouriteType.Track - Multiple Spotify Track Ids, FavouriteType.Show - Multiple Spotify Show Ids, FavouriteType.Episode - Multiple Spotify Episode Ids</param>
        /// <returns>Status Response</returns>
        Task<StatusResponse> SetFavouriteAsync(
            FavouriteType favouriteType,
            SetType setType,
            List<string> multipleIds);

        /// <summary>
        /// Toggle Favourite
        /// </summary>
        /// <param name="favouriteType">(Required) Favourite Type</param>
        /// <param name="id">(Required) FavouriteType.Album - Spotify Album Id, FavouriteType.Artist - Spotify Artist Id, FavouriteType.Track - Spotify Track Id, FavouriteType.Show - Spotify Show Id, FavouriteType.Episode - Spotify Episode Id</param>
        /// <returns>Bool Response</returns>
        Task<BoolResponse> ToggleFavouriteAsync(
            FavouriteType favouriteType,
            string id);
        #endregion Favourite Methods
    }
}
