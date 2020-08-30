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
    internal class CursorPagingToNavigationResponseConverter<TSource, TDestination> : 
        ITypeConverter<CursorPaging<TSource>, NavigationResponse<TDestination>>
    {
        public NavigationResponse<TDestination> Convert(CursorPaging<TSource> source, 
            NavigationResponse<TDestination> destination, 
            ResolutionContext context)
        {
            if (source != null)
            {
                var list = source.Items.ToList();
                var itemMapping = context.Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(list);
                var response = new NavigationResponse<TDestination>
                {
                    Href = source.Href,
                    Back = source.Before,
                    Items = itemMapping.ToList(),
                    Error = context.Mapper.Map<ErrorResponse>(source.Error),
                    Limit = source.Limit ?? 0,
                    Next = source.Next,
                    Offset = source.Offset ?? 0,
                    Total = source.Total
                };
                return response;
            }
            return null;
        }
    }
}
