using AutoMapper;
using Spotify.NetStandard.Responses;

namespace Spotify.NetStandard.Sdk.AutoMapper
{
    /// <summary>
    /// Track Response to Play History Converter
    /// </summary>
    internal class TrackResponseToPlayHistoryConverter :
        ITypeConverter<TrackResponse, PlayHistory>
    {
        public PlayHistory Convert(TrackResponse source, PlayHistory destination, ResolutionContext context)
        {
            if (source != null)
            {
                var playHistory = new PlayHistory()
                {
                    PlayedAt = source.PlayedAt,
                    Context = context.Mapper.Map<Context>(source),
                    Track = context.Mapper.Map<Track>(source),
                    Error = context.Mapper.Map<Responses.ErrorResponse>(source.Error)
                };
                return playHistory;
            }
            return null;
        }
    }
}
