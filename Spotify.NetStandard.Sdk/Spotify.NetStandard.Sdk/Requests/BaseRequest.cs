namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Base Request
    /// </summary>
    public abstract class BaseRequest
    {
        /// <summary>
        /// (Optional) Navigation Request
        /// </summary>
        public NavigationRequest NavigationRequest { get; set; }
    }
}
