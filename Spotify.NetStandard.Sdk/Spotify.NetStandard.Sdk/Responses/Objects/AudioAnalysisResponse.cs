using System.Collections.Generic;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Audio Analysis Response
    /// </summary>
    public class AudioAnalysisResponse : BaseResponse
    {
        /// <summary>
        /// The time intervals of the bars throughout the track
        /// </summary>
        public List<TimeIntervalResponse> Bars { get; set; }

        /// <summary>
        /// The time intervals of beats throughout the track
        /// </summary>
        public List<TimeIntervalResponse> Beats { get; set; }

        /// <summary>
        /// Sections are defined by large variations in rhythm or timbre, e.g.chorus, verse, bridge, guitar solo, etc
        /// </summary>
        public List<SectionResponse> Sections { get; set; }

        /// <summary>
        /// Audio segments attempts to subdivide a song into many segments, with each segment containing a roughly consitent sound throughout its duration
        /// </summary>
        public List<SegmentResponse> Segments { get; set; }

        /// <summary>
        /// A tatum represents the lowest regular pulse train that a listener intuitively infers from the timing of perceived musical events
        /// </summary>
        public List<TimeIntervalResponse> Tatums { get; set; }
    }
}
