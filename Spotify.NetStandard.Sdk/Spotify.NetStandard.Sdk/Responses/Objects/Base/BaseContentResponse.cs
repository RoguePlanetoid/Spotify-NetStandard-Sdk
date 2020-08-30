using System.Windows.Input;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Base Content Response
    /// </summary>
    public abstract class BaseContentResponse : ContextResponse
    {
        /// <summary>
        /// The base-62 identifier that you can find at the end of the Spotify URI for the object
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the content
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Command
        /// </summary>
        public ICommand Command { get; set; }
    }
}
