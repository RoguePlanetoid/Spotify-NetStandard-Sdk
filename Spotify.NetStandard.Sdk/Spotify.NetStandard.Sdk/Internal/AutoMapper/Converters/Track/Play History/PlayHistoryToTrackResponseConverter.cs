using AutoMapper;
using Spotify.NetStandard.Responses;

namespace Spotify.NetStandard.Sdk.AutoMapper
{
    /// <summary>
    /// Play History to Track Response Converter
    /// </summary>
    internal class PlayHistoryToTrackResponseConverter : 
        ITypeConverter<PlayHistory, TrackResponse>
    {
        public TrackResponse Convert(PlayHistory source, TrackResponse destination, ResolutionContext context)
        {
            if (source != null)
            {
                var response = context.Mapper.Map<TrackResponse>(source.Track);
                response.PlayedAt = source.PlayedAt;
                response.Context = context.Mapper.Map<ContextResponse>(source.Context);
                return response;
            }
            return null;
        }
    }
}
