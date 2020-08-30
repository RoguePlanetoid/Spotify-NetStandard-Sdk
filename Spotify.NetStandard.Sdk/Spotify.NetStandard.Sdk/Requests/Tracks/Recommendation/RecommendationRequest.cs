using System.Collections.Generic;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Recommendation Request
    /// </summary>
    public class RecommendationRequest
    {
        #region Public Properties
        /// <summary>
        /// One of any genres in the set of available genres. Up to 5 seed values may be provided in any combination of seedArtists, seedTracks and seedGenres
        /// </summary>
        public string SeedGenre { get; set; }

        /// <summary>
        /// (Required) List of any genres in the set of available genres. Up to 5 seed values may be provided in any combination of seedArtists, seedTracks and seedGenres
        /// </summary>
        public List<string> SeedGenres { get; set; }

        /// <summary>
        /// (Required) List of Spotify IDs for seed artists. Up to 5 seed values may be provided in any combination of seedArtists, seedTracks and seedGenres
        /// </summary>
        public List<string> SeedArtistIds { get; set; }

        /// <summary>
        /// (Required) List of Spotify IDs for a seed track. Up to 5 seed values may be provided in any combination of seedArtists, seedTracks and seedGenres
        /// </summary>
        public List<string> SeedTrackIds { get; set; }

        /// <summary>
        /// (Optional) Multiple values. For each tunable track attribute, a hard floor on the selected track attribute’s value can be provided
        /// </summary>
        public TuneableTrackRequest MinimumTuneableTrack { get; set; }

        /// <summary>
        /// (Optional) Multiple values. For each tunable track attribute, a hard ceiling on the selected track attribute’s value can be provided
        /// </summary>
        public TuneableTrackRequest MaximumTuneableTrack { get; set; }

        /// <summary>
        /// (Optional) Multiple values. For each of the tunable track attributes (below) a target value may be provided
        /// </summary>
        public TuneableTrackRequest TargetTuneableTrack { get; set; }

        /// <summary>
        /// The target size of the list of recommended tracks. Default: 20. Minimum: 1. Maximum: 100
        /// </summary>
        public int? TargetTotal { get; set; }
        #endregion Public Properties
    }
}
