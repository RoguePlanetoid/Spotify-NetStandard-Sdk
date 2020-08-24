using System;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Authentication State Not Matched Exception
    /// </summary>
    public class AuthenticationStateNotMatchedException : BaseAuthenticationException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="ex">Inner Exception</param>
        public AuthenticationStateNotMatchedException(string message, Exception ex) 
            : base(message, ex) { }
    }
}
