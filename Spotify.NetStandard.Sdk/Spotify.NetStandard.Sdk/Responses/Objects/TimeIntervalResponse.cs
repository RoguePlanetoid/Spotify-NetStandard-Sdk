using Spotify.NetStandard.Sdk.Internal;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Time Interval Response
    /// </summary>
    public class TimeIntervalResponse
    {
        #region Response Properties
        /// <summary>
        /// The starting point in seconds
        /// </summary>
        public float? Start { get; set; }

        /// <summary>
        /// The duration in seconds
        /// </summary>
        public float? Duration { get; set; }

        /// <summary>
        /// The reliability confidence, from 0.0 to 1.0
        /// </summary>
        public float? Confidence { get; set; }
        #endregion Response Properties

        #region Extended Properties
        /// <summary>
        /// The reliability confidence percentage, from 0 to 100%
        /// </summary>
        public int ConfidencePercentage =>
            Helpers.GetAudioPercentage(Confidence);
        #endregion Extended Properties
    }
}
