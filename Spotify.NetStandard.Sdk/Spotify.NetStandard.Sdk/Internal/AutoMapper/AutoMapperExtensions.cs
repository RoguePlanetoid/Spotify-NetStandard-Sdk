using AutoMapper;
using Spotify.NetStandard.Client.Authentication;
using Spotify.NetStandard.Requests;
using Spotify.NetStandard.Responses;
using System.Collections.Generic;

namespace Spotify.NetStandard.Sdk.AutoMapper
{
    /// <summary>
    /// Mapping Extensions
    /// </summary>
    internal static class AutoMapperExtensions
    {
        #region Setup
        /// <summary>
        /// Setup
        /// </summary>
        /// <returns></returns>
        public static IMapper Setup(this IMapper mapper)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            //config.AssertConfigurationIsValid();
            return mapper = config.CreateMapper();
        }
        #endregion Setup

        #region Authentication Mapping
        public static Scope Map(this IMapper mapper, AuthenticationScopeRequest authenticationScope) =>
            mapper.Map<Scope>(authenticationScope);

        public static AuthenticationTokenResponse Map(this IMapper mapper, AccessToken accessToken) =>
            mapper.Map<AuthenticationTokenResponse>(accessToken);

        public static AccessToken Map(this IMapper mapper, AuthenticationTokenResponse accessToken) =>
            mapper.Map<AccessToken>(accessToken);
        #endregion Authentication Mapping

        #region Request Mapping
        public static TuneableTrack Map(this IMapper mapper, TuneableTrackRequest tunableTrack) =>
            mapper.Map<TuneableTrack>(tunableTrack);

        public static SearchType Map(this IMapper mapper, SearchTypeRequest searchTypeRequest) =>
            mapper.Map<SearchType>(searchTypeRequest);

        public static IncludeGroup Map(this IMapper mapper, IncludeGroupRequest includeGroupRequest) =>
            mapper.Map<IncludeGroup>(includeGroupRequest);

        public static PlaylistRequest Map(this IMapper mapper, BasePlaylistRequest basePlaylistRequest) =>
            mapper.Map<PlaylistRequest>(basePlaylistRequest);
        #endregion Request Mapping

        #region Object Mapping
        public static NavigationResponse<RecommendationGenreResponse> Map(this IMapper mapper, AvailableGenreSeeds availableGenreSeeds) =>
            mapper.Map<NavigationResponse<RecommendationGenreResponse>>(availableGenreSeeds);

        public static AudioFeaturesResponse Map(this IMapper mapper, AudioFeatures audioFeatures) =>
            mapper.Map<AudioFeaturesResponse>(audioFeatures);

        public static AudioAnalysisResponse Map(this IMapper mapper, AudioAnalysis audioAnalysis) =>
            mapper.Map<AudioAnalysisResponse>(audioAnalysis);

        public static CurrentUserResponse Map(this IMapper mapper, PrivateUser privateUser) =>
            mapper.Map<CurrentUserResponse>(privateUser);

        public static UserResponse Map(this IMapper mapper, PublicUser publicUser) =>
            mapper.Map<UserResponse>(publicUser);

        public static CurrentlyPlayingItemResponse Map(this IMapper mapper, SimplifiedCurrentlyPlaying simplifiedCurrentlyPlaying) =>
            mapper.Map<CurrentlyPlayingItemResponse>(simplifiedCurrentlyPlaying);

        public static CurrentlyPlayingResponse Map(this IMapper mapper, CurrentlyPlaying currentlyPlaying) =>
            mapper.Map<CurrentlyPlayingResponse>(currentlyPlaying);

        public static StatusResponse Map(this IMapper mapper, Status status) =>
            mapper.Map<StatusResponse>(status);

        public static NavigationResponse<bool> MapToNavigationResponse(this IMapper mapper, Bools bools) =>
            mapper.Map<NavigationResponse<bool>>(bools);

        public static SnapshotResponse Map(this IMapper mapper, Snapshot snapshot) =>
            mapper.Map<SnapshotResponse>(snapshot);
        #endregion Object Mapping

        #region Images
        public static PlaylistImageResponse Map(this IMapper mapper, List<Image> images) =>
            mapper.Map<PlaylistImageResponse>(images);
        #endregion Images

        #region Categories
        public static CategoryResponse Map(this IMapper mapper, Category category) =>
            mapper.Map<CategoryResponse>(category);

        public static NavigationResponse<CategoryResponse> MapFromPaging(this IMapper mapper, Paging<Category> paging) =>
            mapper.Map<NavigationResponse<CategoryResponse>>(paging);

        public static Paging<Category> MapToPaging(this IMapper mapper, NavigationResponse<CategoryResponse> navigationResponse) =>
            mapper.Map<Paging<Category>>(navigationResponse);
        #endregion Categories

        #region Artists
        public static ArtistResponse Map(this IMapper mapper, Artist artist) =>
            mapper.Map<ArtistResponse>(artist);

