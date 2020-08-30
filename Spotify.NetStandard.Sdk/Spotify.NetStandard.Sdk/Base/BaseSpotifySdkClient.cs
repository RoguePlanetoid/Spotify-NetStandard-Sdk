using System;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Base Spotify Sdk Client
    /// </summary>
    public abstract class BaseSpotifySdkClient : BaseNotifyPropertyChanged, IDisposable
    {
        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        public BaseSpotifySdkClient(
            ISpotifySdkClient client) =>
            Client = client;
        #endregion Constructor

        #region Protected Methods
        /// <summary>
        /// Spotify Sdk Client
        /// </summary>
        public ISpotifySdkClient Client { get; protected set; }
        #endregion Protected Methods

        #region Public Methods
        /// <summary>Dispose</summary>
        public void Dispose() =>
            Client = null;
        #endregion Public Methods
    }
}
