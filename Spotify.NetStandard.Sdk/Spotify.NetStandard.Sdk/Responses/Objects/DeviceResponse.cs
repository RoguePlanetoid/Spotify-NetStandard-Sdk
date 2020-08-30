using System.Windows.Input;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Device Response
    /// </summary>
    public class DeviceResponse
    {
        #region Response Properties
        /// <summary>
        /// The device Id. This may be null
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// If this device is the currently active device
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// If this device is currently in a private session
        /// </summary>
        public bool IsPrivateSession { get; set; }

        /// <summary>
        /// Whether controlling this device is restricted. If true then no commands will be accepted by this device
        /// </summary>
        public bool IsRestricted { get; set; }

        /// <summary>
        /// The name of the device.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Device type, such as “computer”, “smartphone” or “speaker”
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The current volume in percent This may be null
        /// </summary>
        public int? Volume { get; set; }
        #endregion Response Properties

        #region Extended Properties
        /// <summary>
        /// Transfer a User's Playback
        /// </summary>
        public ICommand TransferUserPlaybackCommand { get; set; }
        #endregion Extended Properties
    }
}
