using System;
using System.Collections.Generic;
using System.Linq;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Response Removed Arguments
    /// </summary>
    /// <typeparam name="TResponse">Response Type</typeparam>
    public class ResponseRemovedArgs<TResponse> : EventArgs
    {
        #region Public Properties
        /// <summary>
        /// Index
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// List of Response Item
        /// </summary>
        public List<TResponse> Items { get; set; }

        /// <summary>
        /// Item
        /// </summary>
        public TResponse Item => Items.FirstOrDefault();
        #endregion Public Properties
    }
}