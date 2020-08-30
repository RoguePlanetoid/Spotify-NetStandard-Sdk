using AutoMapper;
using Spotify.NetStandard.Responses;

namespace Spotify.NetStandard.Sdk.AutoMapper
{
    /// <summary>
    /// Saved Album to Album Response Converter
    /// </summary>
    internal class SavedAlbumToAlbumResponseConverter : 
        ITypeConverter<SavedAlbum, AlbumResponse>
    {
        public AlbumResponse Convert(SavedAlbum source, AlbumResponse destination, ResolutionContext context)
        {
            if (source != null)
            {
                var response = context.Mapper.Map<AlbumResponse>(source.Album);
                response.AddedAt = source.AddedAt;
                return response;
            }
            return null;
        }
    }
}
