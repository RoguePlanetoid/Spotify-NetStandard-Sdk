using Spotify.NetStandard.Sdk.Internal;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Audio Features Response
    /// </summary>
    public class AudioFeaturesResponse : BaseContentResponse
    {
        #region Response Properties
        /// <summary>
        /// A confidence measure from 0.0 to 1.0 of whether the track is acoustic
        /// </summary>
        public float? Acousticness { get; set; }

        /// <summary>
        /// An HTTP URL to access the full audio analysis of this track
        /// </summary>
        public string AnalysisUrl { get; set; }

        /// <summary>
        /// Danceability describes how suitable a track is for dancing based on a combination of musical elements including tempo, rhythm stability, beat strength, and overall regularity. A value of 0.0 is least danceable and 1.0 is most danceable
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
        /// Predicts whether a track contains no vocals. “Ooh” and “aah” sounds are treated as instrumental in this context. Rap or spoken word tracks are clearly “vocal”. The closer the instrumentalness value is to 1.0, the greater likelihood the track contains no vocal content. Values above 0.5 are intended to represent instrumental tracks, but confidence is higher as the value approaches 1.0
        /// </summary>
        public float? Instrumentalness { get; set; }

        /// <summary>
        /// The key the track is in. Integers map to pitches using standard Pitch Class notation.
        /// </summary>
        public int? Key { get; set; }

        /// <summary>
        /// Detects the presence of an audience in the recording. Higher liveness values represent an increased probability that the track was performed live. A value above 0.8 provides strong likelihood that the track is live
        /// </summary>
        public float? Liveness { get; set; }

        /// <summary>
        /// The overall loudness of a track in decibels (dB). Loudness values are averaged across the entire track and are useful for comparing relative loudness of tracks. Loudness is the quality of a sound that is the primary psychological correlate of physical strength (amplitude). Values typical range between -60 and 0 db
        /// </summary>
        public float? Loudness { get; set; }

        /// <summary>
        /// Mode indicates the modality(major or minor) of a track, the type of scale from which its melodic content is derived. Major is represented by 1 and minor is 0
        /// </summary>
        public int? Mode { get; set; }

        /// <summary>
        /// Speechiness detects the presence of spoken words in a track. The more exclusively speech-like the recording (e.g. talk show, audio book, poetry), the closer to 1.0 the attribute value. Values above 0.66 describe tracks that are probably made entirely of spoken words. Values between 0.33 and 0.66 describe tracks that may contain both music and speech, either in sections or layered, including such cases as rap music. Values below 0.33 most likely represent music and other non-speech-like tracks
        /// </summary>
        public float? Speechiness { get; set; }

        /// <summary>
        /// The overall estimated tempo of a track in beats per minute (BPM). In musical terminology, tempo is the speed or pace of a given piece and derives directly from the average beat duration 
        /// </summary>
        public float? Tempo { get; set; }

        /// <summary>
        /// An estimated overall time signature of a track. The time signature (meter) is a notational convention to specify how many beats are in each bar (or measure)
        /// </summary>
        public int? TimeSignature { get; set; }

        /// <summary>
        /// A link to the Web API endpoint providing full details of the track
        /// </summary>
        public string TrackHref { get; set; }

        /// <summary>
        /// A measure from 0.0 to 1.0 describing the musical positiveness conveyed by a track. Tracks with high valence sound more positive (e.g. happy, cheerful, euphoric), while tracks with low valence sound more negative (e.g. sad, depressed, angry)
        /// </summary>
        public float? Valence { get; set; }
        #endregion Response Properties

        #region Extension Properties
        /// <summary>
        /// A confidence percentage from 0% to 100% of whether the track is acoustic
        /// </summary>
        public int AcousticPercentage => 
            Helpers.GetAudioPercentage(Acousticness);

        /// <summary>
        /// Danceability percentage described how suitable a track is for dancing based on a combination of musical elements including tempo, rhythm stability, beat strength, and overall regularity. A value of 0 is least danceable and 100% is most danceable
        /// </summary>
        public int DanceablePercentage => 
            Helpers.GetAudioPercentage(Danceability);

        /// <summary>
        /// Energy percentage from 0% to 100% represents a perceptual measure of intensity and activity
        /// </summary>
        public int EnergyPercentage => 
            Helpers.GetAudioPercentage(Energy);

        /// <summary>
        /// Instrumental precentage predicts whether a track contains no vocals. “Ooh” and “aah” sounds are treated as instrumental in this context. Rap or spoken word tracks are clearly “vocal”. The closer the instrumentalness value is to 100%, the greater likelihood the track contains no vocal content. Values above 50% are intended to represent instrumental tracks, but confidence is higher as the value approaches 100%
        /// </summary>
        public int InstrumentalPercentage => 
            Helpers.GetAudioPercentage(Instrumentalness);

        /// <summary>
        /// The key the track is in using standard Pitch Class notation of C, C♯, D, D♯, E, F, F♯, G, G♯, A, A♯ or B
        /// </summary>
        public string KeyString => 
            Helpers.GetAudioKey(Key);

        /// <summary>
        /// Live precentage detects the presence of an audience in the recording. Higher liveness percentage represent an increased probability that the track was performed live. A value above 80% provides strong likelihood that the track is live
        /// </summary>
        public int LivePercentage => 
            Helpers.GetAudioPercentage(Liveness);

        /// <summary>
        /// Speechiness percentage detects the presence of spoken words in a track. The more exclusively speech-like the recording (e.g. talk show, audio book, poetry), the closer to 100% the attribute value. Values above 60% percent describe tracks that are probably made entirely of spoken words. Values between 33% and 66% describe tracks that may contain both music and speech, either in sections or layered, including such cases as rap music. Values below 33% most likely represent music and other non-speech-like tracks
        /// </summary>
        public int SpeechPercentage => 
            Helpers.GetAudioPercentage(Speechiness);

        /// <summary>
        /// Valence percentage from 0% to 100% describing the musical positiveness conveyed by a track. Tracks with high valence sound more positive (e.g. happy, cheerful, euphoric), while tracks with low valence sound more negative (e.g. sad, depressed, angry)
        /// </summary>
        public int ValencePercentage => 
            Helpers.GetAudioPercentage(Valence);

        /// <summary>
        /// The overall rounded loudness of a track in decibels (dB). Loudness values are averaged across the entire track and are useful for comparing relative loudness of tracks. Loudness is the quality of a sound that is the primary psychological correlate of physical strength (amplitude). Values typical range between -60 and 0 db
        /// </summary>
        public int LoudnessValue =>
            Helpers.GetAudioValue(Loudness);

        /// <summary>
        /// The overall estimated rounded tempo of a track in beats per minute (BPM). In musical terminology, tempo is the speed or pace of a given piece and derives directly from the average beat duration
        /// </summary>
        public int TempoValue =>
            Helpers.GetAudioValue(Tempo);

        /// <summary>
        /// Mode indicates the modality of a track, the type of scale from which its melodic content is derived of which can be Major, Minor or none
        /// </summary>
        public string ModeString => 
            Helpers.GetAudioMode(Mode);

        /// <summary>
        /// Meter is the estimated overall time signature of a track. The time signature (meter) is a notational convention to specify how many beats are in each bar (or measure) of 3/4, 4/4, 5/4, 6/4 and 7/4
        /// </summary>
        public string MeterString => 
            Helpers.GetAudioMeter(TimeSignature);
        #endregion Extension Properties
    }
}
