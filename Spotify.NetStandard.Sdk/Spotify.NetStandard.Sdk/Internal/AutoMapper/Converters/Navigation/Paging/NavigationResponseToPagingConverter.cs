using AutoMapper;
using Spotify.NetStandard.Responses;
using System.Collections.Generic;
using System.Linq;

namespace Spotify.NetStandard.Sdk.AutoMapper
{
    /// <summary>
    /// Navigation Response to Paging Converter
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TDestination"></typeparam>
    internal class NavigationResponseToPagingConverter<TSource, TDestination> : 
        ITypeConverter<NavigationResponse<TSource>, Paging<TDestination>>
    {
        public Paging<TDestination> Convert(NavigationResponse<TSource> source, 
            Paging<TDestination> destination, 
            ResolutionContext context)
        {
            if (source != null)
            {
                var list = source.Items.ToList();
                var itemMapping = context.Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(list);
                var response = new Paging<TDestination>
                {
                    Href = source.Href,
                    Previous = source.Back,
                    Items = itemMapping.ToList(),
                    Error = context.Mapper.Map<Responses.ErrorResponse>(source.Error),
                    Limit = source.Limit,
                    Next = source.Next,
                    Offset = source.Offset,
                    Total = source.Total
                };
                return response;
            }
            return null;
        }
    }
}
