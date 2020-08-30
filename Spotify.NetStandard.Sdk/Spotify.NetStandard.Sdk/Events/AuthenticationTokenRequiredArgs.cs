using System;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Token Required Arguments
    /// </summary>
    public class AuthenticationTokenRequiredArgs : EventArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tokenType">Token Type</param>
        public AuthenticationTokenRequiredArgs(AuthenticationTokenType tokenType) =>
            TokenType = tokenType;

        /// <summary>
        /// Token Type
        /// </summary>
        public AuthenticationTokenType TokenType { get; set; }
    }
}
