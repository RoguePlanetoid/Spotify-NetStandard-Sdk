using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Spotify.NetStandard.Sdk.AutoMapper
{
    /// <summary>
    /// Navigation Response To Paging Converter
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TDestination"></typeparam>
    internal class NavigationResponseToListConverter<TSource, TDestination> : 
        ITypeConverter<NavigationResponse<TSource>, List<TDestination>>
    {
        public List<TDestination> Convert(NavigationResponse<TSource> source, 
            List<TDestination> destination, 
            ResolutionContext context)
        {
            if (source != null)
            {
                var response = context.Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source.Items);
                return response.ToList();
            }
            return null;
        }
    }
}
