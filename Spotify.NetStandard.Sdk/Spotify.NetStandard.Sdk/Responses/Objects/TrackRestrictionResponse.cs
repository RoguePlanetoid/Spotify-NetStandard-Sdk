namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Track Restriction Response
    /// </summary>
    public class TrackRestrictionResponse
    {
        /// <summary>
        /// Contains the reason why the track is not available e.g. market
        /// </summary>
        public string Reason { get; set; }
    }
}
