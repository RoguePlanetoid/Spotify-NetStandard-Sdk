using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Spotify.NetStandard.Sdk.AutoMapper
{
    /// <summary>
    /// List to Navigation Response Converter
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TDestination"></typeparam>
    internal class ListToNavigationResponseConverter<TSource, TDestination> : 
        ITypeConverter<List<TSource>, NavigationResponse<TDestination>>
    {
        public NavigationResponse<TDestination> Convert(List<TSource> source, 
            NavigationResponse<TDestination> destination, 
            ResolutionContext context)
        {
            if (source != null)
            {
                var itemMapping = context.Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);
                var response = new NavigationResponse<TDestination>
                {
                    Items = itemMapping.ToList(),
                    Total = source?.Count() ?? 0
                };
                return response;
            }
            return null;
        }
    }
}
