using System.Collections.Generic;
using System.Linq;

namespace Spotify.NetStandard.Sdk.Internal
{
    /// <summary>
    /// Favourites
    /// </summary>
    internal class Favourites : IFavourites
    {
        #region Private Members
        private List<string> _albumIds;
        private List<string> _artistIds;
        private List<string> _trackIds;
        private List<string> _showIds;
        private List<string> _episodeIds;
        #endregion Private Members

        #region Public Properties
        /// <summary>
        /// Album Spotify Ids
        /// </summary>
        public List<string> AlbumIds { get => _albumIds; set => _albumIds = value; }

        /// <summary>
        /// Artist Spotify Ids
        /// </summary>
        public List<string> ArtistIds { get => _artistIds; set => _artistIds = value; }

        /// <summary>
        /// Track Spotify Ids
        /// </summary>
        public List<string> TrackIds { get => _trackIds; set => _trackIds = value; }

        /// <summary>
        /// Show Spotify Ids
        /// </summary>
        public List<string> ShowIds { get => _showIds; set => _showIds = value; }

        /// <summary>
        /// Show Spotify Ids
        /// </summary>
        public List<string> EpisodeIds { get => _episodeIds; set => _episodeIds = value; }
        #endregion Public Properties

        #region Private Methods
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="items">List of Items</param>
        /// <returns>True if Items is accepted or already in list, False if too many items</returns>
        private bool Add(string id, ref List<string> items)
        {
            if (items == null)
                items = new List<string>();
            if (!items.Contains(id))
                items.Add(id);
            return true;
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="multipleIds">Ids</param>
        /// <param name="items">List of Items</param>
        /// <returns>Array of Bools where True if Item was accepted or already in list, False if was not added as were too many items</returns>
        private List<bool> Add(List<string> multipleIds, ref List<string> items)
        {
            List<bool> results = new List<bool>();
            foreach (string id in multipleIds)
            {
                results.Add(Add(id, ref items));
            }
            return results;
        }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="items">List of Items</param>
        /// <returns>True if in List, False if Not</returns>
        private bool Contains(string id, ref List<string> items) =>
            items?.Contains(id) ?? false;

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="multipleIds">Multiple Ids</param>
        /// <param name="items">List of Item</param>
        /// <returns></returns>
        private List<bool> Contains(List<string> multipleIds, List<string> items) => 
            multipleIds.Select(id => items?.Contains(id) ?? false).ToList();

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="id"></param>
        /// <param name="items">List of Items</param>
        /// <returns>True if Removed, False if Not</returns>
        private bool Remove(string id, ref List<string> items)
        {
            if (Contains(id, ref items))
            {
                items?.Remove(id);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="multipleIds">List of Id</param>
        /// <param name="items">List of Items</param>
        /// <returns></returns>
        private List<bool> Remove(List<string> multipleIds, ref List<string> items)
        {
            var results = new List<bool>();
            foreach(var id in multipleIds)
            {
                results.Add(Remove(id, ref items));
            }
            return results;
        }
        #endregion Private Methods

        #region Public Methods
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="favouriteType">FavouriteType</param>
        /// <param name="id">Id</param>
        /// <returns>True if Items is accepted or already in list, False if too many items</returns>
        public bool Add(FavouriteType favouriteType, string id)
        {
            bool result = false;
            switch (favouriteType)
            {
                case FavouriteType.Album:
                    result = Add(id, ref _albumIds);
                    break;
                case FavouriteType.Artist:
                    result = Add(id, ref _artistIds);
                    break;
                case FavouriteType.Track:
                    result = Add(id, ref _trackIds);
                    break;
                case FavouriteType.Show:
                    result = Add(id, ref _showIds);
                    break;
                case FavouriteType.Episode:
                    result = Add(id, ref _episodeIds);
                    break;
            }
            return result;
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="favouriteType">FavouriteType</param>
        /// <param name="multipleIds">Item Ids</param>
        /// <returns>True if Items is accepted or already in list, False if too many items</returns>
        public List<bool> Add(FavouriteType favouriteType, List<string> multipleIds)
        {
            List<bool> result = new List<bool>();
            switch (favouriteType)
            {
                case FavouriteType.Album:
                    result = Add(multipleIds, ref _albumIds);
                    break;
                case FavouriteType.Artist:
                    result = Add(multipleIds, ref _artistIds);
                    break;
                case FavouriteType.Track:
                    result = Add(multipleIds, ref _trackIds);
                    break;
                case FavouriteType.Show:
                    result = Add(multipleIds, ref _showIds);
                    break;
                case FavouriteType.Episode:
                    result = Add(multipleIds, ref _episodeIds);
                    break;
            }
            return result;
        }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="favouriteType">FavouriteType</param>
        /// <param name="id">Item Id</param>
        /// <returns>True if in List, False if Not</returns>
        public bool Contains(FavouriteType favouriteType, string id)
        {
            bool result = false;
            switch (favouriteType)
            {
                case FavouriteType.Album:
                    result = Contains(id, ref _albumIds);
                    break;
                case FavouriteType.Artist:
                    result = Contains(id, ref _artistIds);
                    break;
                case FavouriteType.Track:
                    result = Contains(id, ref _trackIds);
                    break;
                case FavouriteType.Show:
                    result = Contains(id, ref _showIds);
                    break;
                case FavouriteType.Episode:
                    result = Contains(id, ref _episodeIds);
                    break;
            }
            return result;
        }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="favouriteType">FavouriteType</param>
        /// <param name="multipleIds">Multiple Spotify Item Id</param>
        /// <returns>True if in List, False if Not</returns>
        public List<bool> Contains(FavouriteType favouriteType, List<string> multipleIds)
        {
            List<bool> result = null;
            switch (favouriteType)
            {
                case FavouriteType.Album:
                    result = Contains(multipleIds, _albumIds);
                    break;
                case FavouriteType.Artist:
                    result = Contains(multipleIds, _artistIds);
                    break;
                case FavouriteType.Track:
                    result = Contains(multipleIds, _trackIds);
                    break;
                case FavouriteType.Show:
                    result = Contains(multipleIds, _showIds);
                    break;
                case FavouriteType.Episode:
                    result = Contains(multipleIds, _episodeIds);
                    break;
            }
            return result;
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="favouriteType">FavouriteType</param>
        /// <param name="id">Item Id</param>
        /// <returns>True if Items is removed, False if not</returns>
        public bool Remove(FavouriteType favouriteType, string id)
        {
            bool result = false;
            switch (favouriteType)
            {
                case FavouriteType.Album:
                    result = Remove(id, ref _albumIds);
                    break;
                case FavouriteType.Artist:
                    result = Remove(id, ref _artistIds);
                    break;
                case FavouriteType.Track:
                    result = Remove(id, ref _trackIds);
                    break;
                case FavouriteType.Show:
                    result = Remove(id, ref _showIds);
                    break;
                case FavouriteType.Episode:
                    result = Remove(id, ref _episodeIds);
                    break;
            }
            return result;
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="favouriteType">FavouriteType</param>
        /// <param name="multipleIds">Item Ids</param>
        /// <returns>True if Items are remove in list, False if not</returns>
        public List<bool> Remove(FavouriteType favouriteType, List<string> multipleIds)
        {
            List<bool> result = new List<bool>();
            switch (favouriteType)
            {
                case FavouriteType.Album:
                    result = Remove(multipleIds, ref _albumIds);
                    break;
                case FavouriteType.Artist:
                    result = Remove(multipleIds, ref _artistIds);
                    break;
                case FavouriteType.Track:
                    result = Remove(multipleIds, ref _trackIds);
                    break;
                case FavouriteType.Show:
                    result = Remove(multipleIds, ref _showIds);
                    break;
                case FavouriteType.Episode:
                    result = Remove(multipleIds, ref _episodeIds);
                    break;
            }
            return result;
        }
        #endregion Public Methods
    }
}