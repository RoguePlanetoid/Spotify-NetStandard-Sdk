using AutoMapper;
using Spotify.NetStandard.Responses;

namespace Spotify.NetStandard.Sdk.AutoMapper
{
    /// <summary>
    /// Track Response to Saved Track Converter
    /// </summary>
    internal class TrackResponseToSavedTrackConverter :
        ITypeConverter<TrackResponse, SavedTrack>
    {
        public SavedTrack Convert(TrackResponse source, SavedTrack destination, ResolutionContext context)
        {
            if (source != null)
            {
                var savedAlbum = new SavedTrack()
                {
                    AddedAt = source.AddedAt,
                    Track = context.Mapper.Map<Track>(source),
                    Error = context.Mapper.Map<Responses.ErrorResponse>(source.Error)
                };
                return savedAlbum;
            }
            return null;
        }
    }
}
