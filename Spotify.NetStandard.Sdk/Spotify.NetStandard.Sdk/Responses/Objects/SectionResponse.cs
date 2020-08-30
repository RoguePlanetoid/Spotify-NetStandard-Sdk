using Spotify.NetStandard.Sdk.Internal;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Section Response
    /// </summary>
    public class SectionResponse : TimeIntervalResponse
    {
        #region Response Properties
        /// <summary>
        /// The overall loudness of the section in decibels (dB)
        /// </summary>
        public float? Loudness { get; set; }

        /// <summary>
        /// The overall estimated tempo of the section in beats per minute (BPM)  
        /// </summary>
        public float? Tempo { get; set; }

        /// <summary>
        /// The confidence, from 0.0 to 1.0, of the reliability of the tempo
        /// </summary>
        public float? TempoConfidence { get; set; }

        /// <summary>
        /// The estimated overall key of the section. The values in this field ranging from 0 to 11 mapping to pitches using standard Pitch Class notation
        /// </summary>
        public int? Key { get; set; }

        /// <summary>
        /// The confidence, from 0.0 to 1.0, of the reliability of the key
        /// </summary>
        public float? KeyConfidence { get; set; }

        /// <summary>
        /// Indicates the modality (major or minor) of a track, the type of scale from which its melodic content is derived.This field will contain a 0 for “minor”, a 1 for “major”, or a -1 for no result
        /// </summary>
        public int? Mode { get; set; }

        /// <summary>
        /// The confidence, from 0.0 to 1.0, of the reliability of the mode
        /// </summary>
        public float? ModeConfidence { get; set; }

        /// <summary>
        /// An estimated overall time signature of a track. The time signature (meter) is a notational convention to specify how many beats are in each bar (or measure). The time signature ranges from 3 to 7 indicating time signatures of “3/4”, to “7/4”
        /// </summary>
        public int? TimeSignature { get; set; }

        /// <summary>
        /// The confidence, from 0.0 to 1.0, of the reliability of the time_signature
        /// </summary>
        public float? TimeSignatureConfidence { get; set; }
        #endregion Response Properties

        #region Extension Properties
        /// <summary>
        /// The overall rounded loudness of the section in decibels (dB)
        /// </summary>
        public int LoudnessValue =>
            Helpers.GetAudioValue(Loudness);

        /// <summary>
        /// The overall estimated rounded tempo of the section in beats per minute (BPM) 
        /// </summary>
        public int TempoValue =>
            Helpers.GetAudioValue(Tempo);

        /// <summary>
        /// The confidence percentage, from 0% to 100%, of the reliability of the tempo
        /// </summary>
        public int TempoConfidencePercentage =>
             Helpers.GetAudioPercentage(Tempo);

        /// <summary>
        /// The estimated overall key of the section. The values in this field using standard Pitch Class notation of C, C♯, D, D♯, E, F, F♯, G, G♯, A, A♯ or B
        /// </summary>
        public string KeyString => 
            Helpers.GetAudioKey(Key);

        /// <summary>
        /// The confidence percentage, from 0% to 100%, of the reliability of the key
        /// </summary>
        public int KeyConfidencePercentage =>
             Helpers.GetAudioPercentage(KeyConfidence);

        /// <summary>
        /// Indicates the modality of a track, the type of scale from which its melodic content is derived which can be Major, Minor or Empty String
        /// </summary>
        public string ModeString =>
            Helpers.GetAudioMode(Mode);

        /// <summary>
        /// The confidence percentage, from 0% to 100%, of the reliability of the mode
        /// </summary>
        public int ModePercentage =>
             Helpers.GetAudioPercentage(ModeConfidence);

        /// <summary>
        /// Meter is the estimated overall time signature of a track. The time signature (meter) is a notational convention to specify how many beats are in each bar (or measure) of 3/4, 4/4, 5/4, 6/4 and 7/4
        /// </summary>
        public string MeterString =>
            Helpers.GetAudioMeter(TimeSignature);

        /// <summary>
        /// The confidence percentage, from 0% to 100%, of the reliability of the Time Signature
        /// </summary>
        public int TimeSignatureConfidencePercentage =>
             Helpers.GetAudioPercentage(TimeSignatureConfidence);
        #endregion Extension Properties
    }
}
