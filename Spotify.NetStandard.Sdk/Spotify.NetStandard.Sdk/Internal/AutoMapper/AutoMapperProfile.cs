using AutoMapper;
using Spotify.NetStandard.Client.Authentication;
using Spotify.NetStandard.Responses;
using System.Collections.Generic;

namespace Spotify.NetStandard.Sdk.AutoMapper
{
    /// <summary>
    /// Auto Mapper Profile
    /// </summary>
    internal class AutoMapperProfile : Profile
    {
        #region Private Methods
        /// <summary>
        /// Map Authentication
        /// </summary>
        private void MapAuthentication()
        { 
            // Access Token
            CreateMap<AccessToken, AuthenticationTokenResponse>().ForMember(
                dest => dest.AuthenticationTokenType, 
                opt => opt.MapFrom(source => source.TokenType))
                .ReverseMap();
            // Scopes
            CreateMap<Requests.Scope, AuthenticationScopeRequest>().ForMember(
                dest => dest.ImageUserGeneratedContentUpload, 
                opt => opt.MapFrom(source => source.UserGeneratedContentImageUpload))
                .ReverseMap();
        }

        /// <summary>
        /// Map Navigation
        /// </summary>
        private void MapNavigation()
        {
            // List
            CreateMap(typeof(List<>), typeof(NavigationResponse<>))
                .ConvertUsing(typeof(ListToNavigationResponseConverter<,>));
            CreateMap(typeof(NavigationResponse<>), typeof(List<>))
                .ConvertUsing(typeof(NavigationResponseToListConverter<,>));
            // Paging
            CreateMap(typeof(Paging<>), typeof(NavigationResponse<>))
                .ConvertUsing(typeof(PagingToNavigationResponseConverter<,>));
            CreateMap(typeof(NavigationResponse<>), typeof(Paging<>))
                .ConvertUsing(typeof(NavigationResponseToPagingConverter<,>));
            // Cursor
            CreateMap(typeof(CursorPaging<>), typeof(NavigationResponse<>))
                .ConvertUsing(typeof(CursorPagingToNavigationResponseConverter<,>));
            CreateMap(typeof(NavigationResponse<>), typeof(CursorPaging<>))
                .ConvertUsing(typeof(NavigationResponseToCursorPagingConverter<,>));
            // Genres
            CreateMap<AvailableGenreSeeds, NavigationResponse<RecommendationGenreResponse>>()
                .ConvertUsing(typeof(AvailableGenreSeedsToNavigationResponseConverter));
            // Recommendations            
            CreateMap<RecommendationsResponse, NavigationResponse<TrackResponse>>()
                .ConvertUsing(typeof(RecommendationsResponseToNavigationResponseConverter));
            // Playlist Image
            CreateMap<List<Image>, PlaylistImageResponse>()
                .ConvertUsing(typeof(ImageListToPlaylistImageResponseConverter));
            // Devices
            CreateMap<Devices, NavigationResponse<DeviceResponse>>()
                .ConvertUsing(typeof(DevicesToNavigationDeviceResponseConverter));
            // Devices
            CreateMap<Bools, NavigationResponse<bool>>()
                .ConvertUsing(typeof(BoolsToNavigationBoolResponseConverter));
        }

        /// <summary>
        /// Map Requests
        /// </summary>
        private void MapRequests()
        {
            CreateMap<Requests.TuneableTrack, TuneableTrackRequest>().ReverseMap();
            CreateMap<Requests.SearchType, SearchTypeRequest>().ReverseMap();
            CreateMap<Requests.IncludeGroup, IncludeGroupRequest>().ReverseMap();
            CreateMap<Requests.PlaylistRequest, BasePlaylistRequest>().ReverseMap();
        }

