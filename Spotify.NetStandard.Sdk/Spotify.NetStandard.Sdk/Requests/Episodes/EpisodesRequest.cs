using System.Collections.Generic;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Episodes Request
    /// </summary>
    public class EpisodesRequest : BaseRequest
    {
        /// <summary>
        /// (Required) Episode Type
        /// </summary>
        public EpisodeType EpisodeType { get; set; }

        /// <summary>
        /// (Required) Only for EpisodeType.Search - Episode Search Term or EpisodeType.Show - Show Id
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// (Required) Only for EpisodeType.Multiple - Multiple Spotify Episode Ids
        /// </summary>
        public List<string> MultipleEpisodeIds { get; set; }

        /// <summary>
        /// (Optional) Only for EpisodeType.Search - If true the response will include any relevant audio content that is hosted externally.
        /// </summary>
        public bool? SearchIsExternal { get; set; }

        /// <summary>
        /// (Optional) Overrides Client Country as ISO 3166-1 alpha-2 country code e.g. GB
        /// </summary>
        public string Country { get; set; }
    }
}