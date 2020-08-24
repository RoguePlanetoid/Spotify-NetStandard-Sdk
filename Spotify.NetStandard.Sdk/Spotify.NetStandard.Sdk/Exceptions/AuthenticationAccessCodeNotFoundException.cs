using System;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Authentication Access Code Not Found Exception
    /// </summary>
    public class AuthenticationAccessCodeNotFoundException : BaseAuthenticationException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="ex">Inner Exception</param>
        public AuthenticationAccessCodeNotFoundException(string message, Exception ex) 
            : base(message, ex) { }
    }
}
