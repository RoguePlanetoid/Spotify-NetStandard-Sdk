using Spotify.NetStandard.Sdk.Internal;
using System.Collections.Generic;
using System.Windows.Input;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Playlist Response
    /// </summary>
    public class PlaylistResponse : BaseContentResponse, IPlaybackResponse
    {
        #region Response Properties
        /// <summary>
        /// Returns true if the owner allows other users to modify the playlist
        /// </summary>
        public bool Collaborative { get; set; }

        /// <summary>
        /// Images for the playlist. The array may be empty or contain up to three images. The images are returned by size in descending order
        /// </summary>
        public List<ImageResponse> Images { get; set; }

        /// <summary>
        /// The user who owns the playlist
        /// </summary>
        public UserResponse Owner { get; set; }

        /// <summary>
        /// The playlist's public/private status: true the playlist is public, false the playlist is private, null the playlist status is not relevant
        /// </summary>
        public bool? Public { get; set; }

        /// <summary>
        /// The version identifier for the current playlist
        /// </summary>
        public string SnapshotId { get; set; }

        /// <summary>
        /// Information about the items of the playlist
        /// </summary>
        public NavigationResponse<PlaylistItemResponse> Tracks { get; set; }

        /// <summary>
        /// The playlist description. Only returned for modified, verified playlists, otherwise null
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Information about the followers of the playlist
        /// </summary>
        public FollowersResponse Followers { get; set; }
        #endregion Response Properties

        #region Extended Properties
        /// <summary>
        /// Playback Start Type
        /// </summary>
        public PlaybackStartType PlaybackStartType => PlaybackStartType.Playlist;

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
        /// The total number of followers
        /// </summary>
        public int TotalFollowers => Followers?.Total ?? 0;

        /// <summary>
        /// Is Own Playlist, Requires Current User
        /// </summary>
        public bool IsOwnPlaylist { get; set; }

        /// <summary>
        /// Is Editable, Requires Current User
        /// </summary>
        public bool IsEditable { get; set; }

        /// <summary>
        /// Start/Resume a User's Playback
        /// </summary>
        public ICommand AddUserPlaybackCommand { get; set; }

        /// <summary>
        /// Is Own Playlist Only - Upload a Custom Playlist Cover Image -
        /// </summary>
        public ICommand SetPlaylistImageCommand { get; set; }

        /// <summary>
        /// Is Own Playlist Only - Change a Playlist's Details
        /// </summary>
        public ICommand SetPlaylistCommand { get; set; }

        /// <summary>
        /// Get Playlist Only - Toggle Following State for Playlist
        /// </summary>
        public Toggle ToggleFollow { get; set; }
        #endregion Extended Properties
    }
}
