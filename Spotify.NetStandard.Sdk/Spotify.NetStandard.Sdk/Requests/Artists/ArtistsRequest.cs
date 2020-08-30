using System.Collections.Generic;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Artists Request
    /// </summary>
    public class ArtistsRequest : BaseRequest
    {
        /// <summary>
        /// (Required) Artist Type
        /// </summary>
        public ArtistType ArtistType { get; set; }

        /// <summary>
        /// (Required) Only for ArtistType.Search - Artist Search Term and ArtistType.Related - Artist Id
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// (Required) Only for ArtistType.Multiple - Multiple Artist Spotify Ids
        /// </summary>
        public List<string> MultipleArtistIds { get; set; }

        /// <summary>
        /// (Optional) Only for ArtistType.Search - If true the response will include any relevant audio content that is hosted externally.
        /// </summary>
        public bool? SearchIsExternal { get; set; }

        /// <summary>
        /// (Optional) Only for ArtistType.UserTop - Long Term: calculated from several years of data and including all new data as it becomes available, Medium Term: (Default) approximately last 6 months, Short Term: approximately last 4 weeks
        /// </summary>
        public UserTopTimeRangeType? UserTopTimeRangeType { get; set; }

        /// <summary>
        /// (Optional) Only for ArtistType.Search - Overrides Client Country as ISO 3166-1 alpha-2 country code e.g. GB
        /// </summary>
        public string Country { get; set; }
    }
}