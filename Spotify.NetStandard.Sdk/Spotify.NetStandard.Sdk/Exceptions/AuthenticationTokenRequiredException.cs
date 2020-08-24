namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Authentication Token Required Exception
    /// </summary>
    public class AuthenticationTokenRequiredException : BaseAuthenticationException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tokenType">Token Type</param>
        public AuthenticationTokenRequiredException(AuthenticationTokenType tokenType) =>
            TokenType = tokenType;

        /// <summary>
        /// Token Type
        /// </summary>
        public AuthenticationTokenType TokenType { get; }
    }
}
