using AutoMapper;
using Spotify.NetStandard.Responses;
using System.Collections.Generic;

namespace Spotify.NetStandard.Sdk.AutoMapper
{
    /// <summary>
    /// Recommendations Response to Navigation Response Converter
    /// </summary>
    internal class RecommendationsResponseToNavigationResponseConverter :
        ITypeConverter<RecommendationsResponse, NavigationResponse<TrackResponse>>
    {
        public NavigationResponse<TrackResponse> Convert(RecommendationsResponse source,
                NavigationResponse<TrackResponse> destination,
                ResolutionContext context)
        {
            if (source != null)
            {
                var itemMapping = context.Mapper.Map<List<TrackResponse>>(source.Tracks);
                itemMapping.ForEach(f => f.Seeds = context.Mapper.Map<List<RecommendationSeedResponse>>(source.Seeds));
                var response = new NavigationResponse<TrackResponse>
                {
                    Items = itemMapping,
                    Total = itemMapping.Count
                };
                return response;
            }
            return null;
        }
    }
}
