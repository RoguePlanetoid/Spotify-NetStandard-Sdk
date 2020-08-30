using AutoMapper;
using Spotify.NetStandard.Responses;

namespace Spotify.NetStandard.Sdk.AutoMapper
{
    /// <summary>
    /// Album Response to Saved Album Converter
    /// </summary>
    internal class AlbumResponseToSavedAlbumConverter :
        ITypeConverter<AlbumResponse, SavedAlbum>
    {
        public SavedAlbum Convert(AlbumResponse source, SavedAlbum destination, ResolutionContext context)
        {
            if (source != null)
            {
                var savedAlbum = new SavedAlbum()
                {
                    AddedAt = source.AddedAt,
                    Album = context.Mapper.Map<Album>(source),
                    Error = context.Mapper.Map<Responses.ErrorResponse>(source.Error)
                };
                return savedAlbum;
            }
            return null;
        }
    }
}
