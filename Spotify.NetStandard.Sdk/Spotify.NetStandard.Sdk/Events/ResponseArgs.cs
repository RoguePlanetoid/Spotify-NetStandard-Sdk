using System;
using System.Collections.Generic;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Response Arguments
    /// </summary>
    public class ResponseArgs<TResponse> : EventArgs
    {
        #region Public Properties
        /// <summary>
        /// Index
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// List of Response Items
        /// </summary>
        public List<TResponse> Items { get; set; }
        #endregion Public Properties
    }
}
