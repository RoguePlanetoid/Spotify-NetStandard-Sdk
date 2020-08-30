using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.NetStandard.Sdk.Test
{
    /// <summary>
    /// Spotify Sdk Client Method Tests
    /// </summary>
    [TestClass]
    public class SpotifySdkClientTest
    {
        private const string country = "GB";
        private const int limit = 3;

        private ISpotifySdkClient _client = null;

        /// <summary>
        /// Initialise Unit Test and Configuration
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Configuration
            var configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration config = configBuilder.Build();
            // Spotify Sdk Client Factory
            _client = SpotifySdkClientFactory.CreateSpotifySdkClient(
                config["client_id"], 
                config["client_secret"]
            ).Set(country);
            Assert.IsNotNull(_client);
            // Set Limit
            _client.Limit = limit;
        }

        #region Get Methods
        /// <summary>
        /// Get a Category
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Test_Get_Category()
        {
            var item = await _client.GetCategoryAsync("pop");
            Assert.IsTrue(item?.Id == "pop");
        }

        /// <summary>
        /// Get an Artist
        /// </summary>
        [TestMethod]
        public async Task Test_Get_Artist()
        {
            var item = await _client.GetArtistAsync("43ZHCT0cAZBISjO8DG9PnE");
            Assert.IsTrue(item?.Id == "43ZHCT0cAZBISjO8DG9PnE");
        }

        /// <summary>
        /// Get a Playlist
        /// </summary>
        [TestMethod]
        public async Task Test_Get_Playlist()
        {
            var item = await _client.GetPlaylistAsync("37i9dQZF1DXatMjChPKgBk");
            Assert.IsTrue(item?.Id == "37i9dQZF1DXatMjChPKgBk");
        }

        /// <summary>
        /// Get an Album
        /// </summary>
        [TestMethod]
        public async Task Test_Get_Album()
        {
            var item = await _client.GetAlbumAsync("1ZGxGu4fMROqmZsFSoepeE");
            Assert.IsTrue(item?.Id == "1ZGxGu4fMROqmZsFSoepeE");
        }

        /// <summary>
        /// Get Audio Analysis for a Track
        /// </summary>
        [TestMethod]
        public async Task Test_Get_Track_AudioAnalysis()
        {
            var item = await _client.GetTrackAudioAnalysisAsync("1cTZMwcBJT0Ka3UJPXOeeN");
            Assert.IsNotNull(item);
        }

        /// <summary>
        /// Get Audio Features for a Track
        /// </summary>
        [TestMethod]
        public async Task Test_Get_Track_AudioFeatures()
        {
            var item = await _client.GetTrackAudioFeaturesAsync("1cTZMwcBJT0Ka3UJPXOeeN");
            Assert.IsNotNull(item);
        }

        /// <summary>
        /// Get a Track
        /// </summary>
        [TestMethod]
        public async Task Test_Get_Track()
        {
            var item = await _client.GetTrackAsync("3CA9pLiwRIGtUBiMjbZmRw");
            Assert.IsTrue(item?.Id == "3CA9pLiwRIGtUBiMjbZmRw");
        }

        /// <summary>
        /// Get an Episode
        /// </summary>
        [TestMethod]
        public async Task Test_Get_Episode()
        {
            var item = await _client.GetEpisodeAsync("79hCFrLsRSD7VlDYXcrCVt");
            Assert.IsTrue(item?.Id == "79hCFrLsRSD7VlDYXcrCVt");
        }

        /// <summary>
        /// Get a Show
        /// </summary>
        [TestMethod]
        public async Task Test_Get_Show()
        {
            var item = await _client.GetShowAsync("4r157jjrIV0bzS6UxhN07i");
            Assert.IsTrue(item?.Id == "4r157jjrIV0bzS6UxhN07i");
        }
        #endregion Get Methods

        #region List Categories
        /// <summary>
        /// Get All Categories
        /// </summary>
        [TestMethod]
        public async Task Test_List_Categories()
        {
            var items = await _client.ListCategoriesAsync();
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);

            var more = await _client.ListCategoriesAsync(items);
            Assert.IsNotNull(more?.Items);
            Assert.IsTrue(more?.Items.Count > 0);
        }
        #endregion List Categories

        #region List Artists
        /// <summary>
        /// Get Multiple Artists
        /// </summary>
        [TestMethod]
        public async Task Test_ListArtists_Multiple()
        {
            var request = new ArtistsRequest()
            {
                ArtistType = ArtistType.Multiple,
                MultipleArtistIds = new List<string> 
                { 
                    "2wY79sveU1sp5g7SokKOiI", 
                    "6qqNVTkY8uBg9cP3Jd7DAH" 
                }
            };
            var items = await _client.ListArtistsAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);
        }

        /// <summary>
        /// Search for an Item (Artists)
        /// </summary>
        [TestMethod]
        public async Task Test_ListArtists_Search()
        {
            var request = new ArtistsRequest()
            {
                ArtistType = ArtistType.Search,
                Value = "Oldfield"
            };
            var items = await _client.ListArtistsAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);

            var more = await _client.ListArtistsAsync(items);
            Assert.IsNotNull(more?.Items);
            Assert.IsTrue(more?.Items.Count > 0);
        }

        /// <summary>
        /// Get an Artist's Related Artists
        /// </summary>
        [TestMethod]
        public async Task Test_ListArtists_Related()
        {
            var request = new ArtistsRequest()
            {
                ArtistType = ArtistType.Related,
                Value = "562Od3CffWedyz2BbeYWVn"
            };
            var items = await _client.ListArtistsAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);
        }
        #endregion List Artists

        #region List Albums
        /// <summary>
        /// Get Multiple Albums
        /// </summary>
        [TestMethod]
        public async Task Test_ListAlbums_Multiple()
        {
            var request = new AlbumsRequest()
            {
                AlbumType = AlbumType.Multiple,
                MultipleAlbumIds = new List<string> 
                { 
                    "5sXSHscDjBez8VF20cSyad", 
                    "31qVWUdRrlb8thMvts0yYL" 
                }
            };
            var items = await _client.ListAlbumsAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);
        }

        /// <summary>
        /// Search for an Item (Albums)
        /// </summary>
        [TestMethod]
        public async Task Test_ListAlbums_Search()
        {
            var request = new AlbumsRequest()
            {
                AlbumType = AlbumType.Search,
                Value = "Tubular Bells"
            };
            var items = await _client.ListAlbumsAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);

            var more = await _client.ListAlbumsAsync(items);
            Assert.IsNotNull(more?.Items);
            Assert.IsTrue(more?.Items.Count > 0);
        }

        /// <summary>
        /// Get All New Releases
        /// </summary>
        [TestMethod]
        public async Task Test_ListAlbums_NewReleases()
        {
            var request = new AlbumsRequest()
            {
                AlbumType = AlbumType.NewReleases
            };
            var items = await _client.ListAlbumsAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);

            var more = await _client.ListAlbumsAsync(items);
            Assert.IsNotNull(more?.Items);
            Assert.IsTrue(more?.Items.Count > 0);
        }

        /// <summary>
        /// Get an Artist's Albums
        /// </summary>
        [TestMethod]
        public async Task Test_ListAlbums_Artist()
        {
            var request = new AlbumsRequest()
            {
                AlbumType = AlbumType.Artist,
                Value = "43ZHCT0cAZBISjO8DG9PnE",
                IncludeGroup = new IncludeGroupRequest()
                {
                    Album = true
                }
            };
            var items = await _client.ListAlbumsAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);

            var more = await _client.ListAlbumsAsync(items);
            Assert.IsNotNull(more?.Items);
            Assert.IsTrue(more?.Items.Count > 0);
        }
        #endregion List Albums

        #region List Tracks
        /// <summary>
        /// Get Several Tracks
        /// </summary>
        [TestMethod]
        public async Task Test_ListTracks_Multiple()
        {
            var request = new TracksRequest()
            {
                TrackType = TrackType.Multiple,
                MultipleTrackIds = new List<string> 
                { 
                    "5YdibPcnANMEMZ2NtG840v", 
                    "3gYveYzeG2u9I7dDhTfBsJ" 
                },
            };
            var items = await _client.ListTracksAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);
        }

        /// <summary>
        /// Search for an Item (Tracks)
        /// </summary>
        [TestMethod]
        public async Task Test_ListTracks_Search()
        {
            var request = new TracksRequest()
            {
                TrackType = TrackType.Search,
                Value = "Hello",
            };
            var items = await _client.ListTracksAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);

            var more = await _client.ListTracksAsync(items);
            Assert.IsNotNull(more?.Items);
            Assert.IsTrue(more?.Items.Count > 0);
        }

        /// <summary>
        /// Get Recommendations (Genre)
        /// </summary>
        [TestMethod]
        public async Task Test_ListTracks_Recommended_Genre()
        {
            var request = new TracksRequest()
            {
                TrackType = TrackType.Recommended,
                Recommendation = new RecommendationRequest()
                {
                    SeedGenre = "rock"
                }
            };
            var items = await _client.ListTracksAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);
        }

        /// <summary>
        /// Get Recommendations (Artist)
        /// </summary>
        [TestMethod]
        public async Task Test_ListTracks_Recommended_Artist()
        {
            var request = new TracksRequest()
            {
                TrackType = TrackType.Recommended,
                Recommendation = new RecommendationRequest()
                {
                    SeedArtistIds = new List<string>() { "6qqNVTkY8uBg9cP3Jd7DAH" }
                }
            };
            var items = await _client.ListTracksAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);
        }

        /// <summary>
        /// Get Recommendations (Track)
        /// </summary>
        [TestMethod]
        public async Task Test_ListTracks_Recommended_Track()
        {
            var request = new TracksRequest()
            {
                TrackType = TrackType.Recommended,
                Recommendation = new RecommendationRequest()
                {
                    SeedTrackIds = new List<string>() { "3gYveYzeG2u9I7dDhTfBsJ" }
                }
            };
            var items = await _client.ListTracksAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);
        }

        /// <summary>
        /// Get an Album's Tracks
        /// </summary>
        [TestMethod]
        public async Task Test_ListTracks_Album()
        {
            var request = new TracksRequest()
            {
                TrackType = TrackType.Album,
                Value = "6bL2a1Sq96zlG4FoQbcn7k"
            };
            var items = await _client.ListTracksAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);

            var more = await _client.ListTracksAsync(items);
            Assert.IsNotNull(more?.Items);
            Assert.IsTrue(more?.Items.Count > 0);
        }

        /// <summary>
        /// Get an Artist's Top Tracks
        /// </summary>
        [TestMethod]
        public async Task Test_ListTracks_Artist()
        {
            var request = new TracksRequest()
            {
                TrackType = TrackType.Artist,
                Value = "43ZHCT0cAZBISjO8DG9PnE"
            };
            var items = await _client.ListTracksAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);
        }
        #endregion List Artists

        #region List Playlists
        /// <summary>
        /// Search for an Item (Playlist)
        /// </summary>
        [TestMethod]
        public async Task Test_ListPlaylists_Search()
        {
            var request = new PlaylistsRequest()
            {
                PlaylistType = PlaylistType.Search,
                Value = "Chill"
            };
            var items = await _client.ListPlaylistsAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);

            var more = await _client.ListPlaylistsAsync(items);
            Assert.IsNotNull(more?.Items);
            Assert.IsTrue(more?.Items.Count > 0);
        }

        /// <summary>
        /// Get All Featured Playlists
        /// </summary>
        [TestMethod]
        public async Task Test_ListPlaylists_Featured()
        {
            var request = new PlaylistsRequest()
            {
                PlaylistType = PlaylistType.Featured
            };
            var items = await _client.ListPlaylistsAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);

            var more = await _client.ListPlaylistsAsync(items);
            Assert.IsNotNull(more?.Items);
            Assert.IsTrue(more?.Items.Count > 0);
        }

        /// <summary>
        /// Get a Category's Playlists
        /// </summary>
        [TestMethod]
        public async Task Test_ListPlaylists_CategoriesPlaylists()
        {
            var request = new PlaylistsRequest()
            {
                PlaylistType = PlaylistType.Category,
                Value = "mood"
            };
            var items = await _client.ListPlaylistsAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);

            var more = await _client.ListPlaylistsAsync(items);
            Assert.IsNotNull(more?.Items);
            Assert.IsTrue(more?.Items.Count > 0);
        }

        /// <summary>
        /// Get a Playlist's Items
        /// </summary>
        [TestMethod]
        public async Task Test_ListPlaylistItems()
        {
            var request = new PlaylistItemsRequest()
            {
                PlaylistId = "37i9dQZF1DZ06evO2ZGJkQ"
            };
            var items = await _client.ListPlaylistItemsAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);

            var more = await _client.ListPlaylistItemsAsync(items);
            Assert.IsNotNull(more?.Items);
            Assert.IsTrue(more?.Items.Count > 0);
        }
        #endregion List Playlists

        #region List Episodes
        /// <summary>
        /// Get Multiple Episodes
        /// </summary>
        [TestMethod]
        public async Task Test_ListEpisodes_Multiple()
        {
            var request = new EpisodesRequest()
            {
                EpisodeType = EpisodeType.Multiple,
                MultipleEpisodeIds = new List<string> 
                { 
                    "79hCFrLsRSD7VlDYXcrCVt", 
                    "6EbtlqXrvhCBic2TpeaalK" 
                }
            };
            var items = await _client.ListEpisodesAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);
        }

        /// <summary>
        /// Search for an Item (Episodes)
        /// </summary>
        [TestMethod]
        public async Task Test_ListEpisodes_Search()
        {
            var request = new EpisodesRequest()
            {
                EpisodeType = EpisodeType.Search,
                Value = "Andrew Jackson"
            };
            var items = await _client.ListEpisodesAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);

            var more = await _client.ListEpisodesAsync(items);
            Assert.IsNotNull(more?.Items);
            Assert.IsTrue(more?.Items.Count > 0);
        }

        /// <summary>
        /// Get a Show's Episodes
        /// </summary>
        [TestMethod]
        public async Task Test_ListEpisodes_Show()
        {
            var request = new EpisodesRequest()
            {
                EpisodeType = EpisodeType.Show,
                Value = "4r157jjrIV0bzS6UxhN07i"
            };
            var items = await _client.ListEpisodesAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);

            var more = await _client.ListEpisodesAsync(items);
            Assert.IsNotNull(more?.Items);
            Assert.IsTrue(more?.Items.Count > 0);
        }
        #endregion List Episodes

        #region List Shows
        /// <summary>
        /// Get Multiple Shows
        /// </summary>
        [TestMethod]
        public async Task Test_ListShows_Multiple()
        {
            var request = new ShowsRequest()
            {
                ShowType = ShowType.Multiple,
                MultipleShowIds = new List<string> 
                { 
                    "4r157jjrIV0bzS6UxhN07i", 
                    "2GmNzw8t4uG70rn4XG9zcC" 
                }
            };
            var items = await _client.ListShowsAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);
        }

        /// <summary>
        /// Search for an Item (Shows)
        /// </summary>
        [TestMethod]
        public async Task Test_ListShows_Search()
        {
            var request = new ShowsRequest()
            {
                ShowType = ShowType.Search,
                Value = "Famous"
            };
            var items = await _client.ListShowsAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);

            var more = await _client.ListShowsAsync(items);
            Assert.IsNotNull(more?.Items);
            Assert.IsTrue(more?.Items.Count > 0);
        }
        #endregion List Shows

        #region List Methods
        /// <summary>
        /// Get Recommendation Genres
        /// </summary>
        [TestMethod]
        public async Task Test_ListRecommendationGenres()
        {
            var items = await _client.ListRecommendationGenresAsync();
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);
        }

        /// <summary>
        /// Get Audio Features for Several Tracks
        /// </summary>
        [TestMethod]
        public async Task Test_ListAudioFeatures_List()
        {
            var request = new AudioFeaturesRequest()
            {
                MultipleTrackIds = new List<string> 
                {
                    "3n3Ppam7vgaVa1iaRUc9Lp",
                    "3twNvmDtFQtAd5gMKedhLD"
                }
            };
            var items = await _client.ListAudioFeaturesAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);
        }
        #endregion List Methods

        #region Search Method
        /// <summary>
        /// Search for an Item
        /// </summary>
        [TestMethod]
        public async Task Test_Search()
        {
            SearchRequest request = new SearchRequest()
            {
                Query = "Tubular",
                SearchTypeRequest = new SearchTypeRequest().All()
            };
            var response = await _client.SearchAsync(request);
            Assert.IsTrue(response.Albums?.Items?.Count > 0);
            Assert.IsTrue(response.Artists?.Items?.Count > 0);
            Assert.IsTrue(response.Episodes?.Items?.Count > 0);
            Assert.IsTrue(response.Playlists?.Items?.Count > 0);
            Assert.IsTrue(response.Shows?.Items?.Count > 0);
            Assert.IsTrue(response.Tracks?.Items?.Count > 0);
        }
        #endregion Search Method

        #region Favourite Methods
        /// <summary>
        /// List Albums (Favourites)
        /// </summary>
        [TestMethod]
        public async Task Test_ListAlbums_Favourite()
        {
            // Arrange
            _client.Favourites.AlbumIds = new List<string> { "2C5HYffMBumERQlNfceyrO" };
            // Act
            var request = new AlbumsRequest()
            {
                AlbumType = AlbumType.Favourite
            };
            var response = await _client.ListAlbumsAsync(request);
            // Assert
            Assert.IsNotNull(response);
        }

        /// <summary>
        /// List Artists (Favourites)
        /// </summary>
        [TestMethod]
        public async Task Test_ListArtists_Favourite()
        {
            // Arrange
            _client.Favourites.ArtistIds = new List<string> { "724YlnEzfIBXRWSmT1ur6W" };
            // Act
            var request = new ArtistsRequest()
            {
                ArtistType = ArtistType.Favourite
            };
            var response = await _client.ListArtistsAsync(request);
            // Assert
            Assert.IsNotNull(response);
        }

        /// <summary>
        /// List Episodes (Favourites)
        /// </summary>
        [TestMethod]
        public async Task Test_ListEpisodes_Favourite()
        {
            // Arrange
            _client.Favourites.EpisodeIds = new List<string> { "4f7Db3sSFzxZPZkHJqGIdG" };
            // Act
            var request = new EpisodesRequest()
            {
                EpisodeType = EpisodeType.Favourite
            };
            var response = await _client.ListEpisodesAsync(request);
            // Assert
            Assert.IsNotNull(response);
        }

        /// <summary>
        /// List Shows (Favourites)
        /// </summary>
        [TestMethod]
        public async Task Test_ListShows_Favourite()
        {
            // Arrange
            _client.Favourites.ShowIds = new List<string> { "5tz9eGgXtNHmq3WVD3EwYx" };
            // Act
            var request = new ShowsRequest()
            {
                ShowType = ShowType.Favourite
            };
            var response = await _client.ListShowsAsync(request);
            // Assert
            Assert.IsNotNull(response);
        }

        /// <summary>
        /// List Tracks (Favourites)
        /// </summary>
        [TestMethod]
        public async Task Test_ListTracks_Favourite()
        {
            // Arrange
            _client.Favourites.TrackIds = new List<string> { "5plveMW66pe7YdXLbf060h" };
            // Act
            var request = new TracksRequest()
            {
                TrackType = TrackType.Favourite
            };
            var response = await _client.ListTracksAsync(request);
            // Assert
            Assert.IsNotNull(response);
        }

        /// <summary>
        /// Get Favourite
        /// </summary>
        /// <param name="favouriteType">Favourite Type</param>
        /// <param name="id">Id</param>
        [TestMethod]
        [DataRow(FavouriteType.Album, "2C5HYffMBumERQlNfceyrO")]
        [DataRow(FavouriteType.Artist, "724YlnEzfIBXRWSmT1ur6W")]
        [DataRow(FavouriteType.Episode, "4f7Db3sSFzxZPZkHJqGIdG")]
        [DataRow(FavouriteType.Show, "5tz9eGgXtNHmq3WVD3EwYx")]
        [DataRow(FavouriteType.Track, "5plveMW66pe7YdXLbf060h")]
        public async Task Test_GetFavourite(FavouriteType favouriteType, string id)
        {
            // Arrange
            await _client.SetFavouriteAsync(favouriteType, SetType.Add, id);
            // Act
            var result = await _client.GetFavouriteAsync(favouriteType, id);
            // Assert
            Assert.IsTrue(result.Value);
        }

        /// <summary>
        /// List Favourite
        /// </summary>
        /// <param name="favouriteType">Favourite Type</param>
        /// <param name="id">Id</param>
        [TestMethod]
        [DataRow(FavouriteType.Album, "2C5HYffMBumERQlNfceyrO")]
        [DataRow(FavouriteType.Artist, "724YlnEzfIBXRWSmT1ur6W")]
        [DataRow(FavouriteType.Episode, "4f7Db3sSFzxZPZkHJqGIdG")]
        [DataRow(FavouriteType.Show, "5tz9eGgXtNHmq3WVD3EwYx")]
        [DataRow(FavouriteType.Track, "5plveMW66pe7YdXLbf060h")]
        public async Task Test_ListFavourite(FavouriteType favouriteType, string id)
        {
            // Arrange
            var response = await _client.SetFavouriteAsync(favouriteType, SetType.Add, id);
            // Act
            var result = await _client.ListFavouriteAsync(favouriteType, new List<string> { id });
            // Assert
            Assert.IsTrue(result.Items.All(a => a == true));
        }

        /// <summary>
        /// Toggle Favourite
        /// </summary>
        /// <param name="favouriteType">Favourite Type</param>
        /// <param name="id">Id</param>
        [TestMethod]
        [DataRow(FavouriteType.Album, "2C5HYffMBumERQlNfceyrO")]
        [DataRow(FavouriteType.Artist, "724YlnEzfIBXRWSmT1ur6W")]
        [DataRow(FavouriteType.Episode, "4f7Db3sSFzxZPZkHJqGIdG")]
        [DataRow(FavouriteType.Show, "5tz9eGgXtNHmq3WVD3EwYx")]
        [DataRow(FavouriteType.Track, "5plveMW66pe7YdXLbf060h")]
        public async Task Test_ToggleFavourite(FavouriteType favouriteType, string id)
        {
            var result = await _client.ToggleFavouriteAsync(favouriteType, id);
            Assert.IsTrue(result.Value);
        }
        #endregion Favourite Methods
    }
}
