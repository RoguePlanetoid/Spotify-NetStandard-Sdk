using Spotify.NetStandard.Sdk.Internal;
using System.Collections.Generic;
using System.Windows.Input;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Playlist Image Response
    /// </summary>
    public class PlaylistImageResponse : IAssetResponse
    {
        #region Response Properties
        /// <summary>
        /// Images in various sizes, if available
        /// </summary>
        public List<ImageResponse> Images { get; set; }
        #endregion Response Properties

        #region Extended Properties
        /// <summary>
        /// Playlist Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Large Image
        /// </summary>
        public ImageResponse Large => Images.GetLargeImage();

        /// <summary>
        /// Medium Image
        /// </summary>
        public ImageResponse Medium => Images.GetMediumImage();

        /// <summary>
        /// Small Image
        /// </summary>
        public ImageResponse Small => Images.GetSmallImage();

        /// <summary>
        /// Command
        /// </summary>
        public ICommand Command { get; set; }
        #endregion Extended Properties
    }
}
