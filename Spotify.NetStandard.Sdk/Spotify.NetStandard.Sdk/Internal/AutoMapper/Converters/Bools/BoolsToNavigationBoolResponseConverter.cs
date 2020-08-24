using AutoMapper;
using Spotify.NetStandard.Responses;
using System.Collections.Generic;

namespace Spotify.NetStandard.Sdk.AutoMapper
{
    /// <summary>
    /// Bools to Navigation Bool Response Converter
    /// </summary>
    internal class BoolsToNavigationBoolResponseConverter : 
        ITypeConverter<Bools, NavigationResponse<bool>>
    {
        public NavigationResponse<bool> Convert(Bools source, NavigationResponse<bool> destination, ResolutionContext context)
        {
            if (source != null)
            {
                var items = context.Mapper.Map<List<bool>>(source);
                var response = new NavigationResponse<bool>
                {
                    Items = items,
                    Total = items?.Count ?? 0,
                    Error = context.Mapper.Map<ErrorResponse>(source.Error)
                };
                return response;
            }
            return null;
        }
    }
}
