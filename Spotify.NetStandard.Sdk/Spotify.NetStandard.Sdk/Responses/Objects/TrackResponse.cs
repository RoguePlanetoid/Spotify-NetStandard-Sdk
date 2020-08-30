using Spotify.NetStandard.Sdk.Internal;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Track Response
    /// </summary>
    public class TrackResponse : BaseContentResponse, IPlayItemResponse
    {
        #region Response Properties
        /// <summary>
        /// The artists who performed the track. Each artist object includes a link in href to more detailed information about the artist.
        /// </summary>
        public List<ArtistResponse> Artists { get; set; }

        /// <summary>
        /// A list of the countries in which the track can be played, identified by their ISO 3166-1 alpha-2 code.
        /// </summary>
        public List<string> AvailableMarkets { get; set; }

        /// <summary>
        /// The disc number (usually 1 unless the album consists of more than one disc).
        /// </summary>
        public int DiscNumber { get; set; }

        /// <summary>
        /// The track length in milliseconds.
        /// </summary>
        public long Duration { get; set; }

        /// <summary>
        /// Whether or not the track has explicit lyrics ( true = yes it does; false = no it does not OR unknown).
        /// </summary>
        public bool IsExplicit { get; set; }

        /// <summary>
        /// Part of the response when Track Relinking is applied. If true , the track is playable in the given market. Otherwise false.
        /// </summary>
        public bool IsPlayable { get; set; }

        /// <summary>
        /// Part of the response when Track Relinking is applied and is only part of the response if the track linking, in fact, exists
        /// </summary>
        public LinkedTrackResponse LinkedFrom { get; set; }

        /// <summary>
        /// Part of the response when Track Relinking is applied, the original track is not available in the given market
        /// </summary>
        public TrackRestrictionResponse Restrictions { get; set; }

        /// <summary>
        /// A link to a 30 second preview (MP3 format) of the track
        /// </summary>
        public string Preview { get; set; }

        /// <summary>
        /// The number of the track. If an album has several discs, the track number is the number on the specified disc
        /// </summary>
        public int TrackNumber { get; set; }

        /// <summary>
        /// Whether or not the track is from a local file
        /// </summary>
        public bool IsLocal { get; set; }

        /// <summary>
        /// The album on which the track appears. The album object includes a link in href to full information about the album
        /// </summary>
        public AlbumResponse Album { get; set; }

        /// <summary>
        /// Known external IDs for the track.
        /// </summary>
        public ExternalIdResponse ExternalId { get; set; }

        /// <summary>
        /// The popularity of the track. The value will be between 0 and 100, with 100 being the most popular
        /// </summary>
        public int Popularity { get; set; }

        /// <summary>
        /// TrackType.UserSaved Only - The date and time the track was saved. Timestamps are returned in ISO 8601 format as Coordinated Universal Time (UTC) with a zero offset: YYYY-MM-DDTHH:MM:SSZ. If the time is imprecise (for example, the date/time of an album release), an additional field indicates the precision
        /// </summary>
        public string AddedAt { get; set; }

        /// <summary>
        /// TrackType.UserRecentlyPlayed Only - The date and time the track was played. Format yyyy-MM-ddTHH:mm:ss
        /// </summary>
        public string PlayedAt { get; set; }

        /// <summary>
        /// TrackType.UserRecentlyPlayed Only - The context the track was played from
        /// </summary>
        public ContextResponse Context { get; set; }

        /// <summary>
        /// TrackType.Recommended Only - An array of recommendation seed objects
        /// </summary>
        public List<RecommendationSeedResponse> Seeds { get; set; }
        #endregion Response Properties

        #region Extended Properties
        /// <summary>
        /// Playback Start Type
        /// </summary>
        public PlaybackStartType PlaybackStartType => PlaybackStartType.Track;

        /// <summary>
        /// Play Item Type
        /// </summary>
        public PlayItemType PlayItemType => PlayItemType.Track;

        /// <summary>
        /// Artist Response
        /// </summary>
        public ArtistResponse Artist => Artists.GetArtist();

        /// <summary>
        /// Images in various sizes, if available
        /// </summary>
        public List<ImageResponse> Images => Album?.Images;

        /// <summary>
        /// Large Image
        /// </summary>
        public ImageResponse Large => Images.GetLargeImage();

        /// <summary>
        /// Medium Image
        /// </summary>
        public ImageResponse Medium => Images.GetMediumImage();

        /// <summary>
        /// Small Image
        /// </summary>
        public ImageResponse Small => Images.GetSmallImage();

        /// <summary>
        /// Duration Timespan
        /// </summary>
        public TimeSpan DurationTimeSpan => Duration.AsTimeSpan();

        /// <summary>
        /// Track Length
        /// </summary>
        public string Length => DurationTimeSpan.AsTimeSpanString();

        /// <summary>
        /// Audio Features for Track
        /// </summary>
        public AudioFeaturesResponse AudioFeatures { get; set; }

        /// <summary>
        /// Audio Analysis for Track
        /// </summary>
        public AudioAnalysisResponse AudioAnalysis { get; set; }

        /// <summary>
        /// Start/Resume a User's Playback
        /// </summary>
        public ICommand AddUserPlaybackCommand { get; set; }

        /// <summary>
        /// Add an item to the end of the user's current playback queue
        /// </summary>
        public ICommand AddUserPlaybackQueueCommand { get; set; }

        /// <summary>
        /// Add Item to a Playlist
        /// </summary>
        public ICommand AddPlaylistItemCommand { get; set; }

        /// <summary>
        /// Get Audio Analysis for a Track Command
        /// </summary>
        public ICommand GetAudioAnalysisCommand { get; set; }

        /// <summary>
        /// Get Audio Features for a Track Command
        /// </summary>
        public ICommand GetAudioFeaturesCommand { get; set; }

        /// <summary>
        /// Toggle User's Saved Track
        /// </summary>
        public Toggle ToggleSaved { get; set; }

        /// <summary>
        /// Toggle Favourite Track
        /// </summary>
        public Toggle ToggleFavourite { get; set; }
        #endregion Extended Properties
    }
}
