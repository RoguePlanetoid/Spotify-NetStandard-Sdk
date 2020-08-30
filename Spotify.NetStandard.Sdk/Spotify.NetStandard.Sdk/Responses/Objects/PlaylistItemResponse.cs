using System;
using System.Windows.Input;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Playlist Item Response
    /// </summary>
    public class PlaylistItemResponse : BaseResponse, IPlaylistItemResponse
    {
        #region Response Properties
        /// <summary>
        /// The date and time the Track or Episode was added
        /// </summary>
        public DateTime? AddedAt { get; set; }

        /// <summary>
        /// The Spotify user who added the Track or Episode
        /// </summary>
        public UserResponse AddedBy { get; set; }

        /// <summary>
        /// Whether this track is a local file or not.
        /// </summary>
        public bool IsLocal { get; set; }

        /// <summary>
        /// Information about the Track
        /// </summary>
        public TrackResponse Track { get; set; }

        /// <summary>
        /// Information about the Episode
        /// </summary>
        public EpisodeResponse Episode { get; set; }
        #endregion Response Properties

        #region Extended Properties
        /// <summary>
        /// Play Item Response of Current Track or Episode
        /// </summary>
        public IPlayItemResponse Current =>
            Track ?? (Episode ?? null) as IPlayItemResponse;

        /// <summary>
        /// Play Item Type of Track or Episode
        /// </summary>
        public PlayItemType PlayItemType =>
            Current.PlayItemType;

        /// <summary>
        /// Remove Items from a Playlist
        /// </summary>
        public ICommand RemovePlaylistItemCommand { get; set; }
        #endregion Extended Properties
    }
}
