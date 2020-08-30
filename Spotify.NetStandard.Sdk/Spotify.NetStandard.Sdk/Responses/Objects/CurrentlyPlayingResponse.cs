using Spotify.NetStandard.Sdk.Internal;
using System.Windows.Input;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Currently Playing Response
    /// </summary>
    public class CurrentlyPlayingResponse : CurrentlyPlayingItemResponse
    {
        #region Response Properties
        /// <summary>
        /// The device that is currently active
        /// </summary>
        public DeviceResponse Device { get; set; }

        /// <summary>
        /// The repeat state: off, track, context
        /// </summary>
        public string RepeatState { get; set; }

        /// <summary>
        /// If shuffle is on or off
        /// </summary>
        public bool ShuffleState { get; set; }
        #endregion Response Properties

        #region Extended Properties
        /// <summary>
        /// Has Device?
        /// </summary>
        public bool HasDevice => Device != null;

        /// <summary>
        /// Has Volume?
        /// </summary>
        public bool HasVolume => Device?.Volume != null;

        /// <summary>
        /// Is Repeat State Off?
        /// </summary>
        public bool IsRepeatStateOff =>
            Helpers.IsRepeatStateOff(RepeatState);

        /// <summary>
        /// Is Repeat State Track?
        /// </summary>
        public bool IsRepeatStateTrack =>
            Helpers.IsRepeatStateTrack(RepeatState);

        /// <summary>
        /// Is Repeat State Context?
        /// </summary>
        public bool IsRepeatStateContext =>
            Helpers.IsRepeatStateContext(RepeatState);

        /// <summary>
        /// Toggle Shuffle For User’s Playback
        /// </summary>
        public ICommand UserPlaybackShuffleCommand { get; set; }

        /// <summary>
        /// Set Repeat Mode On User’s Playback
        /// </summary>
        public ICommand UserPlaybackRepeatCommand { get; set; }

        /// <summary>
        /// Set Repeat Off For User’s Playback
        /// </summary>
        public ICommand UserPlaybackRepeatOffCommand { get; set; }

        /// <summary>
        /// Set Repeat Off For User’s Playback
        /// </summary>
        public ICommand UserPlaybackRepeatTrackCommand { get; set; }

        /// <summary>
        /// Set Repeat Context For User’s Playback
        /// </summary>
        public ICommand UserPlaybackRepeatContextCommand { get; set; }

        /// <summary>
        /// Set Seek for User's Playback
        /// </summary>
        public ICommand UserPlaybackSeekCommand { get; set; }

        /// <summary>
        /// Set Volume for User's Playback
        /// </summary>
        public ICommand UserPlaybackVolumeCommand { get; set; }
        #endregion Extended Properties
    }
}
