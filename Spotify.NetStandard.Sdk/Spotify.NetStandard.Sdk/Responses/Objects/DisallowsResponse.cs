namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Disallows Response
    /// </summary>
    public class DisallowsResponse
    {
        #region Response Properties
        /// <summary>
        /// Interrupting playback not allowed?
        /// </summary>
        public bool IsInterruptingPlaybackNotAllowed { get; set; }

        /// <summary>
        /// Pausing not allowed?
        /// </summary>
        public bool IsPausingNotAllowed { get; set; }

        /// <summary>
        /// Resuming not allowed?
        /// </summary>
        public bool IsResumingNotAllowed { get; set; }

        /// <summary>
        /// Seeking not allowed? Will be set to true while playing an ad track
        /// </summary>
        public bool IsSeekingNotAllowed { get; set; }

        /// <summary>
        /// Skipping next not allowed? Will be set to true while playing an ad track
        /// </summary>
        public bool IsSkippingNextNotAllowed { get; set; }

        /// <summary>
        /// Skipping previous not allowed? Will be set to true while playing an ad track
        /// </summary>
        public bool IsSkippingPrevNotAllowed { get; set; }

        /// <summary>
        /// Toggling repeat context not allowed?
        /// </summary>
        public bool IsTogglingRepeatContextNotAllowed { get; set; }

        /// <summary>
        /// Toggling shuffle not allowed?
        /// </summary>
        public bool IsTogglingShuffleNotAllowed { get; set; }

        /// <summary>
        /// Toggling repeat track not allowed?
        /// </summary>
        public bool IsTogglingRepeatTrackNotAllowed { get; set; }

        /// <summary>
        /// Transferring playback not allowed?
        /// </summary>
        public bool IsTransferringPlaybackNotAllowed { get; set; }
        #endregion Response Properties

        #region Extended Properties
        /// <summary>
        /// Toggling repeat not allowed?
        /// </summary>
        public bool IsTogglingRepeatNotAllowed =>
            IsTogglingRepeatContextNotAllowed || IsTogglingRepeatTrackNotAllowed;
        #endregion Extended Properties
    }
}
