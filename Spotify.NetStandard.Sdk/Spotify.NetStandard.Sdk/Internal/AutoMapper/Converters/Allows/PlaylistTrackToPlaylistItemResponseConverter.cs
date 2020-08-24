using AutoMapper;
using Spotify.NetStandard.Responses;

namespace Spotify.NetStandard.Sdk.AutoMapper
{
    /// <summary>
    /// Disallows to Allows Response Converter
    /// </summary>
    internal class DisallowsToAllowsResponseConverter :
        ITypeConverter<Disallows, AllowsResponse>
    {
        #region Public Methods
        public AllowsResponse Convert(Disallows source, AllowsResponse destination, ResolutionContext context)
        {
            if (source != null)
            {
                var response = new AllowsResponse
                {
                    IsInterruptingPlaybackAllowed = !source.IsInterruptingPlaybackNotAllowed,
                    IsPausingAllowed = !source.IsPausingNotAllowed,
                    IsResumingAllowed = !source.IsResumingNotAllowed,
                    IsSeekingAllowed = !source.IsSeekingNotAllowed,
                    IsSkippingNextAllowed = !source.IsSkippingNextNotAllowed,
                    IsSkippingPrevAllowed = !source.IsSkippingPrevNotAllowed,
                    IsTogglingRepeatContextAllowed = !source.IsTogglingRepeatContextNotAllowed,
                    IsTogglingRepeatTrackAllowed = !source.IsTogglingRepeatContextNotAllowed,
                    IsTogglingShuffleAllowed = !source.IsTogglingShuffleNotAllowed,
                    IsTransferringPlaybackAllowed = !source.IsTransferringPlaybackNotAllowed
                };
                return response;
            }
            return null;
        }
        #endregion Public Methods
    }
}
