using System.Collections.Generic;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Albums Request
    /// </summary>
    public class AlbumsRequest : BaseRequest
    {
        /// <summary>
        /// Album Type
        /// </summary>
        public AlbumType AlbumType { get; set; }
        /// <summary>
        /// (Required) Only for AlbumType.Search - Album Search Term and AlbumType.Artist - Artist Id
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// (Required) Only for AlbumType.Multiple - Multiple Spotify Album Ids
        /// </summary>
        public List<string> MultipleAlbumIds { get; set; }

        /// <summary>
        /// (Optional) Only for AlbumType.Search - If true the response will include any relevant audio content that is hosted externally
        /// </summary>
        public bool? SearchIsExternal { get; set; }

        /// <summary>
        /// (Optional) Only used for AlbumType.Artist - Filters the response. If not supplied, all album types will be returned
        /// </summary>
        public IncludeGroupRequest IncludeGroup { get; set; }

        /// <summary>
        /// (Optional) Only for AlbumType.Search, AlbumType.NewReleases, AlbumType.Artist and AlbumType.UserSaved - Overrides Client Country as ISO 3166-1 alpha-2 country code e.g. GB
        /// </summary>
        public string Country { get; set; }
    }
}