using Spotify.NetStandard.Sdk.Internal;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Current User Response
    /// </summary>
    public class CurrentUserResponse : UserResponse
    {
        #region Response Properties
        /// <summary>
        /// The country of the user, as set in the user’s account profile. An ISO 3166-1 alpha-2 country code.This field is only available when the current user has granted access to the UserReadPrivate scope
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// The user’s email address, as entered by the user when creating their account. his field is only available when the current user has granted access to the UserReadEmail scope
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The user’s Spotify subscription level: “premium”, “free”, etc. This field is only available when the current user has granted access to the UserReadPrivate scope
        /// </summary>
        public string Product { get; set; }
        #endregion Response Properties

        #region Extended Properties
        /// <summary>
        /// Is Premium Subscription?
        /// </summary>
        public bool IsPremium =>
            Helpers.IsPremium(Product);
        #endregion Extended Properties
    }
}
