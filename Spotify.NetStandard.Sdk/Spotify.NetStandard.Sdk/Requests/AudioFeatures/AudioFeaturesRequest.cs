using System.Collections.Generic;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Audio Features Request
    /// </summary>
    public class AudioFeaturesRequest
    {
        /// <summary>
        /// (Required) Multiple Track Spotify Ids
        /// </summary>
        public List<string> MultipleTrackIds { get; set; }
    }
}