        public static NavigationResponse<ArtistResponse> MapFromPaging(this IMapper mapper, Paging<Artist> artists) =>
            mapper.Map<NavigationResponse<ArtistResponse>>(artists);

        public static NavigationResponse<ArtistResponse> MapFromCursorPaging(this IMapper mapper, CursorPaging<Artist> artists) =>
            mapper.Map<NavigationResponse<ArtistResponse>>(artists);

        public static Paging<Artist> MapToPaging(this IMapper mapper, NavigationResponse<ArtistResponse> artists) =>
            mapper.Map<Paging<Artist>>(artists);

        public static CursorPaging<Artist> MapToCursorPaging(this IMapper mapper, NavigationResponse<ArtistResponse> artists) =>
            mapper.Map<CursorPaging<Artist>>(artists);

        public static NavigationResponse<ArtistResponse> MapFromArtistList(this IMapper mapper, List<Artist> artists) =>
            mapper.Map<NavigationResponse<ArtistResponse>>(artists);
        #endregion Artists

        #region Albums
        public static AlbumResponse Map(this IMapper mapper, Album album) =>
            mapper.Map<AlbumResponse>(album);

        public static NavigationResponse<AlbumResponse> MapFromPaging(this IMapper mapper, Paging<Album> albums) =>
            mapper.Map<NavigationResponse<AlbumResponse>>(albums);

        public static NavigationResponse<AlbumResponse> MapFromCursorPaging(this IMapper mapper, CursorPaging<Album> albums) =>
            mapper.Map<NavigationResponse<AlbumResponse>>(albums);

        public static NavigationResponse<AlbumResponse> MapFromCursorPaging(this IMapper mapper, CursorPaging<SavedAlbum> albums) =>
            mapper.Map<NavigationResponse<AlbumResponse>>(albums);

        public static Paging<Album> MapToPaging(this IMapper mapper, NavigationResponse<AlbumResponse> albums) =>
            mapper.Map<Paging<Album>>(albums);

        public static CursorPaging<Album> MapToCursorPagingAlbum(this IMapper mapper, NavigationResponse<AlbumResponse> albums) =>
            mapper.Map<CursorPaging<Album>>(albums);

        public static CursorPaging<SavedAlbum> MapToCursorPagingSavedAlbum(this IMapper mapper, NavigationResponse<AlbumResponse> albums) =>
            mapper.Map<CursorPaging<SavedAlbum>>(albums);

        public static NavigationResponse<AlbumResponse> MapFromAlbumList(this IMapper mapper, List<Album> albums) =>
            mapper.Map<NavigationResponse<AlbumResponse>>(albums);
        #endregion Albums

        #region Tracks
        public static TrackResponse Map(this IMapper mapper, Track track) =>
            mapper.Map<TrackResponse>(track);

        public static NavigationResponse<TrackResponse> MapFromPaging(this IMapper mapper, Paging<Track> tracks) =>
            mapper.Map<NavigationResponse<TrackResponse>>(tracks);

        public static NavigationResponse<TrackResponse> MapFromCursorPaging(this IMapper mapper, CursorPaging<Track> tracks) =>
            mapper.Map<NavigationResponse<TrackResponse>>(tracks);

        public static NavigationResponse<TrackResponse> MapFromCursorPaging(this IMapper mapper, CursorPaging<SavedTrack> tracks) =>
            mapper.Map<NavigationResponse<TrackResponse>>(tracks);

        public static NavigationResponse<TrackResponse> MapFromCursorPaging(this IMapper mapper, CursorPaging<PlayHistory> tracks) =>
            mapper.Map<NavigationResponse<TrackResponse>>(tracks);

        public static Paging<Track> MapToPagingTrack(this IMapper mapper, NavigationResponse<TrackResponse> tracks) =>
            mapper.Map<Paging<Track>>(tracks);

        public static CursorPaging<Track> MapToCursorPagingTrack(this IMapper mapper, NavigationResponse<TrackResponse> tracks) =>
            mapper.Map<CursorPaging<Track>>(tracks);

        public static CursorPaging<PlayHistory> MapToCursorPagingPlayHistory(this IMapper mapper, NavigationResponse<TrackResponse> tracks) =>
            mapper.Map<CursorPaging<PlayHistory>>(tracks);

        public static CursorPaging<SavedTrack> MapToCursorPagingSavedTrack(this IMapper mapper, NavigationResponse<TrackResponse> tracks) =>
            mapper.Map<CursorPaging<SavedTrack>>(tracks);

        public static NavigationResponse<TrackResponse> MapFromTrackList(this IMapper mapper, List<Track> tracks) =>
            mapper.Map<NavigationResponse<TrackResponse>>(tracks);

        public static NavigationResponse<TrackResponse> MapFromSimplifiedTrackList(this IMapper mapper, List<SimplifiedTrack> tracks) =>
            mapper.Map<NavigationResponse<TrackResponse>>(tracks);

