namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Tuneable Track Request
    /// </summary>
    public class TuneableTrackRequest
    {
        /// <summary>
        /// A confidence measure from 0.0 to 1.0 of whether the track is acoustic
        /// </summary>
        public float? Acousticness { get; set; }

        /// <summary>
        /// Danceability describes how suitable a track is for dancing based on a combination of musical elements including tempo, rhythm stability, beat strength, and overall regularity
        /// </summary>
        public float? Danceability { get; set; }

        /// <summary>
        /// The duration of the track in milliseconds
        /// </summary>
        public long? Duration { get; set; }

        /// <summary>
        /// Energy is a measure from 0.0 to 1.0 and represents a perceptual measure of intensity and activity
        /// </summary>
        public float? Energy { get; set; }

        /// <summary>
        /// Predicts whether a track contains no vocals
        /// </summary>
        public float? Instrumentalness { get; set; }

        /// <summary>
        /// The key the track is in. Integers map to pitches using standard Pitch Class notation
        /// </summary>
        public int? Key { get; set; }

        /// <summary>
        /// Detects the presence of an audience in the recording
        /// </summary>
        public float? Liveness { get; set; }

        /// <summary>
        /// The overall loudness of a track in decibels (dB)
        /// </summary>
        public float? Loudness { get; set; }

        /// <summary>
        /// Mode indicates the modality(major or minor) of a track, the type of scale from which its melodic content is derived
        /// </summary>
        public int? Mode { get; set; }

        /// <summary>
        /// The popularity of the track. The value will be between 0 and 100, with 100 being the most popular
        /// </summary>
        public int? Popularity { get; set; }

        /// <summary>
        /// Speechiness detects the presence of spoken words in a track 
        /// </summary>
        public float? Speechiness { get; set; }

        /// <summary>
        /// The overall estimated tempo of a track in beats per minute (BPM) 
        /// </summary>
        public float? Tempo { get; set; }

        /// <summary>
        /// An estimated overall time signature of a track.
        /// </summary>
        public int? TimeSignature { get; set; }

        /// <summary>
        /// A measure from 0.0 to 1.0 describing the musical positiveness conveyed by a track
        /// </summary>
        public float? Valence { get; set; }
    }
}