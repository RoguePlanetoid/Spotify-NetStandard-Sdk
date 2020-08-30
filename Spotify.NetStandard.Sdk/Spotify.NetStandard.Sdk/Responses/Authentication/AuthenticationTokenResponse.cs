using System;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Authentication Token Response
    /// </summary>
    public class AuthenticationTokenResponse
    {
        /// <summary>
        /// Access Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Refresh
        /// </summary>
        public string Refresh { get; set; }

        /// <summary>
        /// Token Expiration Date
        /// </summary>
        public DateTime Expiration { get; set; }

        /// <summary>
        /// Authentication Token Type
        /// </summary>
        public AuthenticationTokenType AuthenticationTokenType { get; set; }

        /// <summary>
        /// Scopes
        /// </summary>
        public string Scopes { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Is Valid
        /// </summary>
        public bool IsValid => 
            !string.IsNullOrEmpty(Token) && DateTime.UtcNow < Expiration;

        /// <summary>
        /// Is Logged In
        /// </summary>
        public bool IsLoggedIn => 
            IsValid && AuthenticationTokenType == AuthenticationTokenType.User;
    }
}
