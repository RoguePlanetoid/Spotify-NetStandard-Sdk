namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Categories Request
    /// </summary>
    public class CategoriesRequest : BaseRequest
    {
        /// <summary>
        /// (Optional) Overrides Client Country as ISO 3166-1 alpha-2 country code e.g. GB
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// (Optional) Overrides Client Locale as ISO 639-1 language code and an ISO 3166-1 alpha-2 country code, joined by an underscore e.g. en_GB
        /// </summary>
        public string Locale { get; set; }
    }
}
