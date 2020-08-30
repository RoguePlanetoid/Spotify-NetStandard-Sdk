namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Allows Response
    /// </summary>
    public class AllowsResponse
    {
        #region Response Properties
        /// <summary>
        /// Interrupting playback allowed?
        /// </summary>
        public bool IsInterruptingPlaybackAllowed { get; set; }

        /// <summary>
        /// Pausing allowed?
        /// </summary>
        public bool IsPausingAllowed { get; set; }

        /// <summary>
        /// Resuming allowed?
        /// </summary>
        public bool IsResumingAllowed { get; set; }

        /// <summary>
        /// Seeking allowed? Will be set to false while playing an ad track
        /// </summary>
        public bool IsSeekingAllowed { get; set; }

        /// <summary>
        /// Skipping next allowed? Will be set to false while playing an ad track
        /// </summary>
        public bool IsSkippingNextAllowed { get; set; }

        /// <summary>
        /// Skipping previous allowed? Will be set to false while playing an ad track
        /// </summary>
        public bool IsSkippingPrevAllowed { get; set; }

        /// <summary>
        /// Toggling repeat context allowed?
        /// </summary>
        public bool IsTogglingRepeatContextAllowed { get; set; }

        /// <summary>
        /// Toggling shuffle allowed?
        /// </summary>
        public bool IsTogglingShuffleAllowed { get; set; }

        /// <summary>
        /// Toggling repeat track allowed?
        /// </summary>
        public bool IsTogglingRepeatTrackAllowed { get; set; }

        /// <summary>
        /// Transferring playback allowed?
        /// </summary>
        public bool IsTransferringPlaybackAllowed { get; set; }
        #endregion Response Properties

        #region Extended Properties
        /// <summary>
        /// Toggling repeat allowed?
        /// </summary>
        public bool IsTogglingRepeatAllowed => 
            IsTogglingRepeatContextAllowed || IsTogglingRepeatTrackAllowed;
        #endregion Extended Properties
    }
}
