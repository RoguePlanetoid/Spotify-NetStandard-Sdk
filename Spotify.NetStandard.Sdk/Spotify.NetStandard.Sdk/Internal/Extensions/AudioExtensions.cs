using System.Linq;
using System.Threading.Tasks;

namespace Spotify.NetStandard.Sdk.Internal
{
    /// <summary>
    /// Audio Extensions
    /// </summary>
    public static class AudioExtensions
    {
        /// <summary>
        /// Attach Audio Analysis
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Track Response</param>
        public async static Task AttachGetTrackAudioAnalysis(
            this ISpotifySdkClient client,
            TrackResponse response)
        {
            if (client.Config.IsAttachGetTrackAudioAnalysis && response != null)
            {
                // Get Audio Analysis for a Track
                response.AudioAnalysis =
                    await client.GetTrackAudioAnalysisAsync(response.Id);
            }
        }

        /// <summary>
        /// Attach Audio Features
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Track Response</param>
        public async static Task AttachGetTrackAudioFeatures(
            this ISpotifySdkClient client,
            TrackResponse response)
        {
            if (client.Config.IsAttachGetTrackAudioFeatures && response != null)
            {
                // Get Audio Features for a Track
                response.AudioFeatures =
                    await client.GetTrackAudioFeaturesAsync(response.Id);
            }
        }

        /// <summary>
        /// Attach List Tracks Audio Features
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Navigation Response of Track Response</param>
        public async static Task AttachListTracksAudioFeatures(
            this ISpotifySdkClient client,
            NavigationResponse<TrackResponse> response)
        {
            if (client.Config.IsAttachListTracksAudioFeatures && response?.Items != null)
            {
                // Get Audio Features for Several Tracks
                var features = await client.ListAudioFeaturesAsync(new AudioFeaturesRequest()
                {
                    MultipleTrackIds = response.Items.Select(s => s.Id).ToList()
                });
                if (features != null)
                {
                    for (int i = 0; i < response.Items.Count(); i++)
                    {
                        response.Items[i].AudioFeatures = features.Items[i];
                    }
                }
            }
        }
    }
}
