using System.Windows.Input;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Playlist Item Response
    /// </summary>
    public interface IPlaylistItemResponse
    {
        /// <summary>
        /// Play Item Type of Track or Episode
        /// </summary>
        PlayItemType PlayItemType { get; }

        /// <summary>
        /// Current Track or Episode
        /// </summary>
        IPlayItemResponse Current { get; }

        /// <summary>
        /// Remove Items from a Playlist
        /// </summary>
        ICommand RemovePlaylistItemCommand { get; set; }
    }
}
