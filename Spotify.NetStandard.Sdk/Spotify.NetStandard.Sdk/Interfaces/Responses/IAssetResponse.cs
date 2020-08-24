using System.Collections.Generic;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Asset Response
    /// </summary>
    public interface IAssetResponse
    {
        /// <summary>
        /// Images in various sizes, if available
        /// </summary>
        List<ImageResponse> Images { get; }

        /// <summary>
        /// Large Image
        /// </summary>
        ImageResponse Large { get; }

        /// <summary>
        /// Medium Image
        /// </summary>
        ImageResponse Medium { get; }

        /// <summary>
        /// Small Image
        /// </summary>
        ImageResponse Small { get; }
    }
}
