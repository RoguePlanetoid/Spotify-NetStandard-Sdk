using AutoMapper;
using Spotify.NetStandard.Responses;
using System.Collections.Generic;
using System.Linq;

namespace Spotify.NetStandard.Sdk.AutoMapper
{
    /// <summary>
    /// Cursor Paging to Navigation Response Converter
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TDestination"></typeparam>
    internal class NavigationResponseToCursorPagingConverter<TSource, TDestination> : 
        ITypeConverter<NavigationResponse<TSource>, CursorPaging<TDestination>>
    {
        public CursorPaging<TDestination> Convert(NavigationResponse<TSource> source,
            CursorPaging<TDestination> destination, 
            ResolutionContext context)
        {
            if (source != null)
            {
                var list = source.Items.ToList();
                var itemMapping = context.Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(list);
                var response = new CursorPaging<TDestination>
                {
                    Href = source.Href,
                    Before = source.Back,
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
