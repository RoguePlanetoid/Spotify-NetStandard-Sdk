using Spotify.NetStandard.Sdk.Internal;
using System;
using System.Windows.Input;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Currently Playing Item Response
    /// </summary>
    public class CurrentlyPlayingItemResponse : BaseResponse
    {
        #region Response Properties
        /// <summary>
        /// A Context Object. Can be null
        /// </summary>
        public ContextResponse Context { get; set; }

        /// <summary>
        /// Unix Millisecond Timestamp when data was fetched
        /// </summary>
        public long TimeStamp { get; set; }

        /// <summary>
        /// Progress into the currently playing track or episode. Can be null.
        /// </summary>
        public long? Progress { get; set; }

        /// <summary>
        /// If something is currently playing, return true.
        /// </summary>
        public bool IsPlaying { get; set; }

        /// <summary>
        /// The currently playing track. Can be null.
        /// </summary>
        public TrackResponse Track { get; set; }

        /// <summary>
        /// The currently playing episode. Can be null.
        /// </summary>
        public EpisodeResponse Episode { get; set; }

        /// <summary>
        /// The object type of the currently playing item. Can be one of track, episode, ad or unknown.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Allows to update the user interface based on which playback actions are available within the current context
        /// </summary>
        public ActionsResponse Actions { get; set; }
        #endregion Response Properties

        #region Extended Properties
        /// <summary>
        /// Has Context?
        /// </summary>
        public bool HasContext => Context != null;

        /// <summary>
        /// The currently playing item, Track or Episode
        /// </summary>
        public IPlayItemResponse Current =>
            Track ?? (Episode ?? null) as IPlayItemResponse;

        /// <summary>
        /// Play Item Type of Track or Episode
        /// </summary>
        public PlayItemType PlayItemType =>
            Current.PlayItemType;

        /// <summary>
        /// Has Progress
        /// </summary>
        public bool HasProgress => Progress != null;

        /// <summary>
        /// Duration
        /// </summary>
        public long Duration => Current.Duration;

        /// <summary>
        /// Duration Timespan
        /// </summary>
        public TimeSpan DurationTimeSpan => Duration.AsTimeSpan();

        /// <summary>
        /// Progress TimeSpan
        /// </summary>
        public TimeSpan ProgressTimeSpan => 
            Progress != null ? 
            Progress.Value.AsTimeSpan() :
            TimeSpan.Zero;

        /// <summary>
        /// Skip User’s Playback To Next Track
        /// </summary>
        public ICommand UserPlaybackNextCommand { get; set; }

        /// <summary>
        /// Skip User’s Playback To Previous Track
        /// </summary>
        public ICommand UserPlaybackPreviousCommand { get; set; }

        /// <summary>
        /// Pause a User's Playback
        /// </summary>
        public ICommand UserPlaybackPauseCommand { get; set; }

        /// <summary>
        /// Resume a User's Playback
        /// </summary>
        public ICommand UserPlaybackResumeCommand { get; set; }
        #endregion Extended Properties
    }
}