﻿namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Followers Response
    /// </summary>
    public class FollowersResponse
    {
        /// <summary>
        /// A link to the Web API endpoint providing full details of the followers; null if not available
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// The total number of followers
        /// </summary>
        public int Total { get; set; }
    }
}
