using System;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Response User Playback Arguments
    /// </summary>
    public class ResponseUserPlaybackArgs : EventArgs
    {
        #region Public Methods
        /// <summary>
        /// Constructonr
        /// </summary>
        /// <param name="playbackType">Playback Type</param>
        /// <param name="deviceId">Device Id</param>
        public ResponseUserPlaybackArgs(PlaybackType playbackType, string deviceId = null)
        {
            PlaybackType = playbackType;
            DeviceId = deviceId;
        }
        #endregion Public Methods

        #region Public Properties
        /// <summary>
        /// Playback Type
        /// </summary>
        public PlaybackType PlaybackType { get; set; }

        /// <summary>
        /// Device Id
        /// </summary>
        public string DeviceId { get; set; }
        #endregion Public Properties
    }
}
