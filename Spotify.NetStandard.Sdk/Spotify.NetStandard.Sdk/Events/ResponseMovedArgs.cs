using System;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Response Moved Arguments
    /// </summary>
    public class ResponseMovedArgs : EventArgs
    {
        #region Public Properties
        /// <summary>
        /// Source Index
        /// </summary>
        public int SourceIndex { get; set; }

        /// <summary>
        /// Target Index
        /// </summary>
        public int TargetIndex { get; set; }

        /// <summary>
        /// Total Items
        /// </summary>
        public int? Total { get; set; }
        #endregion Public Properties
    }
}
