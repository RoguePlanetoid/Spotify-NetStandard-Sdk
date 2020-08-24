using Spotify.NetStandard.Sdk.Internal;
using System.Collections.Generic;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Navigation Response
    /// </summary>
    /// <typeparam name="TResponse">Response Type</typeparam>
    public class NavigationResponse<TResponse> : BaseResponse, INavigationResponse
    {
        #region Response Properties
        /// <summary>
        /// Navigation Type
        /// </summary>
        public NavigationType NavigationType { get; set; }

        /// <summary>
        /// Href
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public object Type { get; set; }

        /// <summary>
        /// Offset
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Total
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Limit
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Back Link
        /// </summary>
        public string Back { get; set; }

        /// <summary>
        /// Next Link
        /// </summary>
        public string Next { get; set; }

        /// <summary>
        /// Items
        /// </summary>
        public List<TResponse> Items { get; set; }
        #endregion Response Properties

        #region Extended Properties
        /// <summary>
        /// Navigation Requests
        /// </summary>
        public List<NavigationRequest> NavigationRequests => 
            Helpers.ListNavigationRequests(this);
        #endregion Extended Properties
    }
}
