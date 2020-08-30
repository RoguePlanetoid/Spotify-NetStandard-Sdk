using Spotify.NetStandard.Sdk.Internal;
using System.Collections.Generic;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Category Response
    /// </summary>
    public class CategoryResponse : BaseContentResponse, IResponse
    {
        #region Response Properties
        /// <summary>
        /// The category icon, in various sizes
        /// </summary>
        public List<ImageResponse> Images { get; set; }
        #endregion Response Properties

        #region Extended Properties
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
        #endregion Extended Properties
    }
}
