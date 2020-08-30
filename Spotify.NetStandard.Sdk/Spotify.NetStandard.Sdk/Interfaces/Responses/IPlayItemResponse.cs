using System.Windows.Input;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Play Item Response
    /// </summary>
    public interface IPlayItemResponse : IPlaybackResponse, IAssetResponse, IContentResponse
    {
        /// <summary>
        /// Play Item Type
        /// </summary>
        PlayItemType PlayItemType { get; }

        /// <summary>
        /// The item length in milliseconds.
        /// </summary>
        long Duration { get; set; }

        /// <summary>
        /// A link to a 30 second preview (MP3 format) of the item.
        /// </summary>
        string Preview { get; set; }

        /// <summary>
        /// Whether or not the item is explicit ( true = yes it does; false = no it does not OR unknown).
        /// </summary>
        bool IsExplicit { get; set; }

        /// <summary>
        /// If true , the item is playable in the given market. Otherwise false.
        /// </summary>
        bool IsPlayable { get; set; }

        /// <summary>
        /// Item Length
        /// </summary>
        string Length { get; }

        /// <summary>
        /// Start/Resume a User's Playback
        /// </summary>
        ICommand AddUserPlaybackCommand { get; set; }

        /// <summary>
        /// Add an item to the end of the user's current playback queue
        /// </summary>
        ICommand AddUserPlaybackQueueCommand { get; set; }

        /// <summary>
        /// Add Item to a Playlist
        /// </summary>
        ICommand AddPlaylistItemCommand { get; set; }

        /// <summary>
        /// Toggle Favourite Episode
        /// </summary>
        Toggle ToggleFavourite { get; set; }
    }
}
