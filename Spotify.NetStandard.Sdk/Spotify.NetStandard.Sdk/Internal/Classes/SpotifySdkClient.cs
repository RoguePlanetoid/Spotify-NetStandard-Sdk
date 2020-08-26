using AutoMapper;
using Spotify.NetStandard.Client;
using Spotify.NetStandard.Client.Exceptions;
using Spotify.NetStandard.Client.Interfaces;
using Spotify.NetStandard.Enums;
using Spotify.NetStandard.Responses;
using Spotify.NetStandard.Sdk.AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.NetStandard.Sdk.Internal
{
    /// <summary>
    /// Spotify SDK Client
    /// </summary>
    internal class SpotifySdkClient : BaseNotifyPropertyChanged, ISpotifySdkClient
    {
        #region Private Readonly
        private static readonly List<string> additional_types = 
            new List<string> { "track", "episode" };
        #endregion Private Readonly

        #region Private Members
        private bool _isLoggedIn;
        private readonly IMapper _mapper;
        private readonly Favourites _favourites;
        #endregion Private Members

        #region Protected Methods
        /// <summary>
        /// On Authentication Token Required 
        /// </summary>
        /// <param name="authenticationTokenType">Authentication Token Type</param>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if no AuthenticationTokenRequired Event Subscribers</exception>
        protected virtual void OnAuthenticationTokenRequired(
            AuthenticationTokenType authenticationTokenType = AuthenticationTokenType.Access)
        {
            if (AuthenticationTokenRequired != null)
                AuthenticationTokenRequired?.Invoke(this, new AuthenticationTokenRequiredArgs(authenticationTokenType));
            else
                throw new AuthenticationTokenRequiredException(authenticationTokenType);
        }

        /// <summary>
        /// On Client Exception Required 
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <exception cref="Exception">Thrown if no ClientException Event Subscribers</exception>
        protected virtual void OnClientException(Exception exception)
        {
            if (ClientException != null)
                ClientException?.Invoke(this, new ClientExceptionArgs(exception));
            else
                throw exception;
        }

        /// <summary>
        /// On Status Failed
        /// </summary>
        /// <param name="status">Status</param>
        protected virtual void OnStatusFailed(StatusResponse status)
        {
            if (status != null && status.IsSuccess == false)
                ResponseError?.Invoke(this, new ResponseErrorArgs(status.Error));
        }

        /// <summary>
        /// On Response Error
        /// </summary>
        /// <param name="response"></param>
        protected virtual void OnResponseError(BaseResponse response)
        {
            if (response != null && response.IsSuccess == false)
                ResponseError?.Invoke(this, new ResponseErrorArgs(response.Error));
        }

        /// <summary>
        /// On Set User Playback Success
        /// </summary>
        /// <param name="status">Status</param>
        /// <param name="playbackType">Playback Type</param>
        /// <param name="deviceId">Device Id</param>
        protected virtual void OnSetUserPlaybackSuccess(StatusResponse status, PlaybackType playbackType, string deviceId = null)
        {
            if (status != null && status.IsSuccess == true)
                ResponseUserPlaybackSuccess?.Invoke(this, new ResponseUserPlaybackArgs(playbackType, deviceId));
        }
        #endregion Protected Methods

        #region Public Properties
        /// <summary>
        /// Spotify Client
        /// </summary>
        public ISpotifyClient SpotifyClient { get; private set; }

        /// <summary>
        /// Authentication Redirect Uri
        /// </summary>
        public Uri AuthenticationRedirectUri { get; set; }

        /// <summary>
        /// Authentication State
        /// </summary>
        public string AuthenticationState { get; set; }

        /// <summary>
        /// ISO 3166-1 alpha-2 country code e.g. GB for Country and Market
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// ISO 639-1 language code and an ISO 3166-1 alpha-2 country code, joined by an underscore e.g. en_GB
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// Number of items to return per request
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Navigation Type (Default: NavigationType.Next)
        /// </summary>
        public NavigationType NavigationType { get; set; }

        /// <summary>
        /// Is User Logged In
        /// </summary>
        public bool IsUserLoggedIn
        {
            get => _isLoggedIn;
            set { _isLoggedIn = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Authentication Token
        /// </summary>
        public AuthenticationTokenResponse AuthenticationToken
        {
            get => _mapper.Map(SpotifyClient.GetToken());
            set { SpotifyClient.SetToken(_mapper.Map(value)); NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Only for AuthenticationFlowType.AuthorisationCodeWithProofKeyForCodeExchange - Proof Key for Code Exchange (PKCE) Verifier
        /// </summary>
        public string AuthenticationVerifier
        {
            get => SpotifyClient.GetCodeVerifier();
            set { SpotifyClient.SetCodeVerifier(value); NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public Configuration Config { get; }

        /// <summary>
        /// Favourites
        /// </summary>
        public IFavourites Favourites => _favourites;

        /// <summary>
        /// Command Actions
        /// </summary>
        public CommandActions CommandActions { get; }

        /// <summary>
        /// Current Device - Set by Get User Currently Playing
        /// </summary>
        public DeviceResponse CurrentDevice { get; set; }

        /// <summary>
        /// Current Playlist - Set by Get Playlist
        /// </summary>
        public PlaylistResponse CurrentPlaylist { get; set; }

        /// <summary>
        /// Current User - Set by Get Current User
        /// </summary>
        public CurrentUserResponse CurrentUser { get; set; }
        #endregion Public Properties

        #region Public Methods
        /// <summary>
        /// Spotify Sdk Client
        /// </summary>
        /// <param name="clientId">(Required) Spotify Client Id</param>
        /// <param name="clientSecret">(Optional) Spotify Client Secret</param>
        /// <param name="authorisationRedirectUri">(Optional) Authorisation Redirect Uri</param>
        /// <param name="authorisationState">Authorisation State</param>
        public SpotifySdkClient(
            string clientId,
            string clientSecret = null,
            Uri authorisationRedirectUri = null,
            string authorisationState = null)
        {
            _mapper = _mapper.Setup();
            Config = new Configuration();
            _favourites = new Favourites();
            NavigationType = NavigationType.Next;
            CommandActions = new CommandActions();
            AuthenticationState = authorisationState;
            AuthenticationRedirectUri = authorisationRedirectUri;
            SpotifyClient = SpotifyClientFactory.CreateSpotifyClient(clientId, clientSecret);
        }

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="cultureInfo">(Required) Culture Info</param>
        /// <returns>ISpotifySdkClient</returns>
        public ISpotifySdkClient Set(CultureInfo cultureInfo)
        {
            if (cultureInfo != null)
            {
                var region = new RegionInfo(cultureInfo.LCID);
                if (Country == null)
                    Country = region.TwoLetterISORegionName;
                if (Locale == null)
                    Locale = $"{cultureInfo.TwoLetterISOLanguageName.ToLower()}_{region.TwoLetterISORegionName.ToUpper()}";
            }
            return this;
        }

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="country">(Optional) ISO 3166-1 alpha-2 country code e.g. GB</param>
        /// <param name="locale">(Optional) ISO 639-1 language code and an ISO 3166-1 alpha-2 country code, joined by an underscore e.g. en_GB</param>
        /// <returns>ISpotifySdkClient</returns>
        public ISpotifySdkClient Set(
            string country = null,
            string locale = null)
        {
            Country = country;
            Locale = locale;
            return this;
        }

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="favourites">Favourites</param>
        /// <returns>ISpotifySdkClient</returns>
        public ISpotifySdkClient Set(IFavourites favourites)
        {
            Favourites.AlbumIds = favourites.AlbumIds;
            Favourites.ArtistIds = favourites.ArtistIds;
            Favourites.EpisodeIds = favourites.EpisodeIds;
            Favourites.ShowIds = favourites.ShowIds;
            Favourites.TrackIds = favourites.TrackIds;
            return this;
        }
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
        public Uri GetAuthenticationUri(
            AuthenticationFlowType authenticationFlowType,
            AuthenticationScopeRequest authenticationScope = null,
            bool showAuthenticationDialog = false)
        {
            if (AuthenticationRedirectUri == null)
                throw new ArgumentNullException(nameof(AuthenticationRedirectUri));
            switch (authenticationFlowType)
            {
                case AuthenticationFlowType.AuthorisationCode:
                    // Authorisation Code Flow
                    return SpotifyClient.AuthUser(
                        redirectUri: AuthenticationRedirectUri,
                        state: AuthenticationState,
                        scope: _mapper.Map(authenticationScope),
                        showDialog: showAuthenticationDialog);
                case AuthenticationFlowType.AuthorisationCodeWithProofKeyForCodeExchange:
                    //  Authorization Code Flow With Proof Key for Code Exchange (PKCE)
                    return SpotifyClient.AuthUserCode(
                        redirectUri: AuthenticationRedirectUri,
                        state: AuthenticationState,
                        scope: _mapper.Map(authenticationScope));
                case AuthenticationFlowType.ClientCredentials:
                    // Client Credentials Unsupported
                    throw new ArgumentOutOfRangeException(); 
                case AuthenticationFlowType.ImplicitGrant:
                    // Implicit Grant Flow
                    return SpotifyClient.AuthUserImplicit(
                        redirectUri: AuthenticationRedirectUri,
                        state: AuthenticationState,
                        scope: _mapper.Map(authenticationScope),
                        showDialog: showAuthenticationDialog);
                default:
                    // Unsupported
                    throw new ArgumentOutOfRangeException(); 
            }
        }

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
        public async Task<AuthenticationTokenResponse> GetAuthenticationTokenAsync(
            AuthenticationFlowType authenticationFlowType,
            Uri authenticationResponseUri = null)
        {
            AuthenticationTokenResponse token = null;
            try
            {
                switch (authenticationFlowType)
                {
                    case AuthenticationFlowType.AuthorisationCode:
                        if (authenticationResponseUri == null)
                            throw new ArgumentNullException(nameof(authenticationResponseUri));
                        if (AuthenticationRedirectUri == null)
                            throw new ArgumentNullException(nameof(AuthenticationRedirectUri));
                        // Authorisation Code Flow
                        token = _mapper.Map(
                            await SpotifyClient.AuthUserAsync(
                            responseUri: authenticationResponseUri,
                            redirectUri: AuthenticationRedirectUri,
                            state: AuthenticationState));
                        break;
                    case AuthenticationFlowType.AuthorisationCodeWithProofKeyForCodeExchange:
                        if (authenticationResponseUri == null)
                            throw new ArgumentNullException(nameof(authenticationResponseUri));
                        if (AuthenticationRedirectUri == null)
                            throw new ArgumentNullException(nameof(AuthenticationRedirectUri));
                        // Authorization Code Flow With Proof Key For Code Exchange (PKCE)
                        token = _mapper.Map(
                            await SpotifyClient.AuthUserCodeAsync(
                                responseUri: authenticationResponseUri,
                                redirectUri: AuthenticationRedirectUri,
                                state: AuthenticationState));
                        break;
                    case AuthenticationFlowType.ClientCredentials:
                        token = _mapper.Map(accessToken: await SpotifyClient.AuthAsync());
                        break;
                    case AuthenticationFlowType.ImplicitGrant:
                        if (authenticationResponseUri == null)
                            throw new ArgumentNullException(nameof(authenticationResponseUri));
                        if (AuthenticationRedirectUri == null)
                            throw new ArgumentNullException(nameof(AuthenticationRedirectUri));
                        token = _mapper.Map(
                            accessToken: SpotifyClient.AuthUserImplicit(
                            responseUri: authenticationResponseUri,
                            redirectUri: AuthenticationRedirectUri,
                            state: AuthenticationState));
                        break;
                }
                IsUserLoggedIn = token.IsLoggedIn;
            }
            catch (AuthCodeValueException ex)
            {
                throw new AuthenticationAccessCodeNotFoundException(ex.Message, ex);
            }
            catch (AuthCodeStateException ex)
            {
                throw new AuthenticationStateNotMatchedException(ex.Message, ex);
            }
            catch (AuthTokenValueException ex)
            {
                throw new AuthenticationAccessTokenNotFoundException(ex.Message, ex);
            }
            catch (AuthTokenStateException ex)
            {
                throw new AuthenticationStateNotMatchedException(ex.Message, ex);
            }
            return token;
        }

        /// <summary>
        /// Set Authentication Token Client Credentials
        /// </summary>
        public async void SetAuthenticationTokenClientCredentialsAsync() => 
            AuthenticationToken = await GetAuthenticationTokenAsync(AuthenticationFlowType.ClientCredentials);

        /// <summary>
        /// Logout
        /// </summary>
        public void Logout()
        {
            CurrentUser = null;
            IsUserLoggedIn = false;
            AuthenticationToken = null;
        }
        #endregion Authentication Methods

        #region Public Events
        /// <summary>
        /// Authentication Token Required Event
        /// </summary>
        public event EventHandler<AuthenticationTokenRequiredArgs> AuthenticationTokenRequired;

        /// <summary>
        /// Client Exception Event
        /// </summary>
        public event EventHandler<ClientExceptionArgs> ClientException;

        /// <summary>
        /// Response Error Event
        /// </summary>
        public event EventHandler<ResponseErrorArgs> ResponseError;

        /// <summary>
        /// Response User Playback Success
        /// </summary>
        public event EventHandler<ResponseUserPlaybackArgs> ResponseUserPlaybackSuccess;
        #endregion Public Events

        #region Event Handlers
        /// <summary>
        /// Playlist Item Response Removed Handler
        /// </summary>
        /// <param name="response">Playlist Response</param>
        /// <param name="args">Playlist Item Response Removed Argument</param>
        public async void PlaylistItemResponseRemovedHandler(
            PlaylistResponse response,
            ResponseRemovedArgs<PlaylistItemResponse> args) =>
            await RemovePlaylistItemAsync(
                response.Id,
                args.Item.PlayItemType,
                args.Item?.Current?.Id,
                new List<int> { args.Index });

        /// <summary>
        /// Playlist Item Response Removed Handler
        /// </summary>
        /// <param name="response">Playlist Response</param>
        /// <param name="args">Playlist Item Response Removed Argument</param>
        public async void PlaylistItemResponseMovedHandler(
            PlaylistResponse response,
            ResponseMovedArgs args) =>
                await SetPlaylistItemOrderAsync(
                    response.Id,
                    args.SourceIndex,
                    args.TargetIndex);
        #endregion Event Handlers

        #region Get Methods
        /// <summary>
        /// Get Category
        /// </summary>
        /// <param name="categoryId">(Required) Spotify Category Id</param>
        /// <returns>Category Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<CategoryResponse> GetCategoryAsync(string categoryId)
        {
            CategoryResponse result = null;
            try
            {
                // Get a Category
                var response = await SpotifyClient.LookupCategoryAsync(
                    categoryId: categoryId,
                    country: Country,
                    locale: Locale);
                result = _mapper.Map(response);
                OnResponseError(result);
                this.AttachGetCategoryCommands(result);
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch(Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Get Artist
        /// </summary>
        /// <param name="artistId">(Required) Spotify Artist Id</param>
        /// <returns>Artist Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<ArtistResponse> GetArtistAsync(string artistId)
        {
            ArtistResponse result = null;
            try
            {
                // Get an Artist
                var response = await SpotifyClient.LookupAsync<Artist>(
                    itemId: artistId,
                    lookupType: LookupType.Artists);
                result = _mapper.Map(response);
                OnResponseError(result);
                this.AttachGetArtistCommands(result);
                await this.AttachGetArtistToggles(result);
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Get Playlist
        /// </summary>
        /// <param name="playlistId">(Required) Spotify Playlist Id</param>
        /// <param name="fields">(Optional) Filters for the query: a comma-separated list of the fields to return. If omitted, all fields are returned.</param>
        /// <returns>Playlist Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<PlaylistResponse> GetPlaylistAsync(
            string playlistId, 
            string fields = null)
        {
            PlaylistResponse result = null;
            try
            {
                // Get a Playlist
                var response = await SpotifyClient.LookupPlaylistAsync(
                    playlistId: playlistId,
                    market: Country,
                    fields: fields,
                    additionalTypes: additional_types);
                result = _mapper.Map(response);
                OnResponseError(result);
                this.SetPlaylistExtended(result);
                this.AttachGetPlaylistCommands(result);
                await this.AttachGetPlaylistToggles(result);
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Get Album
        /// </summary>
        /// <param name="albumId">(Required) Album Spotify Id</param>
        /// <returns>Album Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<AlbumResponse> GetAlbumAsync(string albumId)
        {
            AlbumResponse result = null;
            try
            {
                // Get an Album
                var response = await SpotifyClient.LookupAsync<Album>(
                    itemId: albumId, 
                    lookupType: LookupType.Albums, 
                    market: Country);
                result = _mapper.Map(response);
                OnResponseError(result);
                this.AttachGetAlbumCommands(result);
                await this.AttachGetAlbumToggles(result);
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Get Track
        /// </summary>
        /// <param name="trackId">(Required) Spotify Track Id</param>
        /// <returns>Track Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<TrackResponse> GetTrackAsync(string trackId)
        {
            TrackResponse result = null;
            try
            {
                // Get a Track
                var response = await SpotifyClient.LookupAsync<Track>(
                    itemId: trackId,
                    lookupType: LookupType.Tracks,
                    market: Country);
                result = _mapper.Map(response);
                OnResponseError(result);
                this.AttachGetTrackCommands(result);
                await this.AttachGetTrackToggles(result);
                await this.AttachGetTrackAudioFeatures(result);
                await this.AttachGetTrackAudioAnalysis(result);
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Get Track Audio Analysis
        /// </summary>
        /// <param name="trackId">(Required) Spotify Track Id</param>
        /// <returns>Audio Analysis Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<AudioAnalysisResponse> GetTrackAudioAnalysisAsync(string trackId)
        {
            AudioAnalysisResponse result = null;
            try
            {
                // Get Audio Analysis for a Track
                var response = await SpotifyClient.LookupAsync<AudioAnalysis>(
                    itemId: trackId,
                    lookupType: LookupType.AudioAnalysis);
                result = _mapper.Map(response);
                OnResponseError(result);
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Get Track Audio Features
        /// </summary>
        /// <param name="trackId">(Required) Spotify Track Id</param>
        /// <returns>Audio Features Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<AudioFeaturesResponse> GetTrackAudioFeaturesAsync(string trackId)
        {
            AudioFeaturesResponse result = null;
            try
            {
                // Get Audio Features for a Track
                var response = await SpotifyClient.LookupAsync<AudioFeatures>(
                    itemId: trackId, 
                    lookupType: LookupType.AudioFeatures);
                result = _mapper.Map(response);
                OnResponseError(result);
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Get Episode
        /// </summary>
        /// <param name="episodeId">(Required) Spotify Episode Id</param>
        /// <returns>Episode Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<EpisodeResponse> GetEpisodeAsync(string episodeId)
        {
            EpisodeResponse result = null;
            try
            {
                // Get an Episode
                var response = await SpotifyClient.LookupAsync<Episode>(
                    itemId: episodeId, 
                    lookupType: LookupType.Episodes, 
                    market: Country);
                result = _mapper.Map(response);
                OnResponseError(result);
                this.AttachGetEpisodeCommands(result);
                await this.AttachGetEpisodeToggles(result);
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Get Show
        /// </summary>
        /// <param name="showId">(Required) Spotify Show Id</param>
        /// <returns>Show Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<ShowResponse> GetShowAsync(string showId)
        {
            ShowResponse result = null;
            try
            {
                // Get a Show
                var response = await SpotifyClient.LookupAsync<Show>(
                    itemId: showId, 
                    lookupType: LookupType.Shows, 
                    market: Country);
                result = _mapper.Map(response);
                OnResponseError(result);
                this.AttachGetShowCommands(result);
                await this.AttachGetShowToggles(result);
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Get Current User
        /// <para>Scopes: UserReadEmail, UserReadPrivate</para>
        /// </summary>
        /// <returns>Current User Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<CurrentUserResponse> GetCurrentUserAsync()
        {
            CurrentUserResponse result = null;
            try
            {
                // Get Current User's Profile
                var currentUser = await SpotifyClient.AuthLookupUserProfileAsync();
                result = _mapper.Map(currentUser);
                OnResponseError(result);
                this.SetCurrentUserExtended(result);
                this.AttachGetCurrentUserCommands(result);
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Get User
        /// </summary>
        /// <param name="userId">(Required) Spotify User Id</param>
        /// <returns>User Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<UserResponse> GetUserAsync(string userId)
        {
            UserResponse result = null;
            try
            {
                // Get a User's Profile
                var user = await SpotifyClient.AuthLookupUserProfileAsync(userId);
                result = _mapper.Map(user);
                OnResponseError(result);
                this.AttachGetUserCommands(result);
                await this.AttachGetUserToggles(result);
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Get Playlist Image
        /// </summary>
        /// <param name="playlistId">(Required) Spotify Playlist Id</param>
        /// <returns>Playlist Image Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<PlaylistImageResponse> GetPlaylistImageAsync(string playlistId)
        {
            PlaylistImageResponse result = null;
            try
            {
                // Get a Playlist Cover Image
                var images = await SpotifyClient.AuthGetPlaylistCoverImageAsync(playlistId);
                result = _mapper.Map(images);
                result.SetPlaylistImageExtended(playlistId);
                this.AttachGetPlaylistImageCommands(result);
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Get User Currently Playing Item
        /// <para>Scopes: ConnectReadCurrentlyPlaying, ConnectReadPlaybackState</para>
        /// </summary>
        /// <returns>Currently Playing Item Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<CurrentlyPlayingItemResponse> GetUserCurrentlyPlayingItemAsync()
        {
            CurrentlyPlayingItemResponse result = null;
            try
            {
                // Get the User's Currently Playing Track 
                var currentlyPlayingItem = await SpotifyClient.AuthLookupUserPlaybackCurrentTrackAsync(
                market: Country, 
                additionalTypes: additional_types);
                result = _mapper.Map(currentlyPlayingItem);
                OnResponseError(result);
                this.AttachUserCurrentlyPlayingItemCommands(result);
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Get User Currently Playing
        /// <para>Scopes: ConnectReadPlaybackState</para>
        /// </summary>
        /// <returns>Currently Playing Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<CurrentlyPlayingResponse> GetUserCurrentlyPlayingAsync()
        {
            CurrentlyPlayingResponse result = null;
            try
            {
                // Get Information About The User's Current Playback
                var currentlyPlaying = await SpotifyClient.AuthLookupUserPlaybackCurrentAsync(
                market: Country,
                additionalTypes: additional_types);
                result = _mapper.Map(currentlyPlaying);
                OnResponseError(result);
                this.SetCurrentlyPlayingExtended(result);
                this.AttachGetUserCurrentlyPlayingCommands(result);
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Get Saved
        /// <para>Scopes: LibraryRead</para>
        /// </summary>
        /// <param name="savedType">(Required) Saved Type</param>
        /// <param name="id">(Required) Spotify Item Id</param>
        /// <returns>Bool Response</returns>
        public async Task<BoolResponse> GetSavedAsync(
            SavedType savedType,
            string id) =>
                Helpers.GetBoolResponse(await ListSavedAsync(
                savedType: savedType,
                multipleIds: new List<string> { id }));

        /// <summary>
        /// Get Follow
        /// <para>Scopes: FollowType.FollowArtist FollowType.FollowUser - FollowRead, FollowType.FollowPlaylist - PlaylistReadPrivate</para>
        /// </summary>
        /// <param name="followType">(Required) Follow Type</param>
        /// <param name="id">(Required) Spotify Item Id</param>
        /// <param name="userId">(Required) Only for FollowType.FollowPlaylist</param>
        /// <returns>Bool Response</returns>
        public async Task<BoolResponse> GetFollowAsync(
            FollowType followType,
            string id,
            string userId = null) => 
                Helpers.GetBoolResponse(await ListFollowAsync(
                followType: followType,
                multipleIds: new List<string> {
                    followType == FollowType.Playlist ? 
                    userId : 
                    id },
                playlistId: followType == FollowType.Playlist ? 
                    id : 
                    null));

        /// <summary>
        /// Get
        /// </summary>
        /// <typeparam name="TResponse">Response Type: CategoryResponse, ArtistResponse, PlaylistResponse, AlbumResponse, TrackResponse, AudioFeaturesResponse, AudioAnalysisResponse, EpisodeResponse, ShowResponse, CurrentUserResponse, UserResponse, PlaylistImageResponse, CurrentlyPlayingResponse, CurrentlyPlayingItemResponse</typeparam>
        /// <param name="id">Id</param>
        /// <returns>Response</returns>
        public async Task<TResponse> GetAsync<TResponse>(string id)
            where TResponse : class
        {
            switch (typeof(TResponse))
            {
                case Type category when category == typeof(CategoryResponse):
                    return await GetCategoryAsync(id) as TResponse;
                case Type artist when artist == typeof(ArtistResponse):
                    return await GetArtistAsync(id) as TResponse;
                case Type playlist when playlist == typeof(PlaylistResponse):
                    return await GetPlaylistAsync(id) as TResponse;
                case Type album when album == typeof(AlbumResponse):
                    return await GetAlbumAsync(id) as TResponse;
                case Type track when track == typeof(TrackResponse):
                    return await GetTrackAsync(id) as TResponse;
                case Type audioFeatures when audioFeatures == typeof(AudioFeaturesResponse):
                    return await GetTrackAudioFeaturesAsync(id) as TResponse;
                case Type audioAnalysis when audioAnalysis == typeof(AudioAnalysisResponse):
                    return await GetTrackAudioAnalysisAsync(id) as TResponse;
                case Type episode when episode == typeof(EpisodeResponse):
                    return await GetEpisodeAsync(id) as TResponse;
                case Type show when show == typeof(ShowResponse):
                    return await GetShowAsync(id) as TResponse;
                case Type currentUser when currentUser == typeof(CurrentUserResponse):
                    return await GetCurrentUserAsync() as TResponse;
                case Type user when user == typeof(UserResponse):
                    return await GetUserAsync(id) as TResponse;
                case Type playlistImage when playlistImage == typeof(PlaylistImageResponse):
                    return await GetPlaylistImageAsync(id) as TResponse;
                case Type currentlyPlaying when currentlyPlaying == typeof(CurrentlyPlayingResponse):
                    return await GetUserCurrentlyPlayingAsync() as TResponse;
                case Type currentlyPlayingItem when currentlyPlayingItem == typeof(CurrentlyPlayingItemResponse):
                    return await GetUserCurrentlyPlayingItemAsync() as TResponse;
                default:
                    throw new NotSupportedException();
            }
        }
        #endregion Get Methods

        #region Is Methods
        /// <summary>
        /// Is Playlist Owned by Current User?
        /// <para>Prerequisite: GetCurrentUser</para>
        /// </summary>
        /// <param name="playlist">Playlist Response</param>
        /// <returns>True if Playlist Owned, False if Not</returns>
        public bool IsPlaylistOwnedByCurrentUser(
            PlaylistResponse playlist) => 
            CurrentUser?.Id == playlist?.Owner?.Id;
        #endregion Is Methods

        #region List Methods
        /// <summary>
        /// List Categories
        /// </summary>
        /// <param name="categoriesRequest">(Optional) Categories Request</param>
        /// <returns>NavigationResponse of Category Responses</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<NavigationResponse<CategoryResponse>> ListCategoriesAsync(
            CategoriesRequest categoriesRequest = null)
        {
            NavigationResponse<CategoryResponse> result = null;
            try
            {
                // Get All Categories
                var page = Helpers.GetPage(categoriesRequest?.NavigationRequest, Limit);
                var response = await SpotifyClient.LookupAllCategoriesAsync(
                    country: categoriesRequest?.Country ?? Country, 
                    locale: categoriesRequest?.Locale ?? Locale, 
                    page: page);
                result = _mapper.MapFromPaging(response?.Categories);
                result.SetTypes(NavigationType, typeof(CategoryResponse));
                OnResponseError(result);
                this.AttachListCategoriesCommands(result);
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// List Categories
        /// </summary>
        /// <param name="navigationResponse">(Required) NavigationResponse of Category Responses</param>
        /// <returns>NavigationResponse of Category Responses</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<NavigationResponse<CategoryResponse>> ListCategoriesAsync(
            NavigationResponse<CategoryResponse> navigationResponse)
        {
            NavigationResponse<CategoryResponse> result = null;
            try
            {
                var navigateType = Helpers.GetNavigationType(NavigationType);
                if (navigationResponse?.Type != null && Helpers.IsNavigationValid(navigationResponse, navigateType))
                {
                    var paging = _mapper.MapToPaging(navigationResponse);
                    var response = await SpotifyClient.NavigateAsync(
                        paging: paging,
                        navigateType: navigateType);
                    result = _mapper.MapFromPaging(response?.Categories);
                    result.SetTypes(NavigationType, typeof(CategoryResponse));
                    OnResponseError(result);
                    this.AttachListCategoriesCommands(result);
                }
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// List Artists
        /// <para>Scopes: ArtistType.UserFollowed - FollowRead, UserFollowed.UserTop - LibraryRead</para>
        /// </summary>
        /// <param name="artistsRequest">(Required) Artists Request</param>
        /// <returns>Navigation Response of Artist Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<NavigationResponse<ArtistResponse>> ListArtistsAsync(
            ArtistsRequest artistsRequest)
        {
            NavigationResponse<ArtistResponse> result = null;
            try
            {
                var page = Helpers.GetPage(artistsRequest.NavigationRequest, Limit);
                var cursor = Helpers.GetCursor(artistsRequest.NavigationRequest, Limit);
                switch (artistsRequest.ArtistType)
                {
                    case ArtistType.Favourite:
                        // Get Favourite Artists
                        result = await this.GetFavouritesAsync<ArtistResponse>(
                            mapper: _mapper,
                            multipleIds: _favourites.ArtistIds);
                        break;
                    case ArtistType.Multiple:
                        // Get Multiple Artists
                        if (artistsRequest.MultipleArtistIds == null)
                            throw new ArgumentNullException(nameof(artistsRequest.MultipleArtistIds));
                        var multiple = await SpotifyClient.LookupAsync(
                            itemIds: artistsRequest.MultipleArtistIds, 
                            lookupType: LookupType.Artists);
                        result = _mapper.MapFromArtistList(multiple?.Artists);
                        break;
                    case ArtistType.Search:
                        // Search for an Item (Artists)
                        var search = await SpotifyClient.SearchAsync(
                            query: artistsRequest.Value, 
                            searchType: Helpers.SearchArtists(),
                            market: artistsRequest.Country ?? Country,
                            external: artistsRequest.SearchIsExternal,
                            page: page);
                        result = _mapper.MapFromPaging(search?.Artists);
                        break;
                    case ArtistType.Related:
                        // Get an Artist's Related Artists
                        var related = await SpotifyClient.LookupArtistRelatedArtistsAsync(
                            itemId: artistsRequest.Value);
                        result = _mapper.MapFromArtistList(related?.Artists);
                        break;
                    case ArtistType.UserFollowed:
                        // Get User's Followed Artists
                        var followed = await SpotifyClient.AuthLookupFollowedArtistsAsync(
                            cursor: cursor);
                        result = _mapper.MapFromCursorPaging(followed);
                        break;
                    case ArtistType.UserTop:
                        // Get a User's Top Artists (and Tracks)
                        var top = await SpotifyClient.AuthLookupUserTopArtistsAsync(
                             timeRange: Helpers.GetUserTopTimeRange(artistsRequest.UserTopTimeRangeType), 
                             cursor: cursor);
                        result = _mapper.MapFromCursorPaging(top);
                        break;
                }
                result.SetTypes(NavigationType, artistsRequest.ArtistType);
                OnResponseError(result);
                this.AttachListArtistsCommands(result);
                await this.AttachListArtistsToggles(result);
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// List Artists
        /// <para>Scopes: ArtistType.UserFollowed - FollowRead, UserFollowed.UserTop - LibraryRead</para>
        /// </summary>
        /// <param name="navigationResponse">(Required) Navigation Response of Artist Response</param>
        /// <returns>Navigation Response of Artist Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<NavigationResponse<ArtistResponse>> ListArtistsAsync(
            NavigationResponse<ArtistResponse> navigationResponse)
        {
            NavigationResponse<ArtistResponse> result = null;
            try
            {
                var navigateType = Helpers.GetNavigationType(NavigationType);
                if (navigationResponse?.Type != null && Helpers.IsNavigationValid(navigationResponse, navigateType))
                { 
                    var artistType = (ArtistType)navigationResponse.Type;
                    switch (artistType)
                    {
                        case ArtistType.Favourite:
                            // Get Favourite Artists
                            result = await this.GetFavouritesAsync<ArtistResponse>(
                                mapper: _mapper,
                                response: navigationResponse,
                                multipleIds: _favourites.ArtistIds);
                            break;
                        case ArtistType.UserFollowed:
                            var userFollowedCursor = _mapper.MapToCursorPaging(navigationResponse);
                            var userFollowedResponse = await SpotifyClient.AuthLookupFollowedArtistsAsync(
                                cursor: userFollowedCursor);
                            result = _mapper.MapFromCursorPaging(userFollowedResponse);
                            break;
                        case ArtistType.UserTop:
                            var userTopCursor = _mapper.MapToCursorPaging(navigationResponse);
                            var userTopResponse = await SpotifyClient.AuthNavigateAsync(
                                cursor: userTopCursor,
                                navigateType: navigateType);
                            result = _mapper.MapFromCursorPaging(userTopResponse);
                            break;
                        default:
                            var paging = _mapper.MapToPaging(navigationResponse);
                            var pagingResponse = await SpotifyClient.NavigateAsync(
                                paging: paging,
                                navigateType: navigateType);
                            result = _mapper.MapFromPaging(pagingResponse?.Artists);
                            break;
                    }
                    result.SetTypes(NavigationType, artistType);
                    OnResponseError(result);
                    this.AttachListArtistsCommands(result);
                    await this.AttachListArtistsToggles(result);
                }
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// List Albums
        /// <para>Scopes: AlbumType.UserSaved - LibraryRead</para>
        /// </summary>
        /// <param name="albumsRequest">(Required) Albums Request</param>
        /// <returns>Navigation Response of Album Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<NavigationResponse<AlbumResponse>> ListAlbumsAsync(
            AlbumsRequest albumsRequest)
        {
            NavigationResponse<AlbumResponse> result = null;
            try
            {
                var page = Helpers.GetPage(albumsRequest.NavigationRequest, Limit);
                var cursor = Helpers.GetCursor(albumsRequest.NavigationRequest, Limit);
                switch (albumsRequest.AlbumType)
                {
                    case AlbumType.Favourite:
                        // Get Favourite Albums
                        result = await this.GetFavouritesAsync<AlbumResponse>(
                            mapper: _mapper,
                            multipleIds: _favourites.AlbumIds);
                        break;
                    case AlbumType.Multiple:
                        // Get Multiple Albums
                        if (albumsRequest.MultipleAlbumIds == null)
                            throw new ArgumentNullException(nameof(albumsRequest.MultipleAlbumIds));
                        var multiple = await SpotifyClient.LookupAsync(
                            itemIds: albumsRequest.MultipleAlbumIds, 
                            lookupType: LookupType.Albums);
                        result = _mapper.MapFromAlbumList(multiple?.Albums);
                        break;
                    case AlbumType.Search:
                        // Search for an Item (Albums)
                        var search = await SpotifyClient.SearchAsync(
                            query: albumsRequest.Value, 
                            searchType: Helpers.SearchAlbums(),
                            market: albumsRequest.Country ?? Country,
                            external: albumsRequest.SearchIsExternal,
                            page: page);
                        result = _mapper.MapFromPaging(search?.Albums);
                        break;
                    case AlbumType.NewReleases:
                        // Get All New Releases
                        var releases = await SpotifyClient.LookupNewReleasesAsync(
                            country: Country, 
                            page: page);
                        result = _mapper.MapFromPaging(releases?.Albums);
                        break;
                    case AlbumType.Artist:
                        // Get an Artist's Albums
                        var albums = await SpotifyClient.LookupArtistAlbumsAsync(
                            itemId: albumsRequest.Value, 
                            includeGroup: _mapper.Map(albumsRequest.IncludeGroup),
                            market: albumsRequest.Country ?? Country, 
                            page: page);
                        result = _mapper.MapFromPaging(albums);
                        break;
                    case AlbumType.UserSaved:
                        // Get User's Saved Albums
                        var saved = await SpotifyClient.AuthLookupUserSavedAlbumsAsync(
                            market: albumsRequest.Country ?? Country, 
                            cursor: cursor);
                        result = _mapper.MapFromCursorPaging(saved);
                        break;
                }
                result.SetTypes(NavigationType, albumsRequest.AlbumType);
                OnResponseError(result);
                this.AttachListAlbumsCommands(result);
                await this.AttachListAlbumsToggles(result);
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// List Albums
        /// <para>Scopes: AlbumType.UserSaved - LibraryRead</para>
        /// </summary>
        /// <param name="navigationResponse">(Required) Navigation Response of Album Response</param>
        /// <returns>Navigation Response of Album Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<NavigationResponse<AlbumResponse>> ListAlbumsAsync(
            NavigationResponse<AlbumResponse> navigationResponse)
        {
            NavigationResponse<AlbumResponse> result = null;
            try
            {
                var navigateType = Helpers.GetNavigationType(NavigationType);
                if (navigationResponse?.Type != null && Helpers.IsNavigationValid(navigationResponse, navigateType))
                { 
                    var albumType = (AlbumType)navigationResponse.Type;
                    switch(albumType)
                    {
                        case AlbumType.Favourite:
                            // Get Favourite Albums
                            result = await this.GetFavouritesAsync(
                                mapper: _mapper,
                                response: navigationResponse,
                                multipleIds: _favourites.AlbumIds);
                            break;
                        case AlbumType.Artist:
                            var artistPaging = _mapper.MapToPaging(navigationResponse);
                            var artistResponse = await SpotifyClient.PagingAsync(artistPaging, navigateType);
                            result = _mapper.MapFromPaging(artistResponse);
                            break;
                        case AlbumType.UserSaved:
                            var cursor = _mapper.MapToCursorPagingSavedAlbum(navigationResponse);
                            var userSaved = await SpotifyClient.AuthNavigateAsync(
                                cursor: cursor,
                                navigateType: navigateType);
                            result = _mapper.MapFromCursorPaging(userSaved);
                            break;
                        default:
                            var paging = _mapper.MapToPaging(navigationResponse);
                            var response = await SpotifyClient.NavigateAsync(
                                paging: paging,
                                navigateType: navigateType);
                            result = _mapper.MapFromPaging(response?.Albums);
                        break;
                    }
                    result.SetTypes(NavigationType, albumType);
                    OnResponseError(result);
                    this.AttachListAlbumsCommands(result);
                    await this.AttachListAlbumsToggles(result);
                }
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// List Tracks
        /// <para>Scopes: TrackType.UserRecentlyPlayed - ListeningRecentlyPlayed, TrackType.UserSaved - LibraryRead, TrackType.UserTop - ListeningTopRead</para>
        /// </summary>
        /// <param name="tracksRequest">(Required) Tracks Request</param>
        /// <returns>Navigation Response of Track Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<NavigationResponse<TrackResponse>> ListTracksAsync(
            TracksRequest tracksRequest)
        {
            NavigationResponse<TrackResponse> result = null;
            try
            {
                var page = Helpers.GetPage(tracksRequest.NavigationRequest, Limit);
                var cursor = Helpers.GetCursor(tracksRequest.NavigationRequest, Limit);
                switch (tracksRequest.TrackType)
                {
                    case TrackType.Favourite:
                        // Get Favourite Tracks
                        result = await this.GetFavouritesAsync<TrackResponse>(
                            mapper: _mapper,
                            multipleIds: _favourites?.TrackIds);
                        break;
                    case TrackType.Multiple:
                        // Get Several Tracks
                        if (tracksRequest.MultipleTrackIds == null)
                            throw new ArgumentNullException(nameof(tracksRequest.MultipleTrackIds));
                        var multiple = await SpotifyClient.LookupAsync(
                            itemIds: tracksRequest.MultipleTrackIds, 
                            lookupType: LookupType.Tracks);
                        result = _mapper.MapFromTrackList(multiple?.Tracks);
                        break;
                    case TrackType.Search:
                        // Search for an Item (Tracks)
                        var search = await SpotifyClient.SearchAsync(
                            query: tracksRequest.Value, 
                            searchType: Helpers.SearchTracks(), 
                            market: tracksRequest.Country ?? Country,
                            external: tracksRequest.SearchIsExternal,
                            page: page);
                        result = _mapper.MapFromPaging(search?.Tracks);
                        break;
                    case TrackType.Recommended:
                        // Get Recommendations                       
                        result = await SpotifyClient.GetRecommendationsAsync(
                            mapper: _mapper,
                            country: tracksRequest.Country ?? Country,
                            recommendationRequest: tracksRequest?.Recommendation);
                        break;
                    case TrackType.Album:
                        // Get an Album's Tracks
                        var albumTracks = await SpotifyClient.LookupAsync<Paging<Track>>(
                            itemId: tracksRequest.Value, 
                            lookupType: LookupType.AlbumTracks,
                            market: tracksRequest.Country ?? Country, 
                            page: page);
                        result = _mapper.MapFromPaging(albumTracks);
                        break;
                    case TrackType.Artist:
                        // Get an Artist's Top Tracks
                        var artistTracks = await SpotifyClient.LookupArtistTopTracksAsync(
                            itemId: tracksRequest.Value, 
                            market: tracksRequest.Country ?? Country);
                        result = _mapper.MapFromTrackList(artistTracks?.Tracks);
                        break;
                    case TrackType.UserRecentlyPlayed:
                        // Get Current User's Recently Played Tracks
                        var played = await SpotifyClient.AuthLookupUserRecentlyPlayedTracksAsync(
                            cursor: cursor);
                        result = _mapper.MapFromCursorPaging(played);
                        break;
                    case TrackType.UserSaved:
                        // Get User's Saved Tracks
                        var saved = await SpotifyClient.AuthLookupUserSavedTracksAsync(
                            market: tracksRequest.Country ?? Country, 
                            cursor: cursor);
                        result = _mapper.MapFromCursorPaging(saved);
                        break;
                    case TrackType.UserTop:
                        // Get a User's Top Artists and Tracks
                        var top = await SpotifyClient.AuthLookupUserTopTracksAsync(
                             cursor: cursor);
                        result = _mapper.MapFromCursorPaging(top);
                        break;
                }
                result.SetTypes(NavigationType, tracksRequest.TrackType);
                OnResponseError(result);
                this.AttachListTracksCommands(result);
                await this.AttachListTracksToggles(result);
                await this.AttachListTracksAudioFeatures(result);
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// List Tracks
        /// <para>Scopes: TrackType.UserRecentlyPlayed - ListeningRecentlyPlayed, TrackType.UserSaved - LibraryRead, TrackType.UserTop - ListeningTopRead</para>
        /// </summary>
        /// <param name="navigationResponse">(Required) Navigation Response of Track Response</param>
        /// <returns>Navigation Response of Track Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<NavigationResponse<TrackResponse>> ListTracksAsync(
            NavigationResponse<TrackResponse> navigationResponse)
        {
            NavigationResponse<TrackResponse> result = null;
            try
            {
                var navigateType = Helpers.GetNavigationType(NavigationType);
                if (navigationResponse?.Type != null && Helpers.IsNavigationValid(navigationResponse, navigateType))
                {
                    var trackType = (TrackType)navigationResponse.Type;
                    switch (trackType)
                    {
                        case TrackType.Favourite:
                            // Get Favourite Tracks
                            result = await this.GetFavouritesAsync(
                                mapper: _mapper,
                                response: navigationResponse,
                                multipleIds: _favourites?.TrackIds);
                            break;
                        case TrackType.Album:
                            var pagingAlbum = _mapper.MapToPagingTrack(navigationResponse);
                            var responseAlbum = await SpotifyClient.PagingAsync(
                                paging: pagingAlbum,
                                navigateType: navigateType);
                            result = _mapper.MapFromPaging(responseAlbum);
                            break;
                        case TrackType.UserRecentlyPlayed:
                            var playHistory = _mapper.MapToCursorPagingPlayHistory(navigationResponse);
                            var recentlyPlayed = await SpotifyClient.AuthNavigateAsync(
                                cursor: playHistory,
                                navigateType: navigateType);
                            result = _mapper.MapFromCursorPaging(recentlyPlayed);
                            break;
                        case TrackType.UserSaved:
                            var savedTrack = _mapper.MapToCursorPagingSavedTrack(navigationResponse);
                            var userSaved = await SpotifyClient.AuthNavigateAsync(
                                cursor: savedTrack,
                                navigateType: navigateType);
                            result = _mapper.MapFromCursorPaging(userSaved);
                            break;
                        case TrackType.UserTop:
                            var cursor = _mapper.MapToCursorPagingTrack(navigationResponse);
                            var userTop = await SpotifyClient.AuthNavigateAsync(
                                cursor: cursor,
                                navigateType: navigateType);
                            result = _mapper.MapFromCursorPaging(userTop);
                            break;
                        default:
                            var paging = _mapper.MapToPagingTrack(navigationResponse);
                            var response = await SpotifyClient.NavigateAsync(
                                paging: paging,
                                navigateType: navigateType);
                            result = _mapper.MapFromPaging(response?.Tracks);
                            break;
                    }
                    result.SetTypes(NavigationType, trackType);
                    OnResponseError(result);
                    this.AttachListTracksCommands(result);
                    await this.AttachListTracksToggles(result);
                    await this.AttachListTracksAudioFeatures(result);
                }
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// List Playlists
        /// <para>Scopes: PlaylistType.CurrentUser - PlaylistReadPrivate, PlaylistReadCollaborative</para>
        /// </summary>
        /// <param name="playlistsRequest">(Required) Playlists Request</param>
        /// <returns>Navigation Response of Playlist Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<NavigationResponse<PlaylistResponse>> ListPlaylistsAsync(
            PlaylistsRequest playlistsRequest)
        {
            NavigationResponse<PlaylistResponse> result = null;
            try
            {
                var page = Helpers.GetPage(playlistsRequest.NavigationRequest, Limit);
                var cursor = Helpers.GetCursor(playlistsRequest.NavigationRequest, Limit);
                switch (playlistsRequest.PlaylistType)
                {
                    case PlaylistType.Search:
                        // Search for an Item (Playlists)
                        var search = await SpotifyClient.SearchAsync(
                            query: playlistsRequest.Value,
                            searchType: Helpers.SearchPlaylists(),
                            market: playlistsRequest.Country ?? Country,
                            external: playlistsRequest.SearchIsExternal,
                            page: page);
                        result = _mapper.MapFromPaging(search?.Playlists);
                        break;
                    case PlaylistType.Featured:
                        // Get All Featured Playlists
                        var featured = await SpotifyClient.LookupFeaturedPlaylistsAsync(
                            country: playlistsRequest.Country ?? Country, 
                            locale: playlistsRequest.Locale ?? Locale, 
                            page: page);
                        result = _mapper.MapFromPaging(featured?.Playlists);
                        break;
                    case PlaylistType.Category:
                        // Get a Category's Playlists
                        var categoryPlaylists = await SpotifyClient.LookupAsync<ContentResponse>(
                            itemId: playlistsRequest.Value, 
                            lookupType: LookupType.CategoriesPlaylists,
                            market: playlistsRequest.Country ?? Country, 
                            page: page);
                        result = _mapper.MapFromPaging(categoryPlaylists?.Playlists);
                        break;
                    case PlaylistType.User:
                        // Get a List of a User's Playlists
                        var user = await SpotifyClient.AuthLookupUserPlaylistsAsync(
                            userId: playlistsRequest.Value,
                            cursor: cursor);
                        result = _mapper.MapFromCursorPaging(user);
                        break;
                    case PlaylistType.CurrentUser:
                        // Get a List of Current User's Playlists
                        var current = await SpotifyClient.AuthLookupUserPlaylistsAsync(
                                cursor: cursor);
                        result = _mapper.MapFromCursorPaging(current);
                        break;
                    case PlaylistType.CurrentUserAddable:
                        // Get a List of Current User's Playlists that can be Added to
                        var addable = await SpotifyClient.AuthLookupUserAddablePlaylistsAsync();
                        result = _mapper.MapFromList(addable);
                        break;
                }
                result.SetTypes(NavigationType, playlistsRequest.PlaylistType);
                OnResponseError(result);
                this.SetPlaylistsExtended(result);
                this.AttachListPlaylistsCommands(result);
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// List Playlists
        /// <para>Scopes: PlaylistType.CurrentUser - PlaylistReadPrivate, PlaylistReadCollaborative</para>
        /// </summary>
        /// <param name="navigationResponse">(Required) Navigation Response of Playlist Response</param>
        /// <returns>Navigation Response of Playlist Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<NavigationResponse<PlaylistResponse>> ListPlaylistsAsync(
            NavigationResponse<PlaylistResponse> navigationResponse)
        {
            NavigationResponse<PlaylistResponse> result = null;
            try
            {
                var navigateType = Helpers.GetNavigationType(NavigationType);
                if (navigationResponse?.Type != null && Helpers.IsNavigationValid(navigationResponse, navigateType))
                {
                    var playlistType = (PlaylistType)navigationResponse.Type;
                    if (playlistType == PlaylistType.User || playlistType == PlaylistType.CurrentUser)
                    {
                        var cursor = _mapper.MapToCursorPaging(navigationResponse);
                        var response = await SpotifyClient.AuthNavigateAsync(
                            cursor: cursor,
                            navigateType: navigateType);
                        result = _mapper.MapFromCursorPaging(response);
                    }
                    else
                    {
                        var paging = _mapper.MapToPaging(navigationResponse);
                        var response = await SpotifyClient.NavigateAsync(
                            paging: paging,
                            navigateType: navigateType);
                        result = _mapper.MapFromPaging(response?.Playlists);
                    }
                    result.SetTypes(NavigationType, playlistType);
                    OnResponseError(result);
                    this.SetPlaylistsExtended(result);
                    this.AttachListPlaylistsCommands(result);
                }
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// List Playlist Items
        /// </summary>
        /// <param name="playlistItemsRequest">(Required) Playlist Items Request</param>
        /// <returns>Navigation Response of Track Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<NavigationResponse<PlaylistItemResponse>> ListPlaylistItemsAsync(
            PlaylistItemsRequest playlistItemsRequest)
        {
            NavigationResponse<PlaylistItemResponse> result = null;
            try
            {
                // Get a Playlist's Items
                var page = Helpers.GetPage(playlistItemsRequest.NavigationRequest, Limit);
                var response = await SpotifyClient.LookupPlaylistItemsAsync(
                    id: playlistItemsRequest.PlaylistId,
                    market: playlistItemsRequest.Country ?? Country,
                    fields: playlistItemsRequest.Fields,
                    page: page,
                    additionalTypes: additional_types);
                result = _mapper.MapFromPaging(response);
                result.SetTypes(NavigationType, typeof(PlaylistItemResponse));
                OnResponseError(result);
                this.AttachListPlaylistItemsCommands(result);
                await this.AttachListPlaylistItemsToggles(result);
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// List Playlist Items
        /// </summary>
        /// <param name="navigationResponse">(Required) Navigation Response of Playlist Item Response</param>
        /// <returns>Navigation Response of Playlist Item Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<NavigationResponse<PlaylistItemResponse>> ListPlaylistItemsAsync(
            NavigationResponse<PlaylistItemResponse> navigationResponse)
        {
            NavigationResponse<PlaylistItemResponse> result = null;
            try
            {
                var navigateType = Helpers.GetNavigationType(NavigationType);
                if (navigationResponse?.Type != null && Helpers.IsNavigationValid(navigationResponse, navigateType))
                {
                    var paging = _mapper.MapToPagingPlaylistTrack(navigationResponse);
                    var response = await SpotifyClient.PagingAsync(
                        paging: paging,
                        navigateType: navigateType);
                    result = _mapper.MapFromPaging(response);
                    result.SetTypes(NavigationType, typeof(PlaylistItemResponse));
                    OnResponseError(result);
                    this.AttachListPlaylistItemsCommands(result);
                    await this.AttachListPlaylistItemsToggles(result);
                }
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// List Episodes
        /// </summary>
        /// <param name="episodesRequest">(Required) Episodes Request</param>
        /// <returns>Navigation Response of Episode Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<NavigationResponse<EpisodeResponse>> ListEpisodesAsync(
            EpisodesRequest episodesRequest)
        {
            NavigationResponse<EpisodeResponse> result = null;
            try
            {
                var page = Helpers.GetPage(episodesRequest.NavigationRequest, Limit);
                switch (episodesRequest.EpisodeType)
                {
                    case EpisodeType.Favourite:
                        // Get Favourite Episodes
                        result = await this.GetFavouritesAsync<EpisodeResponse>(
                            mapper: _mapper,
                            multipleIds: _favourites.EpisodeIds,
                            market: Country);
                        break;
                    case EpisodeType.Multiple:
                        // Get Multiple Episodes
                        if (episodesRequest.MultipleEpisodeIds == null)
                            throw new ArgumentNullException(nameof(episodesRequest.MultipleEpisodeIds));
                        var multiple = await SpotifyClient.LookupAsync(
                            itemIds: episodesRequest.MultipleEpisodeIds,
                            lookupType: LookupType.Episodes,
                            market: episodesRequest.Country ?? Country);
                        result = _mapper.MapFromEpisodeList(multiple?.Episodes);
                        break;
                    case EpisodeType.Search:
                        // Search for an Item (Episodes)
                        var search = await SpotifyClient.SearchAsync(
                            query: episodesRequest.Value,
                            searchType: Helpers.SearchEpisodes(),
                            market: episodesRequest.Country ?? Country,
                            external: episodesRequest.SearchIsExternal,
                            page: page);
                        result = _mapper.MapFromPaging(search?.Episodes);
                        break;
                    case EpisodeType.Show:
                        // Get a Show's Episodes
                        var showEpisodes = await SpotifyClient.LookupAsync<Paging<SimplifiedEpisode>>(
                            itemId: episodesRequest.Value, 
                            lookupType: LookupType.ShowEpisodes, 
                            market: episodesRequest.Country ?? Country, 
                            page: page);
                        result = _mapper.MapFromPaging(showEpisodes);
                        break;
                }
                result.SetTypes(NavigationType, episodesRequest.EpisodeType);
                OnResponseError(result);
                this.AttachListEpisodesCommands(result);
                await this.AttachListEpisodesToggles(result);
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// List Episodes
        /// </summary>
        /// <param name="navigationResponse">(Required) Navigation Response of Episode Response</param>
        /// <returns>Navigation Response of Episode Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<NavigationResponse<EpisodeResponse>> ListEpisodesAsync(
            NavigationResponse<EpisodeResponse> navigationResponse)
        {
            NavigationResponse<EpisodeResponse> result = null;
            try
            {
                var navigateType = Helpers.GetNavigationType(NavigationType);
                if (navigationResponse?.Type != null && Helpers.IsNavigationValid(navigationResponse, navigateType))
                {
                    var episodeType = (EpisodeType)navigationResponse.Type;
                    if(episodeType == EpisodeType.Favourite)
                    { 
                        // Get Favourite Episodes
                        result = await this.GetFavouritesAsync(
                            mapper: _mapper,
                            response: navigationResponse,
                            multipleIds: _favourites.EpisodeIds,
                            market: Country);
                    }
                    else if(episodeType == EpisodeType.Multiple || episodeType == EpisodeType.Search)
                    { 
                        var paging = _mapper.MapToPaging(navigationResponse);
                        var response = await SpotifyClient.NavigateAsync(
                            paging: paging,
                            navigateType: navigateType);
                        result = _mapper.MapFromPaging(response?.Episodes);
                    }
                    else
                    {
                        var showPaging = _mapper.MapToPaging(navigationResponse);
                        var response = await SpotifyClient.PagingAsync(
                            paging: showPaging,
                            navigateType: navigateType);
                        result = _mapper.MapFromPaging(response);
                    }
                    result.SetTypes(NavigationType, episodeType);
                    OnResponseError(result);
                    this.AttachListEpisodesCommands(result);
                    await this.AttachListEpisodesToggles(result);
                }
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// List Shows
        /// <para>Scopes: ShowType.UserSaved - LibraryRead</para>
        /// </summary>
        /// <param name="showsRequest">(Required) Shows Request</param>
        /// <returns>Navigation Response of Episode Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<NavigationResponse<ShowResponse>> ListShowsAsync(
            ShowsRequest showsRequest)
        {
            NavigationResponse<ShowResponse> result = null;
            try
            {
                var page = Helpers.GetPage(showsRequest.NavigationRequest, Limit);
                var cursor = Helpers.GetCursor(showsRequest.NavigationRequest, Limit);
                switch (showsRequest.ShowType)
                {
                    case ShowType.Favourite:
                        // Get Favourite Shows
                        result = await this.GetFavouritesAsync<ShowResponse>(
                            mapper: _mapper,
                            multipleIds: _favourites.ShowIds,
                            market: Country);
                        break;
                    case ShowType.Multiple:
                        // Get Multiple Shows
                        if (showsRequest.MultipleShowIds == null)
                            throw new ArgumentNullException(nameof(showsRequest.MultipleShowIds));
                        var multiple = await SpotifyClient.LookupAsync(
                            itemIds: showsRequest.MultipleShowIds,
                            lookupType: LookupType.Shows,
                            market: showsRequest.Country ?? Country);
                        result = _mapper.MapFromShowList(multiple?.Shows);
                        break;
                    case ShowType.Search:
                        // Search for an Item (Shows)
                        var search = await SpotifyClient.SearchAsync(
                            query: showsRequest.Value,
                            searchType: Helpers.SearchShows(),
                            market: showsRequest.Country ?? Country,
                            external: showsRequest.SearchIsExternal,
                            page: page);
                        result = _mapper.MapFromPaging(search?.Shows);
                        break;
                    case ShowType.UserSaved:
                        // Get User's Saved Shows
                        var saved = await SpotifyClient.AuthLookupUserSavedShowsAsync(
                            cursor: cursor);
                        result = _mapper.MapFromCursorPaging(saved);
                        break;
                }
                result.SetTypes(NavigationType, showsRequest.ShowType);
                OnResponseError(result);
                this.AttachListShowsCommands(result);
                await this.AttachListShowsToggles(result);
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// List Shows
        /// <para>Scopes: ShowType.UserSaved - LibraryRead</para>
        /// </summary>
        /// <param name="navigationResponse">(Required) Navigation Response of Show Response</param>
        /// <returns>Navigation Response of Show Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<NavigationResponse<ShowResponse>> ListShowsAsync(
            NavigationResponse<ShowResponse> navigationResponse)
        {
            NavigationResponse<ShowResponse> result = null;
            try
            {
                var navigateType = Helpers.GetNavigationType(NavigationType);
                if (navigationResponse?.Type != null && Helpers.IsNavigationValid(navigationResponse, navigateType))
                {
                    var showType = (ShowType)navigationResponse.Type;
                    if (showType == ShowType.Favourite)
                    { 
                        // Get Favourite Shows
                        result = await this.GetFavouritesAsync(
                            mapper: _mapper,
                            response: navigationResponse,
                            multipleIds: _favourites.ShowIds,
                            market: Country);
                    }
                    else if (showType == ShowType.UserSaved)
                    {
                        // Get User's Saved Shows
                        var cursor = _mapper.MapToCursorPaging(navigationResponse);
                        var response = await SpotifyClient.AuthNavigateAsync(
                            cursor: cursor,
                            navigateType: navigateType);
                        result = _mapper.MapFromCursorPaging(response);
                    }
                    else
                    {
                        var paging = _mapper.MapToPaging(navigationResponse);
                        var response = await SpotifyClient.NavigateAsync(
                            paging: paging,
                            navigateType: navigateType);
                        result = _mapper.MapFromPaging(response?.Shows);
                    }
                    result.SetTypes(NavigationType, showType);
                    OnResponseError(result);
                    this.AttachListShowsCommands(result);
                    await this.AttachListShowsToggles(result);
                }
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// List Recommendation Genres
        /// </summary>
        /// <returns>List of Recommendation Genre Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<NavigationResponse<RecommendationGenreResponse>> ListRecommendationGenresAsync()
        {
            NavigationResponse<RecommendationGenreResponse> result = null;
            try
            {
                // Get Recommendation Genres
                var response = await SpotifyClient.LookupRecommendationGenres();
                result = _mapper.Map(response);
                OnResponseError(result);
                this.AttachListRecommendationGenresCommands(result);
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// List Audio Features
        /// </summary>
        /// <param name="audioFeaturesRequest">(Required) Audio Features Request</param>
        /// <returns>List of Audio Features Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<NavigationResponse<AudioFeaturesResponse>> ListAudioFeaturesAsync(
            AudioFeaturesRequest audioFeaturesRequest)
        {
            NavigationResponse<AudioFeaturesResponse> result = null;
            try
            {
                // Get Audio Features for Several Tracks
                var response = await SpotifyClient.LookupAsync(
                   itemIds: audioFeaturesRequest.MultipleTrackIds,
                   lookupType: LookupType.AudioFeatures);
                result = _mapper.MapFromAudioFeaturesList(response?.AudioFeatures);
                result.SetTypes(NavigationType, typeof(AudioFeaturesResponse));
                OnResponseError(result);
            }
            catch (AuthAccessTokenRequiredException)
            {
                OnAuthenticationTokenRequired();
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// List User Devices
        /// <para>Scopes: ConnectReadPlaybackState</para>
        /// </summary>
        /// <returns>Navigation Response of Device Response</returns>
        /// <exception cref="AuthenticationTokenRequiredException">Thrown if AuthenticationTokenRequired Event not Subscribed to</exception>
        public async Task<NavigationResponse<DeviceResponse>> ListUserDevicesAsync()
        {
            NavigationResponse<DeviceResponse> result = null;
            try
            {
                // Get a User's Available Devices
                var response = await SpotifyClient.AuthLookupUserPlaybackDevicesAsync();
                result = _mapper.MapFromDeviceList(response);
                result.SetTypes(NavigationType, typeof(DeviceResponse));
                OnResponseError(result);
                this.AttachListDevicesCommands(result);
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// List Saved
        /// </summary>
        /// <para>Scopes: LibraryRead</para>
        /// <param name="savedType">(Required) Saved Type</param>
        /// <param name="multipleIds">(Required) SavedType.Album - Multiple Spotify Album Ids, SavedType.Track - Multiple Spotify Track Ids, SavedType.Show - Multiple Spotify Show Ids</param>
        /// <returns>Navigation Response of bool</returns>
        public async Task<NavigationResponse<bool>> ListSavedAsync(
            SavedType savedType,
            List<string> multipleIds)
        {
            NavigationResponse<bool> result = null;
            try
            {
                Bools bools = null;
                switch (savedType)
                {
                    // Check User's Saved Albums
                    case SavedType.Album:
                        bools = await SpotifyClient.AuthLookupCheckUserSavedAlbumsAsync(
                            itemIds: multipleIds);
                        break;
                    // Check User's Saved Tracks
                    case SavedType.Track:
                        bools = await SpotifyClient.AuthLookupCheckUserSavedTracksAsync(
                            itemIds: multipleIds);
                        break;
                    // Check User's Saved Shows
                    case SavedType.Show:
                        bools = await SpotifyClient.AuthLookupCheckUserSavedShowsAsync(
                            itemIds: multipleIds);
                        break;
                }
                result = _mapper.MapToNavigationResponse(bools);
                result.SetTypes(NavigationType, savedType);
                OnResponseError(result);
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// List Follow
        /// </summary>
        /// <para>Scopes: FollowType.FollowArtist FollowType.FollowUser : FollowRead, FollowType.FollowPlaylist : PlaylistReadPrivate</para>
        /// <param name="followType">(Required) FollowType Type</param>
        /// <param name="multipleIds">(Required) FollowType.FollowArtist - Multiple Spotify Artist Ids, FollowType.FollowUser and FollowType.Playlist - Multiple Spotify User Ids</param>
        /// <param name="playlistId">(Required) Only for FollowType.FollowPlaylist</param>
        /// <returns>Navigation Response of bool</returns>
        public async Task<NavigationResponse<bool>> ListFollowAsync(
            FollowType followType,
            List<string> multipleIds,
            string playlistId = null)
        {
            NavigationResponse<bool> result = null;
            try
            {
                Bools bools = null;
                switch (followType)
                {
                    // Get Following State for Artists/Users
                    case FollowType.Artist:
                    case FollowType.User:
                        bools = await SpotifyClient.AuthLookupFollowingStateAsync(
                            itemIds: multipleIds,
                            followType: Helpers.GetApiFollowType(followType));
                        break;
                    // Check if Users Follow a Playlist
                    case FollowType.Playlist:
                        if (playlistId == null)
                            throw new ArgumentNullException(nameof(playlistId));
                        bools = await SpotifyClient.AuthLookupUserFollowingPlaylistAsync(
                            itemIds: multipleIds,
                            playlistId);
                        break;
                }
                result = _mapper.MapToNavigationResponse(bools);
                result.SetTypes(NavigationType, followType);
                OnResponseError(result);
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// List
        /// </summary>
        /// <typeparam name="TRequest">Request Type: CategoriesRequest, ArtistsRequest, PlaylistsRequest, PlaylistItemsRequest, AlbumsRequest, TracksRequest, AudioFeaturesRequest, EpisodesRequest, ShowsRequest</typeparam>
        /// <typeparam name="TResponse">Response Type: CategoryResponse, ArtistResponse, PlaylistResponse, PlaylistItemResponse, AlbumResponse, TrackResponse, AudioFeaturesResponse, EpisodeResponse, ShowResponse, DeviceResponse, RecommendationGenreResponse</typeparam>
        /// <param name="request">Request</param>
        /// <returns>Navigation Response of Response</returns>
        public async Task<NavigationResponse<TResponse>> ListAsync<TRequest, TResponse>(
            TRequest request)
            where TRequest : class
            where TResponse : class
        {
            switch (typeof(TResponse))
            {
                case Type category when category == typeof(CategoryResponse):
                    return await ListCategoriesAsync(request as CategoriesRequest)
                        as NavigationResponse<TResponse>;
                case Type artist when artist == typeof(ArtistResponse):
                    return await ListArtistsAsync(request as ArtistsRequest)
                        as NavigationResponse<TResponse>;
                case Type playlist when playlist == typeof(PlaylistResponse):
                    return await ListPlaylistsAsync(request as PlaylistsRequest)
                        as NavigationResponse<TResponse>;
                case Type playlist when playlist == typeof(PlaylistItemResponse):
                    return await ListPlaylistItemsAsync(request as PlaylistItemsRequest)
                        as NavigationResponse<TResponse>;
                case Type album when album == typeof(AlbumResponse):
                    return await ListAlbumsAsync(request as AlbumsRequest)
                        as NavigationResponse<TResponse>;
                case Type track when track == typeof(TrackResponse):
                    return await ListTracksAsync(request as TracksRequest)
                        as NavigationResponse<TResponse>;
                case Type audioFeatures when audioFeatures == typeof(AudioFeaturesResponse):
                    return await ListAudioFeaturesAsync(request as AudioFeaturesRequest)
                        as NavigationResponse<TResponse>;
                case Type episode when episode == typeof(EpisodeResponse):
                    return await ListEpisodesAsync(request as EpisodesRequest)
                        as NavigationResponse<TResponse>;
                case Type show when show == typeof(ShowResponse):
                    return await ListShowsAsync(request as ShowsRequest)
                        as NavigationResponse<TResponse>;
                case Type device when device == typeof(DeviceResponse):
                    return await ListUserDevicesAsync()
                        as NavigationResponse<TResponse>;
                case Type recommendationGenre when recommendationGenre == typeof(RecommendationGenreResponse):
                    return await ListRecommendationGenresAsync()
                        as NavigationResponse<TResponse>;
                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// List
        /// </summary>
        /// <typeparam name="TResponse">Response Type: CategoryResponse, ArtistResponse, PlaylistResponse, PlaylistItemResponse, AlbumResponse, TrackResponse, AudioFeaturesResponse, EpisodeResponse, ShowResponse</typeparam>
        /// <returns>Navigation Response of Response</returns>
        public async Task<NavigationResponse<TResponse>> ListAsync<TResponse>(
            NavigationResponse<TResponse> response)
            where TResponse : class
        {
            switch (typeof(TResponse))
            {
                case Type category when category == typeof(CategoryResponse):
                    return await ListCategoriesAsync(response as NavigationResponse<CategoryResponse>)
                        as NavigationResponse<TResponse>;
                case Type artist when artist == typeof(ArtistResponse):
                    return await ListArtistsAsync(response as NavigationResponse<ArtistResponse>)
                        as NavigationResponse<TResponse>;
                case Type playlist when playlist == typeof(PlaylistResponse):
                    return await ListPlaylistsAsync(response as NavigationResponse<PlaylistResponse>)
                        as NavigationResponse<TResponse>;
                case Type playlist when playlist == typeof(PlaylistItemResponse):
                    return await ListPlaylistItemsAsync(response as NavigationResponse<PlaylistItemResponse>)
                        as NavigationResponse<TResponse>;
                case Type album when album == typeof(AlbumResponse):
                    return await ListAlbumsAsync(response as NavigationResponse<AlbumResponse>)
                        as NavigationResponse<TResponse>;
                case Type track when track == typeof(TrackResponse):
                    return await ListTracksAsync(response as NavigationResponse<TrackResponse>)
                        as NavigationResponse<TResponse>;
                case Type audioFeatures when audioFeatures == typeof(AudioFeaturesResponse):
                    return null;
                case Type episode when episode == typeof(EpisodeResponse):
                    return await ListEpisodesAsync(response as NavigationResponse<EpisodeResponse>)
                        as NavigationResponse<TResponse>;
                case Type show when show == typeof(ShowResponse):
                    return await ListShowsAsync(response as NavigationResponse<ShowResponse>)
                        as NavigationResponse<TResponse>;
                case Type device when device == typeof(DeviceResponse):
                    return null;
                case Type recommendationGenre when recommendationGenre == typeof(RecommendationGenreResponse):
                    return null;
                default:
                    throw new NotSupportedException();
            }
        }
        #endregion List Methods

        #region Search Method
        /// <summary>
        /// Search
        /// </summary>
        /// <param name="searchRequest">(Required) Search Request</param>
        /// <returns>Search Response</returns>
        public async Task<SearchResponse> SearchAsync(
            SearchRequest searchRequest)
        {
            SearchResponse result = null;
            if (searchRequest != null)
            {
                var page = Helpers.GetPage(searchRequest.NavigationRequest, Limit);
                try
                {
                    var search = await SpotifyClient.SearchAsync(
                        query: searchRequest.Query,
                        searchType: _mapper.Map(searchRequest.SearchTypeRequest),
                        market: searchRequest.Country ?? Country,
                        external: searchRequest.External,
                        page: page);
                    result = _mapper.MapSearch(search);
                    OnResponseError(result);
                }
                catch (AuthAccessTokenRequiredException)
                {
                    OnAuthenticationTokenRequired();
                }
                catch (Exception ex)
                {
                    OnClientException(ex);
                }
            }
            return result;
        }
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
        public async Task<StatusResponse> SetUserPlaybackAsync(
            PlaybackType playbackType, 
            string deviceId = null,
            int? option = null)
        {
            StatusResponse result = null;
            try
            {
                Status status = null;
                switch(playbackType)
                {
                    case PlaybackType.Device:
                        // Transfer a User's Playback
                        status = await SpotifyClient.AuthUserPlaybackTransferAsync(
                            Helpers.GetDevicesRequest(deviceId));
                        break;
                    case PlaybackType.Next:
                        // Skip User’s Playback To Next Track
                        status = await SpotifyClient.AuthUserPlaybackNextTrackAsync(deviceId);
                        break;
                    case PlaybackType.Previous:
                        // Skip User’s Playback To Previous Track
                        status = await SpotifyClient.AuthUserPlaybackPreviousTrackAsync(deviceId);
                        break;
                    case PlaybackType.Seek:
                        // Seek To Position In Currently Playing Track
                        if (option == null)
                            throw new ArgumentNullException(nameof(option));
                        status = await SpotifyClient.AuthUserPlaybackSeekTrackAsync(option.Value, deviceId);
                        break;
                    case PlaybackType.Volume:
                        // Set Volume For User's Playback
                        if (option == null)
                            throw new ArgumentNullException(nameof(option));
                        status = await SpotifyClient.AuthUserPlaybackSetVolumeAsync(option.Value, deviceId);
                        break;
                    case PlaybackType.Pause:
                        // Pause a User's Playback
                        status = await SpotifyClient.AuthUserPlaybackPauseAsync(deviceId);
                        break;
                    case PlaybackType.Resume:
                        // Start/Resume a User's Playback
                        status = await SpotifyClient.AuthUserPlaybackStartResumeAsync(null, deviceId);
                        break;
                    case PlaybackType.RepeatTrack:
                        // Set Repeat Mode On User’s Playback (Track)
                        status = await SpotifyClient.AuthUserPlaybackSetRepeatModeAsync(RepeatState.Track, deviceId);
                        break;
                    case PlaybackType.RepeatContext:
                        // Set Repeat Mode On User’s Playback (Context)
                        status = await SpotifyClient.AuthUserPlaybackSetRepeatModeAsync(RepeatState.Context, deviceId);
                        break;
                    case PlaybackType.RepeatOff:
                        // Set Repeat Mode On User’s Playback (Off)
                        status = await SpotifyClient.AuthUserPlaybackSetRepeatModeAsync(RepeatState.Off, deviceId);
                        break;
                    case PlaybackType.ShuffleOn:
                        // Toggle Shuffle For User’s Playback (On)
                        status = await SpotifyClient.AuthUserPlaybackToggleShuffleAsync(true, deviceId);
                        break;
                    case PlaybackType.ShuffleOff:
                        // Toggle Shuffle For User’s Playback (Off)
                        status = await SpotifyClient.AuthUserPlaybackToggleShuffleAsync(false, deviceId);
                        break;
                }
                result = _mapper.Map(status);
                OnStatusFailed(result);
                OnSetUserPlaybackSuccess(result, playbackType, deviceId);
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Set Saved
        /// <para>Scopes: LibraryModify</para>
        /// </summary>
        /// <param name="savedType">(Required) Saved Type</param>
        /// <param name="setType">(Required) Set Type</param>
        /// <param name="multipleIds">(Required) SavedType.Album - Multiple Spotify Album Ids, SavedType.Track - Multiple Spotify Track Ids, SavedType.Show - Multiple Spotify Show Ids</param>
        /// <returns>Status Response</returns>
        public async Task<StatusResponse> SetSavedAsync(
            SavedType savedType,
            SetType setType,
            List<string> multipleIds)
        {
            StatusResponse result = null;
            try
            {
                Status status = null;
                switch (savedType)
                {
                    case SavedType.Album:
                        if(setType == SetType.Add)
                            // Save Albums for Current User
                            status = await SpotifyClient.AuthSaveUserAlbumsAsync(multipleIds);
                        else
                            // Remove Albums for Current User
                            status = await SpotifyClient.AuthRemoveUserAlbumsAsync(multipleIds);
                        break;
                    case SavedType.Track:
                        if (setType == SetType.Add)
                            // Save Tracks for User
                            status = await SpotifyClient.AuthSaveUserTracksAsync(multipleIds);
                        else
                            // Remove User's Saved Tracks
                            status = await SpotifyClient.AuthRemoveUserTracksAsync(multipleIds);
                        break;
                    case SavedType.Show:
                        if (setType == SetType.Add)
                            // Save Shows for Current User
                            status = await SpotifyClient.AuthSaveUserShowsAsync(multipleIds);
                        else
                            // Remove User's Saved Shows
                            status = await SpotifyClient.AuthRemoveUserShowsAsync(multipleIds);
                        break;
                }
                result = _mapper.Map(status);
                OnStatusFailed(result);
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Set Saved
        /// <para>Scopes: LibraryModify</para>
        /// </summary>
        /// <param name="savedType">(Required) Saved Type</param>
        /// <param name="setType">(Required) Set Type</param>
        /// <param name="id">(Required) Spotify Item Id</param>
        /// <returns>Status Response</returns>
        public async Task<StatusResponse> SetSavedAsync(
            SavedType savedType,
            SetType setType,
            string id) =>
            await SetSavedAsync(
                savedType: savedType,
                setType: setType,
                multipleIds: new List<string> { id });

        /// <summary>
        /// Set Follow
        /// <para>Scopes: FollowModify, FollowType.Playlist and SetType.Remove - PlaylistModifyPublic or PlaylistModifyPrivate</para>
        /// </summary>
        /// <param name="followType">(Required) Follow Type</param>
        /// <param name="setType">(Required) Set Type</param>
        /// <param name="multipleIds">(Required) Only for FollowType.Artist - Multiple Spotify Artist Ids, FollowType.User - Multiple Spotify User Ids</param>
        /// <param name="playlistId">(Required) Only for FollowType.Playlist</param>
        /// <returns>Status Response</returns>
        public async Task<StatusResponse> SetFollowAsync(
            FollowType followType,
            SetType setType,
            List<string> multipleIds,
            string playlistId = null)
        {
            StatusResponse result = null;
            try
            {
                Status status = null;
                switch (followType)
                {
                    case FollowType.Artist:
                    case FollowType.User:
                        if (setType == SetType.Add)
                            // Follow Artists or Users
                            status = await SpotifyClient.AuthFollowAsync(
                                itemIds: multipleIds,
                                followType: Helpers.GetApiFollowType(followType));
                        else
                            // Unfollow Artists or Users
                            status = await SpotifyClient.AuthUnfollowAsync(
                                itemIds: multipleIds,
                                followType: Helpers.GetApiFollowType(followType));
                        break;
                    case FollowType.Playlist:
                        if (playlistId == null)
                            throw new ArgumentNullException(nameof(playlistId));
                        if (setType == SetType.Add)
                            // Follow a Playlist
                            status = await SpotifyClient.AuthFollowPlaylistAsync(playlistId: playlistId);
                        else
                            // Unfollow Playlist
                            status = await SpotifyClient.AuthUnfollowPlaylistAsync(playlistId: playlistId);
                        break;
                }
                result = _mapper.Map(status);
                OnStatusFailed(result);
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Set Follow
        /// <para>Scopes: FollowModify, FollowType.Playlist and SetType.Remove - PlaylistModifyPublic or PlaylistModifyPrivate</para>
        /// </summary>
        /// <param name="followType">(Required) Follow Type</param>
        /// <param name="setType">(Required) Set Type</param>
        /// <param name="id">(Required) FollowType.Artist - Spotify Artist Id, FollowType.User - Spotify User Id, FollowType.Playlist - Spotify Playlist Id</param>
        /// <returns>Status Response</returns>
        public async Task<StatusResponse> SetFollowAsync(
            FollowType followType,
            SetType setType,
            string id) =>
            await SetFollowAsync(
                followType: followType,
                setType: setType,
                multipleIds: new List<string> { id },
                playlistId: id);

        /// <summary>
        /// Set Playlist
        /// <para>Scopes: PlaylistModifyPublic, PlaylistModifyPrivate</para>
        /// </summary>
        /// <param name="request">(Required) Set Playlist Request</param>
        /// <returns>Playlist Response</returns>
        public async Task<StatusResponse> SetPlaylistAsync(
            SetPlaylistRequest request)
        {
            StatusResponse result = null;
            try
            {
                // Change a Playlist's Details
                var change = _mapper.Map(request);
                var status = await SpotifyClient.AuthChangePlaylistDetailsAsync(
                    request.PlaylistId,
                    change);
                result = _mapper.Map(status);
                OnStatusFailed(result);
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Set Playlist Items
        /// <para>Scopes: PlaylistModifyPublic, PlaylistModifyPrivate</para>
        /// </summary>
        /// <param name="playlistId">(Required) Spotify Playlist Id</param>
        /// <param name="addPlaylistItemRequests">(Required) The items to add in the Playlist</param>
        /// <returns>Status Response</returns>
        public async Task<StatusResponse> SetPlaylistItemsAsync(
            string playlistId,
            List<AddPlaylistItemRequest> addPlaylistItemRequests)
        {
            StatusResponse result = null;
            try
            {
                // Replace a Playlist's Items
                var status = await SpotifyClient.AuthReplacePlaylistTracksAsync(
                    playlistId: playlistId,
                    uris: Helpers.GetUriListRequest(addPlaylistItemRequests));
                result = _mapper.Map(status);
                OnStatusFailed(result);
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Set Playlist Item
        /// <para>Scopes: PlaylistModifyPublic, PlaylistModifyPrivate</para>
        /// </summary>
        /// <param name="playlistId">(Required) Spotify Playlist Id</param>
        /// <param name="playItemType">Track or Episode</param>
        /// <param name="id">Spotify Track or Episode Id</param>
        /// <returns>Status Response</returns>
        public async Task<StatusResponse> SetPlaylistItemAsync(
            string playlistId,
            PlayItemType playItemType,
            string id) => 
                await SetPlaylistItemsAsync(
                playlistId: playlistId,
                new List<AddPlaylistItemRequest>()
                {
                    new AddPlaylistItemRequest()
                    {
                        PlayItemType = playItemType,
                        Id = id
                    }
                });

        /// <summary>
        /// Set Playlist Item Order
        /// </summary>
        /// <param name="playlistId">(Required) Spotify Playlist Id</param>
        /// <param name="rangeStart">(Required) Position of the first item to be reordered</param>
        /// <param name="insertBefore">(Required) Position where the items should be inserted. To reorder the items to the end of the playlist, simply set insertBefore to the position after the last item.</param>
        /// <param name="rangeLength">(Optional) Amount of items to be reordered. Defaults to 1 if not set. The range of items to be reordered begins from the rangeStart position, and includes the rangeLength subsequent items.</param>
        /// <param name="snapshotId">(Optional) Playlist’s snapshot ID against which you want to make the changes.</param>
        /// <returns>Status Response</returns>
        public async Task<StatusResponse> SetPlaylistItemOrderAsync(
            string playlistId,
            int rangeStart,
            int insertBefore,
            int? rangeLength = null,
            string snapshotId = null)
        {
            StatusResponse result = null;
            try
            {
                // Reorder a Playlist's Items
                var status = await SpotifyClient.AuthReorderPlaylistTracksAsync(
                    playlistId: playlistId,
                    request: Helpers.GetPlaylistReorderRequest(
                        rangeStart: rangeStart, 
                        insertBefore: insertBefore, 
                        rangeLength: rangeLength, 
                        snapshotId: snapshotId));
                result = _mapper.Map(status);
                OnStatusFailed(result);
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Set Playlist Image
        /// <para>Scopes: ImageUserGeneratedContentUpload</para>
        /// </summary>
        /// <param name="playlistId">(Required) Spotify Playlist Id</param>
        /// <param name="jpegFileBytes">(Required) JPEG Image File Bytes (256Kb Max File Size)</param>
        /// <returns>Status Response</returns>
        public async Task<StatusResponse> SetPlaylistImageAsync(
            string playlistId,
            byte[] jpegFileBytes)
        {
            StatusResponse result = null;
            try
            {
                // Upload a Custom Playlist Cover Image
                var status = await SpotifyClient.AuthUploadCustomPlaylistImageAsync(
                    playlistId: playlistId,
                    file: jpegFileBytes);
                result = _mapper.Map(status);
                OnStatusFailed(result);
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }
        #endregion Set Methods

        #region Toggle Methods
        /// <summary>
        /// Toggle Saved
        /// <para>Scopes: LibraryModify</para>
        /// </summary>
        /// <param name="savedType">(Required) Saved Type</param>
        /// <param name="id">(Required) SavedType.Album - Spotify Album Id, SavedType.Track - Spotify Track Id, SavedType.Show - Spotify Show Id</param>
        /// <returns>Status Response</returns>
        public async Task<BoolResponse> ToggleSavedAsync(
            SavedType savedType,
            string id)
        {
            var item = await GetSavedAsync(
                savedType: savedType, 
                id: id);
            if(item.IsSuccess)
            {
                var status = await SetSavedAsync(
                    savedType: savedType,
                    setType: item.Value ? SetType.Remove : SetType.Add,
                    id: id);
                return status.Success
                    ? new BoolResponse() { Value = !item.Value }
                    : new BoolResponse() { Error = status.Error };
            }
            else
                return new BoolResponse() { Error = item.Error };
        }

        /// <summary>
        /// Toggle Follow
        /// <para>Scopes: FollowType.FollowArtist FollowType.FollowUser - FollowRead and FollowModify, FollowType.FollowPlaylist - FollowModify and PlaylistModifyPublic or PlaylistModifyPrivate</para>
        /// </summary>
        /// <param name="followType">(Required) Follow Type</param>
        /// <param name="id">(Required) FollowType.Artist - Spotify Artist Id, FollowType.User - Spotify User Id, FollowType.Playlist - Spotify Playlist Id</param>
        /// <returns>Bool Response</returns>
        public async Task<BoolResponse> ToggleFollowAsync(
            FollowType followType,
            string id)
        {
            var item = await GetFollowAsync(
                followType: followType,
                id: id, 
                userId : CurrentUser?.Id);
            if (item.IsSuccess)
            {
                var status = await SetFollowAsync(
                    followType: followType,
                    setType: item.Value ? SetType.Remove : SetType.Add,
                    id: id);
                return status.Success
                    ? new BoolResponse() { Value = !item.Value }
                    : new BoolResponse() { Error = status.Error };
            }
            else
                return new BoolResponse() { Error = item.Error };
        }

        /// <summary>
        /// Set Toggle
        /// </summary>
        /// <param name="toggle">Toggle</param>
        public async void SetToggleAsync(Toggle toggle)
        {
            BoolResponse boolResponse;
            switch (toggle.ToggleType)
            {
                case ToggleType.Favourites:
                    boolResponse = await ToggleFavouriteAsync((FavouriteType)toggle.ItemType, toggle.Id);
                    toggle.Value = boolResponse.Value;
                    break;
                case ToggleType.Follow:
                    boolResponse = await ToggleFollowAsync((FollowType)toggle.ItemType, toggle.Id);
                    toggle.Value = boolResponse.Value;
                    break;
                case ToggleType.Saved:
                    boolResponse = await ToggleSavedAsync((SavedType)toggle.ItemType, toggle.Id);
                    toggle.Value = boolResponse.Value;
                    break;
            }
        }

        /// <summary>
        /// Get Toggle
        /// </summary>
        /// <param name="toggleType">Toggle Type</param>
        /// <param name="id">Toggle Id</param>
        /// <param name="itemType">Toggle Item Type</param>
        /// <returns>Toggle</returns>
        public async Task<Toggle> GetToggleAsync(
            ToggleType toggleType,
            string id,
            byte itemType)
        {
            bool value = false;
            BoolResponse boolResponse;
            switch (toggleType)
            {
                case ToggleType.Favourites:
                    boolResponse = await GetFavouriteAsync((FavouriteType)itemType, id);
                    value = boolResponse.Value;
                    break;
                case ToggleType.Follow:
                    boolResponse = await GetFollowAsync((FollowType)itemType, id, CurrentUser?.Id);
                    value = boolResponse.Value;
                    break;
                case ToggleType.Saved:
                    boolResponse = await GetSavedAsync((SavedType)itemType, id);
                    value = boolResponse.Value;
                    break;
            }
            var toggle = new Toggle()
            {
                Id = id,
                Value = value,
                ItemType = itemType,
                ToggleType = toggleType,
                Command = new GenericCommand<Toggle>(SetToggleAsync)
            };
            return toggle;
        }

        /// <summary>
        /// List Toggles
        /// </summary>
        /// <param name="toggleType">Toggle Type</param>
        /// <param name="multipleIds">Multiple Ids</param>
        /// <param name="playlistId">Playlist Id</param>
        /// <param name="itemType">Item Type</param>
        /// <returns>List of Toggle</returns>
        public async Task<List<Toggle>> ListTogglesAsync(
            ToggleType toggleType,
            List<string> multipleIds,
            string playlistId,
            byte itemType)
        {
            List<Toggle> result = null;
            NavigationResponse<bool> response = null;
            switch (toggleType)
            {
                case ToggleType.Favourites:
                    response = await ListFavouriteAsync((FavouriteType)itemType, multipleIds);
                    break;
                case ToggleType.Follow: 
                    response = await ListFollowAsync((FollowType)itemType, multipleIds, playlistId);
                    break;
                case ToggleType.Saved:
                    response = await ListSavedAsync((SavedType)itemType, multipleIds);
                    break;
            }
            if(response.IsSuccess && response.Items != null && response.Items.Count() == multipleIds.Count())
            {
                result = new List<Toggle>();
                for(var i = 0; i < multipleIds.Count(); i++)
                {
                    var toggle = new Toggle()
                    {
                        Id = multipleIds[i],
                        Value = response.Items[i],
                        ItemType = itemType,
                        ToggleType = toggleType,
                        Command = new GenericCommand<Toggle>(SetToggleAsync)
                    };
                    result.Add(toggle);
                }
            }
            return result;
        }
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
        public async Task<StatusResponse> AddUserPlaybackAsync(
            PlaybackStartType playbackStartType, 
            string id,
            string deviceId = null,
            int? position = null,
            string offsetId = null)
        {
            StatusResponse result = null;
            try
            {
                // Start/Resume a User's Playback
                var status = await SpotifyClient.AuthUserPlaybackStartResumeAsync(
                    Helpers.GetPlaybackStartRequest(
                        playbackStartType: playbackStartType,
                        id: id,
                        position: position, 
                        offsetId: offsetId),
                        deviceId: deviceId);
                result = _mapper.Map(status);
                OnStatusFailed(result);
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Add User Playback Queue
        /// <para>Scopes: ConnectModifyPlaybackState</para>
        /// </summary>
        /// <param name="playItemType">(Required) Track or Episode</param>
        /// <param name="id">(Required) PlayItemType.Track - Spotify Track Id, PlayItemType.Episode - Spotify Episode Id</param>
        /// <param name="deviceId">(Optional) Spotify Device Id</param>
        /// <returns>Status Response</returns>
        public async Task<StatusResponse> AddUserPlaybackQueueAsync(
            PlayItemType playItemType, 
            string id,
            string deviceId = null)
        {
            StatusResponse result = null;
            try
            {
                // Add an item to the end of the user's current playback queue
                var status = await SpotifyClient.AuthUserPlaybackAddToQueueAsync(
                    uri: Helpers.GetPlaybackQueueUri(playItemType, id),
                    deviceId: deviceId);
                result = _mapper.Map(status);
                OnStatusFailed(result);
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Add Playlist
        /// <para>Scopes: PlaylistModifyPublic, PlaylistModifyPrivate</para>
        /// </summary>
        /// <param name="request">Add Playlist Request (Required)</param>
        /// <returns>Playlist Response</returns>
        public async Task<PlaylistResponse> AddPlaylistAsync(
            AddPlaylistRequest request)
        {
            PlaylistResponse result = null;
            try
            {
                // Create a Playlist
                var create = _mapper.Map(request);
                var playlist = await SpotifyClient.AuthCreatePlaylistAsync(
                    request.UserId, 
                    create);
                result = _mapper.Map(playlist);
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Add Playlist Items
        /// <para>Scopes: PlaylistModifyPublic, PlaylistModifyPrivate</para>
        /// </summary>
        /// <param name="playlistId">(Required) Spotify Playlist Id</param>
        /// <param name="requests">(Required) The items to add to the playlist</param>
        /// <param name="position">(Optional) The position to insert the items, a zero-based index</param>
        /// <returns>Snapshot Response</returns>
        public async Task<SnapshotResponse> AddPlaylistItemsAsync(
            string playlistId,
            List<AddPlaylistItemRequest> requests,
            int? position = null)
        {
            SnapshotResponse result = null;
            try
            {
                // Add Items to a Playlist
                var snapshot = await SpotifyClient.AuthAddTracksToPlaylistAsync(
                    playlistId: playlistId,
                    uris: Helpers.GetUriListRequest(requests),
                    position: position);
                result = _mapper.Map(snapshot);
                OnStatusFailed(result);
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

        /// <summary>
        /// Add Playlist Item
        /// <para>Scopes: PlaylistModifyPublic, PlaylistModifyPrivate</para>
        /// </summary>
        /// <param name="playlistId">(Required) Spotify Playlist Id</param>
        /// <param name="playItemType">(Required) Track or Episode</param>
        /// <param name="id">(Required) Spotify Track Id or Episode Id</param>
        /// <param name="position">(Optional) The positions to remove items by id, a zero-based index</param>
        /// <returns>Snapshot Response</returns>
        public async Task<SnapshotResponse> AddPlaylistItemAsync(
            string playlistId,
            PlayItemType playItemType,
            string id,
            int? position = null) =>
            await AddPlaylistItemsAsync(
                playlistId: playlistId,
                requests:
                new List<AddPlaylistItemRequest>()
                {
                    new AddPlaylistItemRequest()
                    {
                        PlayItemType = playItemType,
                        Id = id
                    }
                },
                position: position);
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
        public async Task<SnapshotResponse> RemovePlaylistItemsAsync(
            string playlistId,
            List<RemovePlaylistItemRequest> removePlaylistItemRequests,
            string snapshotId = null)
        {
            SnapshotResponse result = null;
            try
            {
                // Remove Items from a Playlist
                var snapshot = await SpotifyClient.AuthRemoveTracksFromPlaylistAsync(
                    playlistId: playlistId,
                    request: Helpers.GetPlaylistTracksRequest(
                        requests: removePlaylistItemRequests,
                        snapshotId: snapshotId));
                result = _mapper.Map(snapshot);
                OnStatusFailed(result);
            }
            catch (AuthUserTokenRequiredException)
            {
                OnAuthenticationTokenRequired(AuthenticationTokenType.User);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return result;
        }

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
        public async Task<SnapshotResponse> RemovePlaylistItemAsync(
            string playlistId,
            PlayItemType playItemType,
            string id,
            List<int> positions = null,
            string snapshotId = null) =>
            await RemovePlaylistItemsAsync(
                playlistId: playlistId,
                removePlaylistItemRequests: 
                new List<RemovePlaylistItemRequest>()
                {
                    new RemovePlaylistItemRequest()
                    {
                        PlayItemType = playItemType,
                        Positions = positions,
                        Id = id
                    }
                },
                snapshotId: snapshotId);
        #endregion Remove Methods

        #region Favourite Methods
        /// <summary>
        /// Get Favourite
        /// </summary>
        /// <param name="favouriteType">(Required) Favourite Type</param>
        /// <param name="id">(Required) FavouriteType.Album - Spotify Album Id, FavouriteType.Artist - Spotify Artist Id, FavouriteType.Track - Spotify Track Id, FavouriteType.Show - Spotify Show Id, FavouriteType.Episode - Spotify Episode Id</param>
        /// <returns>Bool Response</returns>
        public Task<BoolResponse> GetFavouriteAsync(
            FavouriteType favouriteType,
            string id)
        {
            BoolResponse result = null;
            try
            {
                var value = _favourites.Contains(
                    favouriteType: favouriteType,
                    id: id);
                result = Helpers.GetBoolResponse(value);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return Task.FromResult(result);
        }

        /// <summary>
        /// List Favourite
        /// </summary>
        /// <param name="favouriteType">(Required) Favourite Type</param>
        /// <param name="multipleIds">(Required) FavouriteType.Album - Multiple Spotify Album Ids, FavouriteType.Artist - Multiple Spotify Artist Ids, FavouriteType.Track - Multiple Spotify Track Ids, FavouriteType.Show - Multiple Spotify Show Ids, FavouriteType.Episode - Multiple Spotify Episode Ids</param>
        /// <returns>Navigation Response of Bool</returns>
        public Task<NavigationResponse<bool>> ListFavouriteAsync(
            FavouriteType favouriteType,
            List<string> multipleIds)
        {
            NavigationResponse<bool> result = null;
            try
            {
                var values = _favourites.Contains(
                    favouriteType: favouriteType, 
                    multipleIds: multipleIds);
                var bools = Helpers.GetBools(values);
                result = _mapper.MapToNavigationResponse(bools);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return Task.FromResult(result);
        }

        /// <summary>
        /// Set Favourite
        /// </summary>
        /// <param name="favouriteType">(Required) Favourite Type</param>
        /// <param name="setType">(Required) Set Type</param>
        /// <param name="id">(Required) FavouriteType.Album - Spotify Album Id, FavouriteType.Artist - Spotify Artist Id, FavouriteType.Track - Spotify Track Id, FavouriteType.Show - Spotify Show Id, FavouriteType.Episode - Spotify Episode Id</param>
        /// <returns>Status Response</returns>
        public Task<StatusResponse> SetFavouriteAsync(
            FavouriteType favouriteType, 
            SetType setType,
            string id)
        {
            StatusResponse result = null;
            try
            {
                bool success = false;
                switch (setType)
                {
                    case SetType.Add:
                        success = _favourites.Add(
                            favouriteType: favouriteType, 
                            id: id);
                        break;
                    case SetType.Remove:
                        success = _favourites.Remove(
                            favouriteType: favouriteType,
                            id: id);
                        break;
                }
                result = Helpers.GetStatusResponse(success);
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return Task.FromResult(result);
        }

        /// <summary>
        /// Set Favourite
        /// </summary>
        /// <param name="favouriteType">(Required) Favourite Type</param>
        /// <param name="setType">(Required) Set Type</param>
        /// <param name="multipleIds">(Required) FavouriteType.Album - Multiple Spotify Album Ids, FavouriteType.Artist - Multiple Spotify Artist Ids, FavouriteType.Track - Multiple Spotify Track Ids, FavouriteType.Show - Multiple Spotify Show Ids, FavouriteType.Episode - Multiple Spotify Episode Ids</param>
        /// <returns>Status Response</returns>
        public Task<StatusResponse> SetFavouriteAsync(
            FavouriteType favouriteType,
            SetType setType,
            List<string> multipleIds)
        {
            StatusResponse result = null;
            try
            {
                List<bool> response = null;
                switch (setType)
                {
                    case SetType.Add:
                        response = _favourites.Add(
                            favouriteType: favouriteType,
                            multipleIds: multipleIds);
                        break;
                    case SetType.Remove:
                        response = _favourites.Remove(
                            favouriteType: favouriteType,
                            multipleIds: multipleIds);
                        break;
                }
                result = Helpers.GetStatusResponse(response.TrueForAll(t => t));
            }
            catch (Exception ex)
            {
                OnClientException(ex);
            }
            return Task.FromResult(result);
        }

        /// <summary>
        /// Toggle Favourite
        /// </summary>
        /// <param name="favouriteType">(Required) Favourite Type</param>
        /// <param name="id">(Required) FavouriteType.Album - Spotify Album Id, FavouriteType.Artist - Spotify Artist Id, FavouriteType.Track - Spotify Track Id, FavouriteType.Show - Spotify Show Id, FavouriteType.Episode - Spotify Episode Id</param>
        /// <returns>Bool Response</returns>
        public async Task<BoolResponse> ToggleFavouriteAsync(
            FavouriteType favouriteType,
            string id)
        {
            var item = await GetFavouriteAsync(
                favouriteType: favouriteType,
                id: id);
            if (item.IsSuccess)
            {
                var status = await SetFavouriteAsync(
                    favouriteType: favouriteType,
                    setType: item.Value ? SetType.Remove : SetType.Add,
                    id: id);
                return status.Success
                    ? new BoolResponse() { Value = !item.Value }
                    : new BoolResponse() { Error = status.Error };
            }
            else
            {
                return new BoolResponse() { Error = item.Error };
            }
        }
        #endregion Favourite Methods
    }
}