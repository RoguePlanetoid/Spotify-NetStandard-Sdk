namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Include Group Request
    /// </summary>
    public class IncludeGroupRequest
    {
        /// <summary>
        /// Album (Optional)
        /// </summary>
        public bool? Album { get; set; }

        /// <summary>
        /// Single (Optional)
        /// </summary>
        public bool? Single { get; set; }

        /// <summary>
        /// Appears On (Optional)
        /// </summary>
        public bool? AppearsOn { get; set; }

        /// <summary>
        /// Compliation (Optional)
        /// </summary>
        public bool? Compilation { get; set; }
    }
}
