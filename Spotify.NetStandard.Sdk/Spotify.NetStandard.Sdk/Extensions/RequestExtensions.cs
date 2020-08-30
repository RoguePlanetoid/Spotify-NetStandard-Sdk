namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Request Extension Methods
    /// </summary>
    public static class RequestExtensions
    {
        /// <summary>
        /// All
        /// </summary>
        /// <param name="searchTypeRequest">SearchTypeRequest</param>
        /// <returns>SearchTypeRequest</returns>
        public static SearchTypeRequest All(this SearchTypeRequest searchTypeRequest)
        {
            searchTypeRequest.Album = true;
            searchTypeRequest.Artist = true;
            searchTypeRequest.Episode = true;
            searchTypeRequest.Playlist = true;
            searchTypeRequest.Show = true;
            searchTypeRequest.Track = true;
            return searchTypeRequest;
        }
    }
}
