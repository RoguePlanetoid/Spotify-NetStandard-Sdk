using System.Collections.Generic;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Tracks Request
    /// </summary>
    public class TracksRequest : BaseRequest
    {
        /// <summary>
        /// (Required) Track Type
        /// </summary>
        public TrackType TrackType { get; set; }

        /// <summary>
        /// (Required) Only for TrackType.Search - Track Search Term, TrackType.Recommended - Genre, TrackType.Album - Spotify Album Id and TrackType.Artist - Spotify Artist Id
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// (Required) Only for TrackType.Multiple - Multiple Spotify Track Ids
        /// </summary>
        public List<string> MultipleTrackIds { get; set; }

        /// <summary>
        /// (Optional) Only used for TrackType.Search - If true the response will include any relevant audio content that is hosted externally
        /// </summary>
        public bool? SearchIsExternal { get; set; }

        /// <summary>
        /// (Optional) Only used for TrackType.Recommended where Value not Provided - Recommendation Request
        /// </summary>
        public RecommendationRequest Recommendation { get; set; }

        /// <summary>
        /// (Optional) Only used for TrackType.Search, TrackType.Album, TrackType.Artist and TrackType.UserSaved - Overrides Client Country as ISO 3166-1 alpha-2 country code e.g. GB
        /// </summary>
        public string Country { get; set; }
    }
}