        public static NavigationResponse<TrackResponse> MapFromRecommendationResponse(this IMapper mapper, RecommendationsResponse recommendationsResponse) =>
            mapper.Map<NavigationResponse<TrackResponse>>(recommendationsResponse);
        #endregion Tracks

        #region Playlists
        public static PlaylistResponse Map(this IMapper mapper, Responses.Playlist playlist) =>
            mapper.Map<PlaylistResponse>(playlist);

        public static Paging<SimplifiedPlaylist> MapToPaging(this IMapper mapper, NavigationResponse<PlaylistResponse> playlists) =>
            mapper.Map<Paging<SimplifiedPlaylist>>(playlists);

        public static CursorPaging<SimplifiedPlaylist> MapToCursorPaging(this IMapper mapper, NavigationResponse<PlaylistResponse> playlists) =>
            mapper.Map<CursorPaging<SimplifiedPlaylist>>(playlists);

        public static NavigationResponse<PlaylistResponse> MapFromPaging(this IMapper mapper, Paging<SimplifiedPlaylist> playlists) =>
            mapper.Map<NavigationResponse<PlaylistResponse>>(playlists);

        public static NavigationResponse<PlaylistResponse> MapFromCursorPaging(this IMapper mapper, CursorPaging<SimplifiedPlaylist> playlists) =>
            mapper.Map<NavigationResponse<PlaylistResponse>>(playlists);

        public static NavigationResponse<PlaylistResponse> MapFromList(this IMapper mapper, List<SimplifiedPlaylist> playlists) =>
            mapper.Map<NavigationResponse<PlaylistResponse>>(playlists);

        public static NavigationResponse<PlaylistItemResponse> MapFromPaging(this IMapper mapper, Paging<PlaylistTrack> playlistItems) =>
            mapper.Map<NavigationResponse<PlaylistItemResponse>>(playlistItems);

        public static Paging<PlaylistTrack> MapToPagingPlaylistTrack(this IMapper mapper, NavigationResponse<PlaylistItemResponse> tracks) =>
            mapper.Map<Paging<PlaylistTrack>>(tracks);
        #endregion Playlists

        #region Episodes
        public static EpisodeResponse Map(this IMapper mapper, Episode episode) =>
            mapper.Map<EpisodeResponse>(episode);

        public static NavigationResponse<EpisodeResponse> MapFromPaging(this IMapper mapper, Paging<SimplifiedEpisode> paging) =>
            mapper.Map<NavigationResponse<EpisodeResponse>>(paging);

        public static Paging<SimplifiedEpisode> MapToPaging(this IMapper mapper, NavigationResponse<EpisodeResponse> navigationResponse) =>
            mapper.Map<Paging<SimplifiedEpisode>>(navigationResponse);

        public static NavigationResponse<EpisodeResponse> MapFromEpisodeList(this IMapper mapper, List<Episode> episodes) =>
            mapper.Map<NavigationResponse<EpisodeResponse>>(episodes);
        #endregion Episodes

        #region Shows
        public static ShowResponse Map(this IMapper mapper, Show show) =>
            mapper.Map<ShowResponse>(show);

        public static NavigationResponse<ShowResponse> MapFromPaging(this IMapper mapper, Paging<SimplifiedShow> shows) =>
            mapper.Map<NavigationResponse<ShowResponse>>(shows);

        public static NavigationResponse<ShowResponse> MapFromShowList(this IMapper mapper, List<Show> shows) =>
            mapper.Map<NavigationResponse<ShowResponse>>(shows);

        public static NavigationResponse<ShowResponse> MapFromCursorPaging(this IMapper mapper, CursorPaging<SavedShow> shows) =>
            mapper.Map<NavigationResponse<ShowResponse>>(shows);

        public static Paging<SimplifiedShow> MapToPaging(this IMapper mapper, NavigationResponse<ShowResponse> navigationResponse) =>
            mapper.Map<Paging<SimplifiedShow>>(navigationResponse);

        public static CursorPaging<SavedShow> MapToCursorPaging(this IMapper mapper, NavigationResponse<ShowResponse> shows) =>
            mapper.Map<CursorPaging<SavedShow>>(shows);
        #endregion Shows

        #region Lists
        public static NavigationResponse<AudioFeaturesResponse> MapFromAudioFeaturesList(this IMapper mapper, List<AudioFeatures> audioFeatures) =>
            mapper.Map<NavigationResponse<AudioFeaturesResponse>>(audioFeatures);

        public static NavigationResponse<DeviceResponse> MapFromDeviceList(this IMapper mapper, Devices devices) =>
            mapper.Map<NavigationResponse<DeviceResponse>>(devices);
        #endregion Lists

        #region Search
        public static SearchResponse MapSearch(this IMapper mapper, ContentResponse search) =>
            mapper.Map<SearchResponse>(search);
        #endregion Search
    }
}
