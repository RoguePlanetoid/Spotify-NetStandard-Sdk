using Spotify.NetStandard.Sdk.Internal;
using System.Collections.Generic;
using System.Windows.Input;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Show Response
    /// </summary>
    public class ShowResponse : BaseContentResponse, IPlaybackResponse
    {
        #region Response Properties
        /// <summary>
        /// A list of the countries in which the show can be played, identified by their ISO 3166-1 alpha-2 code
        /// </summary>
        public List<string> AvailableMarkets { get; set; }

        /// <summary>
        /// The copyright statements of the show
        /// </summary>
        public List<CopyrightResponse> Copyrights { get; set; }

        /// <summary>
        /// A description of the show
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Whether or not the show has explicit content ( true = yes it does; false = no it does not OR unknown)
        /// </summary>
        public bool IsExplicit { get; set; }

        /// <summary>
        /// The cover art for the show in various sizes, widest first
        /// </summary>
        public List<ImageResponse> Images { get; set; }

        /// <summary>
        /// True if all of the show's episodes are hosted outside of Spotify’s CDN
        /// </summary>
        public bool IsExternallyHosted { get; set; }

        /// <summary>
        /// A list of the languages used in the show, identified by their ISO 639 code
        /// </summary>
        public List<string> Languages { get; set; }

        /// <summary>
        /// The media type of the show
        /// </summary>
        public string MediaType { get; set; }

        /// <summary>
        /// The publisher of the show
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// A list of the show’s episodes.
        /// </summary>
        public NavigationResponse<EpisodeResponse> Episodes { get; set;  }

        /// <summary>
        /// ShowType.UserSaved Only - The date and time the show was saved. Timestamps are returned in ISO 8601 format as Coordinated Universal Time (UTC) with a zero offset: YYYY-MM-DDTHH:MM:SSZ. If the time is imprecise (for example, the date/time of an show release), an additional field indicates the precision; see for example, ReleaseDate in a show object.
        /// </summary>
        public string AddedAt { get; set; }
        #endregion Response Properties

        #region Extended Properties
        /// <summary>
        /// Playback Start Type
        /// </summary>
        public PlaybackStartType PlaybackStartType => PlaybackStartType.Show;

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
        /// Start/Resume a User's Playback
        /// </summary>
        public ICommand AddUserPlaybackCommand { get; set; }

        /// <summary>
        /// Toggle User's Saved Show
        /// </summary>
        public Toggle ToggleSaved { get; set; }

        /// <summary>
        /// Toggle Favourite Show
        /// </summary>
        public Toggle ToggleFavourite { get; set; }
        #endregion Extended Properties
    }
}
