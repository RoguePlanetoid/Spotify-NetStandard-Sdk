namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Resume Point Response
    /// </summary>
    public class ResumePointResponse
    {
        /// <summary>
        /// Whether or not the episode has been fully played by the user
        /// </summary>
        public bool FullyPlayed { get; set; }

        /// <summary>
        /// The user’s most recent position in the episode in milliseconds
        /// </summary>
        public long ResumePosition { get; set; }
    }
}
