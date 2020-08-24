using AutoMapper;
using Spotify.NetStandard.Responses;
using System.Collections.Generic;

namespace Spotify.NetStandard.Sdk.AutoMapper
{
    /// <summary>
    /// Devices to Navigation Device Response Converter
    /// </summary>
    internal class DevicesToNavigationDeviceResponseConverter : 
        ITypeConverter<Devices, NavigationResponse<DeviceResponse>>
    {
        public NavigationResponse<DeviceResponse> Convert(Devices source, NavigationResponse<DeviceResponse> destination, ResolutionContext context)
        {
            if (source != null)
            {
                var items = context.Mapper.Map<List<DeviceResponse>>(source.Items);
                var response = new NavigationResponse<DeviceResponse>
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
