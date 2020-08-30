using System;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Base Authentication Exception
    /// </summary>
    public abstract class BaseAuthenticationException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BaseAuthenticationException() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="ex">Inner Exception</param>
        public BaseAuthenticationException(string message, Exception ex) 
            : base(message, ex) { }
    }
}
