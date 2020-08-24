using System.Collections.Generic;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Navigation Response
    /// </summary>
    public interface INavigationResponse
    {
        /// <summary>
        /// Navigation Type
        /// </summary>
        NavigationType NavigationType { get; set; }

        /// <summary>
        /// Href
        /// </summary>
        string Href { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        object Type { get; set; }

        /// <summary>
        /// Offset
        /// </summary>
        int Offset { get; set; }

        /// <summary>
        /// Total
        /// </summary>
        int Total { get; set; }

        /// <summary>
        /// Limit
        /// </summary>
        int Limit { get; set; }

        /// <summary>
        /// Back Link
        /// </summary>
        string Back { get; set; }

        /// <summary>
        /// Next Link
        /// </summary>
        string Next { get; set; }

        /// <summary>
        /// Error Response
        /// </summary>
        ErrorResponse Error { get; set; }

        /// <summary>
        /// Navigation Requests
        /// </summary>
        List<NavigationRequest> NavigationRequests { get; }

        /// <summary>
        /// Is Success
        /// </summary>
        bool IsSuccess { get; }
    }
}
