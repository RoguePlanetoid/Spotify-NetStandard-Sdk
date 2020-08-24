using System.Collections.Generic;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Remove Playlist Item Request
    /// </summary>
    public class RemovePlaylistItemRequest : AddPlaylistItemRequest
    {
        /// <summary>
        /// Items to remove from their current positions in the playlist. Zero-indexed, that is the first item in the playlist has the value 0, the second item 1, and so on to a maximum of a 100 items
        /// </summary>
        public List<int> Positions { get; set; }
    }
}
