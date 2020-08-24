namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Search Request
    /// </summary>
    public class SearchRequest : BaseRequest
    {
        #region Public Properties
        /// <summary>
        /// (Required) Search Query
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// (Required) Search results include hits from all the specified item types
        /// </summary>
        public SearchTypeRequest SearchTypeRequest { get; set; }

        /// <summary>
        /// (Optional) Include any relevant audio content that is hosted externally
        /// </summary>
        public bool? External { get; set; }

        /// <summary>
        /// (Optional) Overrides Client Country as ISO 3166-1 alpha-2 country code e.g. GB
        /// </summary>
        public string Country { get; set; }
        #endregion Public Properties
    }
}
