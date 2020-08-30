using AutoMapper;
using Spotify.NetStandard.Responses;

namespace Spotify.NetStandard.Sdk.AutoMapper
{
    /// <summary>
    /// Show Response to Saved Show Converter
    /// </summary>
    internal class ShowResponseToSavedShowConverter :
        ITypeConverter<ShowResponse, SavedShow>
    {
        public SavedShow Convert(ShowResponse source, SavedShow destination, ResolutionContext context)
        {
            if (source != null)
            {
                var savedShow = new SavedShow()
                {
                    AddedAt = source.AddedAt,
                    Show = context.Mapper.Map<SimplifiedShow>(source),
                    Error = context.Mapper.Map<Responses.ErrorResponse>(source.Error)
                };
                return savedShow;
            }
            return null;
        }
    }
}
