using System;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Authentication Access Token Not Found Exception
    /// </summary>
    public class AuthenticationAccessTokenNotFoundException : BaseAuthenticationException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="ex">Inner Exception</param>
        public AuthenticationAccessTokenNotFoundException(string message, Exception ex) 
            : base(message, ex) { }
    }
}
