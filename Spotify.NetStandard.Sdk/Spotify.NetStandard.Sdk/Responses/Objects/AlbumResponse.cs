using Spotify.NetStandard.Sdk.Internal;
using System.Collections.Generic;
using System.Windows.Input;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Album Response
    /// </summary>
    public class AlbumResponse : BaseContentResponse, IPlaybackResponse
    {
        #region Response Properties
        /// <summary>
        /// The field is present when getting an artist’s albums. Possible values are “album”, “single”, “compilation”, “appears_on”
        /// </summary>
        public string AlbumGroup { get; set; }

        /// <summary>
        /// The type of the album: one of "album", "single", or "compilation"
        /// </summary>
        public string AlbumType { get; set; }

        /// <summary>
        /// The artists of the album. Each artist response includes a link in href to more detailed information about the artist
        /// </summary>
        public List<ArtistResponse> Artists { get; set; }

        /// <summary>
        /// The markets in which the album is available: ISO 3166-1 alpha-2 country codes
        /// </summary>
        public List<string> AvailableMarkets { get; set; }

        /// <summary>
        /// The cover art for the album in various sizes, widest first
        /// </summary>
        public List<ImageResponse> Images { get; set; }

        /// <summary>
        /// The total number of tracks
        /// </summary>
        public int TotalTracks { get; set; }

        /// <summary>
        /// The copyright statements of the album.
        /// </summary>
        public List<CopyrightResponse> Copyrights { get; set; }

        /// <summary>
        /// Known external IDs for the album.
        /// </summary>
        public ExternalIdResponse ExternalId { get; set; }

        /// <summary>
        /// A list of the genres used to classify the album. For example: "Prog Rock", "Post-Grunge"
        /// </summary>
        public List<string> Genres { get; set; }

        /// <summary>
        /// The label for the album.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The popularity of the album. The value will be between 0 and 100, with 100 being the most popular
        /// </summary>
        public int Popularity { get; set; }

        /// <summary>
        /// The date the album was first released, for example 1981. Depending on the precision, it might be shown as 1981-12 or 1981-12-15
        /// </summary>
        public string ReleaseDate { get; set; }

        /// <summary>
        /// The precision with which ReleaseDate value is known: year, month, or day.
        /// </summary>
        public string ReleaseDatePrecision { get; set; }

        /// <summary>
        /// The tracks of the album
        /// </summary>
        public NavigationResponse<TrackResponse> Tracks { get; set; }

        /// <summary>
        /// AlbumType.UserSaved Only - The date and time the album was saved Timestamps are returned in ISO 8601 format as Coordinated Universal Time (UTC) with a zero offset: YYYY-MM-DDTHH:MM:SSZ. If the time is imprecise (for example, the date/time of an album release), an additional field indicates the precision; see for example, ReleaseDate in an album object
        /// </summary>
        public string AddedAt { get; set; }
        #endregion Response Properties

        #region Extended Properties
        /// <summary>
        /// Playback Start Type
        /// </summary>
        public PlaybackStartType PlaybackStartType => PlaybackStartType.Album;

        /// <summary>
        /// Artist Response
        /// </summary>
        public ArtistResponse Artist => Artists.GetArtist();

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
        /// Release Date Year
        /// </summary>
        public string ReleaseDateYear => ReleaseDate.GetReleaseYear();

        /// <summary>
        /// Start/Resume a User's Playback
        /// </summary>
        public ICommand AddUserPlaybackCommand { get; set; }

        /// <summary>
        /// Toggle User's Saved Album
        /// </summary>
        public Toggle ToggleSaved { get; set; }

        /// <summary>
        /// Toggle Favourite Album
        /// </summary>
        public Toggle ToggleFavourite { get; set; }
        #endregion Extended Properties
    }
}
