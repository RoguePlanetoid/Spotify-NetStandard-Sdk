using Spotify.NetStandard.Sdk.Internal;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Episode Response
    /// </summary>
    public class EpisodeResponse : BaseContentResponse, IPlayItemResponse
    {
        #region Response Properties
        /// <summary>
        /// A URL to a 30 second preview (MP3 format) of the episode - null if not available
        /// </summary>
        public string Preview { get; set; }

        /// <summary>
        /// The description of the episode
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The episode length in milliseconds
        /// </summary>
        public long Duration { get; set; }

        /// <summary>
        /// Whether or not the episode has explicit content ( true = yes it does; false = no it does not OR unknown)
        /// </summary>
        public bool IsExplicit { get; set; }

        /// <summary>
        /// The cover art for the episode in various sizes, widest first
        /// </summary>
        public List<ImageResponse> Images { get; set; }

        /// <summary>
        /// True if the episode is hosted outside of Spotify's CDN
        /// </summary>
        public bool IsExternallyHosted { get; set; }

        /// <summary>
        /// True if the episode is playable in the given market. Otherwise false
        /// </summary>
        public bool IsPlayable { get; set; }

        /// <summary>
        /// A list of the languages used in the episode, identified by their ISO 639 code
        /// </summary>
        public List<string> Languages { get; set; }

        /// <summary>
        /// The date the episode was first released, for example 1981-12-15. Depending on the precision, it might be shown as 1981 or 1981-12
        /// </summary>
        public string ReleaseDate { get; set; }

        /// <summary>
        /// The precision with which ReleaseDate value is known: year, month, or day
        /// </summary>
        public string ReleaseDatePrecision { get; set; }

        /// <summary>
        /// The user's most recent position in the episode. Set if the supplied access token is a user token and has the scope user-read-playback-position
        /// </summary>
        public ResumePointResponse ResumePoint { get; set; }

        /// <summary>
        /// The show on which the episode belongs.
        /// </summary>
        public ShowResponse Show { get; set; }
        #endregion Response Properties

        #region Extended Properties
        /// <summary>
        /// Playback Start Type
        /// </summary>
        public PlaybackStartType PlaybackStartType => PlaybackStartType.Episode;

        /// <summary>
        /// Play Item Type
        /// </summary>
        public PlayItemType PlayItemType => PlayItemType.Episode;

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
        public TimeSpan DurationTimeSpan => 
            Duration.AsTimeSpan();

        /// <summary>
        /// Episode Length
        /// </summary>
        public string Length => 
            DurationTimeSpan.AsTimeSpanString();

        /// <summary>
        /// Has Progress?
        /// </summary>
        public bool HasProgress =>
            ResumePoint != null;

        /// <summary>
        /// Episode Played Progress Percentage
        /// </summary>
        public int ProgressPercentage =>
            this.GetProgressPercentage();

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
        /// Toggle Favourite Episode
        /// </summary>
        public Toggle ToggleFavourite { get; set; }
        #endregion Extended Properties
    }
}
