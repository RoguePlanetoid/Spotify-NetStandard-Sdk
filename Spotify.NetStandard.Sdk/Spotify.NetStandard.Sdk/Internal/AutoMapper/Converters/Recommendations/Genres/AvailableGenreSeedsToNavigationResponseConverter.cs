using AutoMapper;
using Spotify.NetStandard.Responses;
using System.Collections.Generic;

namespace Spotify.NetStandard.Sdk.AutoMapper
{
    /// <summary>
    /// Available Genre Seeds to Navigation Response Converter
    /// </summary>
    internal class AvailableGenreSeedsToNavigationResponseConverter :
        ITypeConverter<AvailableGenreSeeds, NavigationResponse<RecommendationGenreResponse>>
    {
        public NavigationResponse<RecommendationGenreResponse> Convert(AvailableGenreSeeds source,
                NavigationResponse<RecommendationGenreResponse> destination,
                ResolutionContext context)
        {
            if (source != null)
            {
                var list = source.Genres;
                var itemMapping = context.Mapper.Map<List<RecommendationGenreResponse>>(list);
                var response = new NavigationResponse<RecommendationGenreResponse>
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
