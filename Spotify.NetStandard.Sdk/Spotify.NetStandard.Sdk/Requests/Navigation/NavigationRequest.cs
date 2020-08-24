namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Navigation Request
    /// </summary>
    public class NavigationRequest
    {
        /// <summary>
        /// Index of first object to return
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Maximum number of objects to return
        /// </summary>
        public int Limit { get; set; }
    }
}
