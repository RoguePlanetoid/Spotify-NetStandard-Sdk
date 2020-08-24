using Spotify.NetStandard.Sdk.Internal;
using System.Collections.Generic;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// User Response
    /// </summary>
    public class UserResponse : BaseContentResponse, IResponse
    {
        #region Response Properties
        /// <summary>
        /// The name displayed on the user’s profile. null if not available.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The user’s profile image.
        /// </summary>
        public List<ImageResponse> Images { get; set; }

        /// <summary>
        /// Information about the followers of this user.
        /// </summary>
        public FollowersResponse Followers { get; set; }
        #endregion Response Properties

        #region Extended Proprties
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
        /// Toggle Following State for User
        /// </summary>
        public Toggle ToggleFollow { get; set; }
        #endregion Extended Properties
    }
}
