using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Favourites
    /// </summary>
    public interface IFavourites
    {
        #region Public Properties
        /// <summary>
        /// Album Spotify Ids
        /// </summary>
        [DataMember(Name = "albums")]
        List<string> AlbumIds { get; set; }

        /// <summary>
        /// Artist Spotify Ids
        /// </summary>
        [DataMember(Name = "artists")]
        List<string> ArtistIds { get; set; }

        /// <summary>
        /// Track Spotify Ids
        /// </summary>
        [DataMember(Name = "tracks")]
        List<string> TrackIds { get; set; }

        /// <summary>
        /// Show Spotify Ids
        /// </summary>
        [DataMember(Name = "shows")]
        List<string> ShowIds { get; set; }

        /// <summary>
        /// Show Spotify Ids
        /// </summary>
        [DataMember(Name = "episodes")]
        List<string> EpisodeIds { get; set; }
        #endregion Public Properties
    }
}