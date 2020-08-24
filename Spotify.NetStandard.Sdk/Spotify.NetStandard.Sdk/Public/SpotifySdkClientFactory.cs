using Spotify.NetStandard.Sdk.Internal;
using System;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Spotify Sdk Client Factory
    /// </summary>
    public class SpotifySdkClientFactory
    {
        /// <summary>
        /// Create Spotify SDK Client
        /// </summary>
        /// <param name="clientId">(Required) Spotify Client Id</param>
        /// <param name="clientSecret">(Optional) Spotify Client Secret</param>
        /// <param name="authorisationRedirectUri">(Optional) Authorisation Redirect Uri</param>
        /// <param name="authorisationState">(Optional) Authorisation State</param>
        /// <returns>Spotify SDK Client</returns>
        public static ISpotifySdkClient CreateSpotifySdkClient(
            string clientId,
            string clientSecret = null,
            Uri authorisationRedirectUri = null,
            string authorisationState = null) =>
            new SpotifySdkClient(clientId, clientSecret,
                authorisationRedirectUri, authorisationState);
    }
}
