using System.Windows.Input;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Available Recommendation Genre Seed Response
    /// </summary>
    public class RecommendationGenreResponse
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Command
        /// </summary>
        public ICommand Command { get; set; }
    }
}
