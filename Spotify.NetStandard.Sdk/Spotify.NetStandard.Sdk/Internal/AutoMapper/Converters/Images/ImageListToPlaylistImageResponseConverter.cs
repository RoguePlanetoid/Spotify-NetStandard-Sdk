using AutoMapper;
using Spotify.NetStandard.Responses;
using System.Collections.Generic;

namespace Spotify.NetStandard.Sdk.AutoMapper
{
    /// <summary>
    /// Image List to Playlist Image Response Converter
    /// </summary>
    internal class ImageListToPlaylistImageResponseConverter :
        ITypeConverter<List<Image>, PlaylistImageResponse>
    {
        public PlaylistImageResponse Convert(List<Image> source, PlaylistImageResponse destination, ResolutionContext context)
        {
            if(source != null)
            {
                var assetResponse = new PlaylistImageResponse()
                {
                    Images = context.Mapper.Map<List<ImageResponse>>(source)
                };
                return assetResponse;
            }
            return null;
        }
    }
}
