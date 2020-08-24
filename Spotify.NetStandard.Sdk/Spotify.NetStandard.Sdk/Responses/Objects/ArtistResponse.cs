using Spotify.NetStandard.Sdk.Internal;
using System.Collections.Generic;
using System.Windows.Input;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Artist Response
    /// </summary>
    public class ArtistResponse : BaseContentResponse, IPlaybackResponse
    {
        #region Response Properties
        /// <summary>
        /// Information about the followers of the artist
        /// </summary>
        public FollowersResponse Followers { get; set; }

        /// <summary>
        /// A list of the genres the artist is associated with. For example: "Prog Rock", "Post-Grunge"
        /// </summary>
        public List<string> Genres { get; set; }

        /// <summary>
        /// Images of the artist in various sizes, widest first
        /// </summary>
        public List<ImageResponse> Images { get; set; }

        /// <summary>
        /// The popularity of the artist. The value will be between 0 and 100, with 100 being the most popular
        /// </summary>
        public int Popularity { get; set; }
        #endregion Response Properties

        #region Extended Properties
        /// <summary>
        /// Playback Start Type
        /// </summary>
        public PlaybackStartType PlaybackStartType => PlaybackStartType.Artist;

        /// <summary>
        /// The total number of followers.
        /// </summary>
        public int TotalFollowers => Followers?.Total ?? 0;

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
        /// Toggle Following State for Artist
        /// </summary>
        public Toggle ToggleFollow { get; set; }

        /// <summary>
        /// Toggle Favourite Artist
        /// </summary>
        public Toggle ToggleFavourite { get; set; }
        #endregion Extended Properties
    }
}
