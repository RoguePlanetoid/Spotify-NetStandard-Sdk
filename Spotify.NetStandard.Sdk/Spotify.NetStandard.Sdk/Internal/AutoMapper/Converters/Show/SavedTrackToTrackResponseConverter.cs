using AutoMapper;
using Spotify.NetStandard.Responses;

namespace Spotify.NetStandard.Sdk.AutoMapper
{
    /// <summary>
    /// Saved Show to Show Response Converter
    /// </summary>
    internal class SavedShowToShowResponseConverter : 
        ITypeConverter<SavedShow, ShowResponse>
    {
        public ShowResponse Convert(SavedShow source, ShowResponse destination, ResolutionContext context)
        {
            if (source != null)
            {
                var response = context.Mapper.Map<ShowResponse>(source.Show);
                response.AddedAt = source.AddedAt;
                return response;
            }
            return null;
        }
    }
}
