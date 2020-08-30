namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Playback Response
    /// </summary>
    public interface IPlaybackResponse : IResponse
    {
        /// <summary>
        /// Playback Start Type
        /// </summary>
        PlaybackStartType PlaybackStartType { get; }
    }
}
