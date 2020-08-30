namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// External Id Response
    /// </summary>
    public class ExternalIdResponse
    {
        /// <summary>
        /// International Standard Recording Code
        /// </summary>
        public string Isrc { get; set; }

        /// <summary>
        /// International Article Number
        /// </summary>
        public string Ean { get; set; }

        /// <summary>
        /// Universal Product Code
        /// </summary>
        public string Upc { get; set; }
    }
}
