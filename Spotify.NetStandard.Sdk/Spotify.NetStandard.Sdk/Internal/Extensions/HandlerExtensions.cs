namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Handler Extensions
    /// </summary>
    internal static class HandlerExtensions
    {
        /// <summary>
        /// Add User Playback Handler
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Playback Response</param>
        public static async void AddUserPlaybackHandler(
            this ISpotifySdkClient client,
            IPlaybackResponse response) =>
                await client.AddUserPlaybackAsync(
                response.PlaybackStartType,
                response.Id);

        /// <summary>
        /// Add User Playback Queue Handler
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Play Item Response</param>
        public static async void AddUserPlaybackQueueHandler(
            this ISpotifySdkClient client,
            IPlayItemResponse response) =>
            await client.AddUserPlaybackQueueAsync(
                response.PlayItemType,
                response.Id);

        /// <summary>
        /// Transfer User Playback Handler
        /// </summary>
        /// <param name="response">Device Response</param>
        /// <param name="client">Spotify Sdk Client</param>
        public static async void TransferUserPlaybackHandler(
            this ISpotifySdkClient client, 
            DeviceResponse response) =>
            await client.SetUserPlaybackAsync(PlaybackType.Device, response.Id);

        /// <summary>
        /// Skip User’s Playback To Next Track Handler 
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Currently Playing Response</param>
        public static async void UserPlaybackNextHandler(
            this ISpotifySdkClient client,
            CurrentlyPlayingResponse response) =>
            await client.SetUserPlaybackAsync(PlaybackType.Next);

        /// <summary>
        /// Skip User’s Playback To Previous Track Handler
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Currently Playing Response</param>
        public static async void UserPlaybackPreviousHandler(
            this ISpotifySdkClient client,
            CurrentlyPlayingResponse response) =>
            await client.SetUserPlaybackAsync(PlaybackType.Previous);

        /// <summary>
        /// Pause a User's Playback Handler
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Currently Playing Response</param>
        public static async void UserPlaybackPauseHandler(
            this ISpotifySdkClient client,
            CurrentlyPlayingResponse response) =>
            await client.SetUserPlaybackAsync(PlaybackType.Pause);

        /// <summary>
        /// Resume a User's Playback Handler
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Currently Playing Response</param>
        public static async void UserPlaybackResumeHandler(
            this ISpotifySdkClient client,
            CurrentlyPlayingResponse response) =>
            await client.SetUserPlaybackAsync(PlaybackType.Resume);

        /// <summary>
        /// Toggle Shuffle For User’s Playback
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Currently Playing Response</param>
        public static async void UserPlaybackShuffleHandler(
            this ISpotifySdkClient client,
            CurrentlyPlayingResponse response) =>
            await client.SetUserPlaybackAsync(
                response.ShuffleState ?
                PlaybackType.ShuffleOn : 
                PlaybackType.ShuffleOff);

        /// <summary>
        /// Set Repeat Mode On User’s Playback Handler
        /// </summary>        
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Currently Playing Response</param>
        public static async void UserPlaybackRepeatHandler(
            this ISpotifySdkClient client,
            CurrentlyPlayingResponse response)
        {
            // States are Off, Track and Context
            switch (response.RepeatState)
            {
                case "off":
                    // Track is Next State if Allowed
                    if (response?.Actions?.Allows?.IsTogglingRepeatTrackAllowed ?? false)
                        await client.SetUserPlaybackAsync(PlaybackType.RepeatTrack);
                    // Or Context is Next State if Allowed
                    else if (response?.Actions?.Allows?.IsTogglingRepeatContextAllowed ?? false)
                        await client.SetUserPlaybackAsync(PlaybackType.RepeatContext);
                    break;
                case "track":
                    // Context is Next State if Allowed
                    if (response?.Actions?.Allows?.IsTogglingRepeatContextAllowed ?? false)
                        await client.SetUserPlaybackAsync(PlaybackType.RepeatContext);
                    // Or Off is the Next State
                    else
                        await client.SetUserPlaybackAsync(PlaybackType.RepeatOff);
                    break;
                case "context":
                    // Off is the Next State
                    await client.SetUserPlaybackAsync(PlaybackType.RepeatOff);
                    break;
            }
        }

        /// <summary>
        /// Set Repeat Off For User’s Playback
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Currently Playing Response</param>
        public static async void UserPlaybackRepeatOffHandler(
            this ISpotifySdkClient client,
            CurrentlyPlayingResponse response) =>
            await client.SetUserPlaybackAsync(PlaybackType.RepeatOff);

        /// <summary>
        /// Set Repeat Track For User’s Playback
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Currently Playing Response</param>
        public static async void UserPlaybackRepeatTrackHandler(
            this ISpotifySdkClient client,
            CurrentlyPlayingResponse response) =>
            await client.SetUserPlaybackAsync(PlaybackType.RepeatTrack);

        /// <summary>
        /// Set Repeat Context For User’s Playback
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Currently Playing Response</param>
        public static async void UserPlaybackRepeatContextHandler(
            this ISpotifySdkClient client,
            CurrentlyPlayingResponse response) =>
            await client.SetUserPlaybackAsync(PlaybackType.RepeatContext);

        /// <summary>
        /// Set Position for User's Playback
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="value">Seek Position</param>
        public static async void UserPlaybackSeekHandler(
            this ISpotifySdkClient client,
            int value) =>
            await client.SetUserPlaybackAsync(PlaybackType.Seek,
                option: value);

        /// <summary>
        /// Set Volume For User's Playback
        /// </summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="value">Volume Percentage</param>
        public static async void UserPlaybackVolumeHandler(
            this ISpotifySdkClient client,
            int value) =>
            await client.SetUserPlaybackAsync(PlaybackType.Volume,
                option: value);
    }
}