        /// <summary>
        /// Map Responses
        /// </summary>
        private void MapResponses()
        {
            CreateMap<AllowsResponse, Disallows>().ReverseMap()
                .ConvertUsing(typeof(DisallowsToAllowsResponseConverter));
            CreateMap<Actions, ActionsResponse>()
                .ForMember(dest => dest.Allows, 
                opt => opt.MapFrom(source => source.Disallows)); 
            
            CreateMap<Album, AlbumResponse>().ReverseMap();
            CreateMap<Artist, ArtistResponse>().ReverseMap();
            CreateMap<AudioAnalysis, AudioAnalysisResponse>().ReverseMap();
            CreateMap<AudioFeatures, AudioFeaturesResponse>().ReverseMap();
            CreateMap<string, RecommendationGenreResponse>()
                .ConvertUsing(str => new RecommendationGenreResponse() { Id = str });
            CreateMap<Category, CategoryResponse>().ReverseMap();
            CreateMap<Context, ContextResponse>().ReverseMap();
            CreateMap<Copyright, CopyrightResponse>().ReverseMap();
            CreateMap<CurrentlyPlaying, CurrentlyPlayingResponse>().ReverseMap();
            CreateMap<Device, DeviceResponse>().ReverseMap();
            CreateMap<Disallows, DisallowsResponse>().ReverseMap();
            CreateMap<Episode, EpisodeResponse>().ReverseMap();
            CreateMap<Responses.ErrorResponse, ErrorResponse>().ReverseMap();
            CreateMap<ExternalId, ExternalIdResponse>().ReverseMap();
            CreateMap<ExternalUrl, ExternalUrlResponse>().ReverseMap();
            CreateMap<Followers, FollowersResponse>().ReverseMap();
            CreateMap<Image, ImageResponse>().ReverseMap();
            CreateMap<LinkedTrack, LinkedTrackResponse>().ReverseMap();

            CreateMap<PlayHistory, TrackResponse>()
                .ConvertUsing(typeof(PlayHistoryToTrackResponseConverter));
            CreateMap<TrackResponse, PlayHistory>()
                .ConvertUsing(typeof(TrackResponseToPlayHistoryConverter));

            CreateMap<Playlist, PlaylistResponse>().ReverseMap();

            CreateMap<PrivateUser, CurrentUserResponse>().ReverseMap();
            CreateMap<PublicUser, UserResponse>().ReverseMap();
            CreateMap<RecommendationSeed, RecommendationSeedResponse>().ReverseMap();

            CreateMap<ResumePoint, ResumePointResponse>().ReverseMap();

            CreateMap<SavedAlbum, AlbumResponse>()
                .ConvertUsing(typeof(SavedAlbumToAlbumResponseConverter));
            CreateMap<AlbumResponse, SavedAlbum>()
                .ConvertUsing(typeof(AlbumResponseToSavedAlbumConverter));

            CreateMap<SavedShow, ShowResponse>()
                .ConvertUsing(typeof(SavedShowToShowResponseConverter));
            CreateMap<ShowResponse, SavedShow>()
                .ConvertUsing(typeof(ShowResponseToSavedShowConverter));

            CreateMap<SavedTrack, TrackResponse>()
                .ConvertUsing(typeof(SavedTrackToTrackResponseConverter));
            CreateMap<TrackResponse, SavedTrack>()
                .ConvertUsing(typeof(TrackResponseToSavedTrackConverter));

            CreateMap<Section, SectionResponse>().ReverseMap();
            CreateMap<Segment, SegmentResponse>().ReverseMap();
            CreateMap<Show, ShowResponse>().ReverseMap();

            CreateMap<SimplifiedAlbum, AlbumResponse>().ReverseMap();
            CreateMap<SimplifiedArtist, ArtistResponse>().ReverseMap();
            CreateMap<SimplifiedCurrentlyPlaying, CurrentlyPlayingItemResponse>().ReverseMap();
            CreateMap<SimplifiedEpisode, EpisodeResponse>().ReverseMap();
            CreateMap<SimplifiedPlaylist, PlaylistResponse>().ReverseMap();
            CreateMap<SimplifiedShow, ShowResponse>().ReverseMap();
            CreateMap<SimplifiedTrack, TrackResponse>().ReverseMap();

            CreateMap<Snapshot, SnapshotResponse>().ReverseMap();
            CreateMap<Status, StatusResponse>().ReverseMap();
            CreateMap<TimeInterval, TimeIntervalResponse>().ReverseMap();
            CreateMap<Track, TrackResponse>().ReverseMap();
            CreateMap<TrackRestriction, TrackRestrictionResponse>().ReverseMap();

            CreateMap<ContentResponse, SearchResponse>().ReverseMap();

            CreateMap<PlaylistTrack, PlaylistItemResponse>().ReverseMap();
        }
        #endregion Private Methods

        #region Public Methods
        /// <summary>
        /// Constructor
        /// </summary>
        public AutoMapperProfile()
        {
            MapAuthentication();
            MapNavigation();
            MapRequests();
            MapResponses();
        }
        #endregion Public Methods
    }
}
