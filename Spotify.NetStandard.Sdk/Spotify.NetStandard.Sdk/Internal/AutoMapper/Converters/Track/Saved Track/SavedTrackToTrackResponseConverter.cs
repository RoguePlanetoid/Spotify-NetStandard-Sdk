using AutoMapper;
using Spotify.NetStandard.Responses;

namespace Spotify.NetStandard.Sdk.AutoMapper
{
    /// <summary>
    /// Saved Track to Track Response Converter
    /// </summary>
    internal class SavedTrackToTrackResponseConverter : 
        ITypeConverter<SavedTrack, TrackResponse>
    {
        public TrackResponse Convert(SavedTrack source, TrackResponse destination, ResolutionContext context)
        {
            if (source != null)
            {
                var response = context.Mapper.Map<TrackResponse>(source.Track);
                response.AddedAt = source.AddedAt;
                return response;
            }
            return null;
        }
    }
}
