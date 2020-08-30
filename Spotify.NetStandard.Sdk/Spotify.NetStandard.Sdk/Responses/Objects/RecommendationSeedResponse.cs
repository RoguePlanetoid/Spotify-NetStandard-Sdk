namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Recommendation Seed Response
    /// </summary>
    public class RecommendationSeedResponse : BaseContentResponse
    {
        /// <summary>
        /// The number of tracks available after min_* and max_* filters have been applied
        /// </summary>
        public int AfterFilteringSize { get; set; }

        /// <summary>
        /// The number of tracks available after relinking for regional availability
        /// </summary>
        public int AfterRelinkingSize { get; set; }

        /// <summary>
        /// The number of recommended tracks available for this seed
        /// </summary>
        public int InitialPoolSize { get; set; }
    }
}
