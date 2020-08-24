using System.Collections.Generic;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Shows Request
    /// </summary>
    public class ShowsRequest : BaseRequest
    {
        /// <summary>
        /// (Required) Show Type
        /// </summary>
        public ShowType ShowType { get; set; }

        /// <summary>
        /// (Required) Only for ShowType.Search - Show Search Term
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// (Required) Only for ShowType.Multiple - Multiple Spotify Show Ids
        /// </summary>
        public List<string> MultipleShowIds { get; set; }

        /// <summary>
        /// (Optional) Only used for ShowType.Search - If true the response will include any relevant audio content that is hosted externally
        /// </summary>
        public bool? SearchIsExternal { get; set; }

        /// <summary>
        /// (Optional) Only for ShowType.Search, ShowType.Multiple and ShowType.UserSaved - Overrides Client Country as ISO 3166-1 alpha-2 country code e.g. GB
        /// </summary>
        public string Country { get; set; }
    }
}