using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Spotify.NetStandard.Sdk.Test
{
    /// <summary>
    /// Spotify Sdk Client Authenticated Method Tests
    /// </summary>
    [TestClass]
    public class AuthSpotifySdkClientTest
    {
        private const string country = "GB";
        private const int limit = 3;

        private ISpotifySdkClient _client = null;

        /// <summary>
        /// Get Resource Bytes
        /// </summary>
        /// <param name="name">Resource Name</param>
        /// <returns>Byte Array</returns>
        private byte[] GetResourceBytes(string name)
        {
            byte[] bytes = null;
            using (var stream = new MemoryStream())
            {
                var results = Assembly.GetExecutingAssembly().GetManifestResourceNames();
                var resourceName = $"{Assembly.GetExecutingAssembly().GetName().Name}.{name}";
                Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName).CopyTo(stream);
                bytes = stream.ToArray();
            }
            return bytes;
        }

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
            // Spotify Client Factory
            _client = SpotifySdkClientFactory.CreateSpotifySdkClient(
                config["client_id"],
                config["client_secret"]
            ).Set(country);
            Assert.IsNotNull(_client);
            // Spotify Client Token
            var authenticationToken = new AuthenticationTokenResponse()
            {
                Token = config["token"],
                Refresh = config["refresh"],
                Expiration = DateTime.Parse(config["expires"]),
                AuthenticationTokenType = (AuthenticationTokenType)Enum.Parse(typeof(AuthenticationTokenType), config["type"])
            };
            _client.AuthenticationToken = authenticationToken;
            _client.Limit = limit;
        }

        #region Get Methods
        /// <summary>
        /// Get Current User's Profile
        /// </summary>
        [TestMethod]
        public async Task Test_GetCurrentUser()
        {
            var item = await _client.GetCurrentUserAsync();
            Assert.IsNotNull(item);
        }

        /// <summary>
        /// Get a User's Profile
        /// </summary>
        [TestMethod]
        public async Task Test_GetUser()
        {
            var item = await _client.GetUserAsync("jmperezperez");
            Assert.IsNotNull(item);
        }

        /// <summary>
        /// Get a Playlist Cover Image
        /// </summary>
        [TestMethod]
        public async Task Test_GetPlaylistCoverImage()
        {
            var result = await _client.GetPlaylistImageAsync(
                "3cEYpjA9oz9GiPac4AsH4n");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Images.Count > 0);
        }

        /// <summary>
        /// Get the User's Currently Playing Item (Track or Episode)
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Test_GetUserCurrentlyPlayingItem()
        {
            var item = await _client.GetUserCurrentlyPlayingItemAsync();
            Assert.IsNotNull(item);
        }

        /// <summary>
        /// Get Information About The User's Current Playback
        /// </summary>
        [TestMethod]
        public async Task Test_GetUserCurrentlyPlaying()
        {
            var item = await _client.GetUserCurrentlyPlayingAsync();
            Assert.IsNotNull(item);
        }
        #endregion Get Methods

        #region Get Saved
        /// <summary>
        /// Check User's Saved Album
        /// </summary>
        [TestMethod]
        public async Task Test_GetSaved_SavedAlbums()
        {
            var item = await _client.GetSavedAsync(SavedType.Album, "0zcj8iJZnXYU18xCBe1KYU");
            Assert.IsNotNull(item);
            Assert.IsTrue(item.Value);
        }

        /// <summary>
        /// Check User's Saved Track
        /// </summary>
        [TestMethod]
        public async Task Test_GetSaved_SavedTracks()
        {
            var item = await _client.GetSavedAsync(SavedType.Track, "3lVyqx2QiLap64Id5CvDaQ");
            Assert.IsNotNull(item);
            Assert.IsTrue(item.Value);
        }

        /// <summary>
        /// Check User's Saved Show
        /// </summary>
        [TestMethod]
        public async Task Test_GetSaved_SavedShows()
        {
            var item = await _client.GetSavedAsync(SavedType.Show, "4r157jjrIV0bzS6UxhN07i");
            Assert.IsNotNull(item);
            Assert.IsTrue(item.Value);
        }
        #endregion Get Saved

        #region Get Follow
        /// <summary>
        /// Get Following State for Artist/User (Artist)
        /// </summary>
        [TestMethod]
        public async Task Test_GetFollow_FollowArtist()
        {
            var item = await _client.GetFollowAsync(FollowType.Artist, "4dpARuHxo51G3z768sgnrY");
            Assert.IsNotNull(item);
            Assert.IsTrue(item.Value);
        }

        /// <summary>
        /// Get Following State for Artist/User (User)
        /// </summary>
        [TestMethod]
        public async Task Test_GetFollow_FollowUser()
        {
            var item = await _client.GetFollowAsync(FollowType.User, "spotify");
            Assert.IsNotNull(item);
            Assert.IsTrue(item.Value);
        }

        /// <summary>
        /// Check if Users Follow a Playlist
        /// </summary>
        [TestMethod]
        public async Task Test_GetFollow_FollowPlaylist()
        {
            var item = await _client.GetFollowAsync(FollowType.Playlist, "3cEYpjA9oz9GiPac4AsH4n", "jmperezperez");
            Assert.IsNotNull(item);
            Assert.IsTrue(item.Value);
        }
        #endregion Get Follow

        #region List Artists
        /// <summary>
        /// Get User's Followed Artists
        /// </summary>
        [TestMethod]
        public async Task Test_ListArtists_UserFollowed()
        {
            var request = new ArtistsRequest()
            {
                ArtistType = ArtistType.UserFollowed
            };
            var items = await _client.ListArtistsAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);

            var more = await _client.ListArtistsAsync(items);
            Assert.IsNotNull(more?.Items);
            Assert.IsTrue(more?.Items.Count > 0);
        }

        /// <summary>
        /// Get a User's Top Artists and Tracks (Artists)
        /// </summary>
        [TestMethod]
        public async Task Test_ListArtists_UserTop()
        {
            var request = new ArtistsRequest()
            {
                ArtistType = ArtistType.UserTop
            };
            var items = await _client.ListArtistsAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);

            var more = await _client.ListArtistsAsync(items);
            Assert.IsNotNull(more?.Items);
            Assert.IsTrue(more?.Items.Count > 0);
        }
        #endregion List Artists

        #region List Album
        /// <summary>
        /// Get User's Saved Albums
        /// </summary>
        [TestMethod]
        public async Task Test_ListAlbums_Saved()
        {
            var request = new AlbumsRequest()
            {
                AlbumType = AlbumType.UserSaved
            };
            var items = await _client.ListAlbumsAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);

            var more = await _client.ListAlbumsAsync(items);
            Assert.IsNotNull(more?.Items);
            Assert.IsTrue(more?.Items.Count > 0);
        }
        #endregion List Album

        #region List Tracks
        /// <summary>
        /// Get Current User's Recently Played Tracks
        /// </summary>
        [TestMethod]
        public async Task Test_ListTracks_UserRecentlyPlayed()
        {
            var request = new TracksRequest()
            {
                TrackType = TrackType.UserRecentlyPlayed
            };
            var items = await _client.ListTracksAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);

            var more = await _client.ListTracksAsync(items);
            Assert.IsNotNull(more?.Items);
            Assert.IsTrue(more?.Items.Count > 0);
        }

        /// <summary>
        /// Get User's Saved Tracks
        /// </summary>
        [TestMethod]
        public async Task Test_ListTracks_UserSaved()
        {
            var request = new TracksRequest()
            {
                TrackType = TrackType.UserSaved
            };
            var items = await _client.ListTracksAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);

            var more = await _client.ListTracksAsync(items);
            Assert.IsNotNull(more?.Items);
            Assert.IsTrue(more?.Items.Count > 0);
        }

        /// <summary>
        /// Get a User's Top Artists and Tracks (Tracks)
        /// </summary>
        [TestMethod]
        public async Task Test_ListTracks_UserTop()
        {
            var request = new TracksRequest()
            {
                TrackType = TrackType.UserTop
            };
            var items = await _client.ListTracksAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);

            var more = await _client.ListTracksAsync(items);
            Assert.IsNotNull(more?.Items);
            Assert.IsTrue(more?.Items.Count > 0);
        }
        #endregion List Tracks

        #region List Playlists
        /// <summary>
        /// Get a List of Current User's Playlists
        /// </summary>
        [TestMethod]
        public async Task Test_ListPlaylists_User()
        {
            var request = new PlaylistsRequest()
            {
                PlaylistType = PlaylistType.User
            };
            var items = await _client.ListPlaylistsAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);

            var more = await _client.ListPlaylistsAsync(items);
            Assert.IsNotNull(more?.Items);
            Assert.IsTrue(more?.Items.Count > 0);
        }


        /// <summary>
        /// Get a List of Current User's Playlists (User Addable)
        /// </summary>
        [TestMethod]
        public async Task Test_ListPlaylists_UserAddable()
        {
            var request = new PlaylistsRequest()
            {
                PlaylistType = PlaylistType.UserAddable
            };
            var items = await _client.ListPlaylistsAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);
        }

        /// <summary>
        /// Get a List of a User's Playlists
        /// </summary>
        [TestMethod]
        public async Task Test_ListPlaylists_User_Spotify()
        {
            var request = new PlaylistsRequest()
            {
                PlaylistType = PlaylistType.User,
                Value = "spotify"
            };
            var items = await _client.ListPlaylistsAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);

            var more = await _client.ListPlaylistsAsync(items);
            Assert.IsNotNull(more?.Items);
            Assert.IsTrue(more?.Items.Count > 0);
        }
        #endregion List Playlists

        #region List Shows
        /// <summary>
        /// Get User's Saved Shows
        /// </summary>
        [TestMethod]
        public async Task Test_ListShows_UserSaved()
        {
            var request = new ShowsRequest()
            {
                ShowType = ShowType.UserSaved
            };
            var items = await _client.ListShowsAsync(request);
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);

            var more = await _client.ListShowsAsync(items);
            Assert.IsNotNull(more?.Items);
            Assert.IsTrue(more?.Items.Count > 0);
        }
        #endregion List Shows

        #region List Devices
        /// <summary>
        /// Get a User's Available Devices
        /// </summary>
        [TestMethod]
        public async Task Test_ListDevices()
        {
            var items = await _client.ListUserDevicesAsync();
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items?.Items.Count > 0);
        }
        #endregion List Devices

        #region List Saved
        /// <summary>
        /// Check User's Saved Albums
        /// </summary>
        [TestMethod]
        public async Task Test_ListSaved_SavedAlbums()
        {
            var items = await _client.ListSavedAsync(SavedType.Album, new List<string> { "0zcj8iJZnXYU18xCBe1KYU" });
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items.Items.All(a => a == true));
        }

        /// <summary>
        /// Get User's Saved Tracks
        /// </summary>
        [TestMethod]
        public async Task Test_ListSaved_SavedTracks()
        {
            var items = await _client.ListSavedAsync(SavedType.Track, new List<string> { "3lVyqx2QiLap64Id5CvDaQ" });
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items.Items.All(a => a == true));
        }

        /// <summary>
        /// Get User's Saved Shows
        /// </summary>
        [TestMethod]
        public async Task Test_ListSaved_SavedShows()
        {
            var items = await _client.ListSavedAsync(SavedType.Show, new List<string> { "4r157jjrIV0bzS6UxhN07i" });
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items.Items.All(a => a == true));
        }
        #endregion List Saved

        #region List Follow
        /// <summary>
        /// Get Following State for Artists/Users (Artists)
        /// </summary>
        [TestMethod]
        public async Task Test_ListBools_FollowArtist()
        {
            var items = await _client.ListFollowAsync(FollowType.Artist, new List<string> { "4dpARuHxo51G3z768sgnrY" });
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items.Items.All(a => a == true));
        }

        /// <summary>
        /// Get Following State for Artists/Users (Users)
        /// </summary>
        [TestMethod]
        public async Task Test_ListBools_FollowUser()
        {
            var items = await _client.ListFollowAsync(FollowType.User, new List<string> { "spotify" });
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items.Items.All(a => a == true));
        }

        /// <summary>
        /// Check if Users Follow a Playlist
        /// </summary>
        [TestMethod]
        public async Task Test_ListBools_FollowPlaylist()
        {
            var items = await _client.ListFollowAsync(FollowType.Playlist, new List<string> { "jmperezperez" }, "3cEYpjA9oz9GiPac4AsH4n");
            Assert.IsNotNull(items?.Items);
            Assert.IsTrue(items.Items.All(a => a == true));
        }
        #endregion List Bools

        #region Set Methods
        /// <summary>
        /// Transfer a User's Playback
        /// </summary>
        [TestMethod]
        public async Task Test_SetUserPlayback_Device()
        {
            var status = await _client.SetUserPlaybackAsync(PlaybackType.Device, "7fd36d2a1eba3db7b0ca548ae6dfeba9144f283a");
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Skip User’s Playback To Next Track
        /// </summary>
        [TestMethod]
        public async Task Test_SetUserPlayback_Next()
        {
            var status = await _client.SetUserPlaybackAsync(PlaybackType.Next);
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Skip User’s Playback To Previous Track
        /// </summary>
        [TestMethod]
        public async Task Test_SetUserPlayback_Previous()
        {
            var status = await _client.SetUserPlaybackAsync(PlaybackType.Previous);
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Seek To Position In Currently Playing Track
        /// </summary>
        [TestMethod]
        public async Task Test_SetUserPlayback_Seek()
        {
            var status = await _client.SetUserPlaybackAsync(PlaybackType.Seek, option: 1234);
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Pause a User's Playback
        /// </summary>
        [TestMethod]
        public async Task Test_SetUserPlayback_Pause()
        {
            var status = await _client.SetUserPlaybackAsync(PlaybackType.Pause);
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Set Volume For User's Playback
        /// </summary>

        [TestMethod]
        public async Task Test_SetUserPlayback_Volume()
        {
            var status = await _client.SetUserPlaybackAsync(PlaybackType.Volume, option: 50);
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Set Repeat Mode On User’s Playback (Track)
        /// </summary>
        [TestMethod]
        public async Task Test_SetUserPlayback_RepeatTrack()
        {
            var status = await _client.SetUserPlaybackAsync(PlaybackType.RepeatTrack);
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Set Repeat Mode On User’s Playback (Context)
        /// </summary>
        [TestMethod]
        public async Task Test_SetUserPlayback_RepeatContext()
        {
            var status = await _client.SetUserPlaybackAsync(PlaybackType.RepeatContext);
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Set Repeat Mode On User’s Playback (Off)
        /// </summary>
        [TestMethod]
        public async Task Test_SetUserPlayback_RepeatOff()
        {
            var status = await _client.SetUserPlaybackAsync(PlaybackType.RepeatOff);
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Toggle Shuffle For User’s Playback (On)
        /// </summary>
        [TestMethod]
        public async Task Test_SetUserPlayback_ShuffleOn()
        {
            var status = await _client.SetUserPlaybackAsync(PlaybackType.ShuffleOn);
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Toggle Shuffle For User’s Playback (Off)
        /// </summary>
        [TestMethod]
        public async Task Test_SetUserPlayback_ShuffleOff()
        {
            var status = await _client.SetUserPlaybackAsync(PlaybackType.ShuffleOff);
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Follow Artists or Users (Artist)
        /// </summary>
        [TestMethod]
        public async Task Test_SetFollow_Add_Artist()
        {
            var status = await _client.SetFollowAsync(FollowType.Artist, SetType.Add, "1nEGjL7aMVdNQzsfQPKdGr");
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Follow Artists or Users (User)
        /// </summary>
        [TestMethod]
        public async Task Test_SetFollow_Add_User()
        {
            var status = await _client.SetFollowAsync(FollowType.User, SetType.Add, "11100538792");
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Follow a Playlist
        /// </summary>
        [TestMethod]
        public async Task Test_SetFollow_Add_Playlist()
        {
            var status = await _client.SetFollowAsync(FollowType.Playlist, SetType.Add, "1vCkoiwwFp37FP0NodPtF6");
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Unfollow Artists or Users (Artist)
        /// </summary>
        [TestMethod]
        public async Task Test_SetUnfollow_Remove_Artist()
        {
            var status = await _client.SetFollowAsync(FollowType.Artist, SetType.Remove, "1nEGjL7aMVdNQzsfQPKdGr");
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Unfollow Artists or Users (User)
        /// </summary>
        [TestMethod]
        public async Task Test_SetUnfollow_Remove_User()
        {
            var status = await _client.SetFollowAsync(FollowType.User, SetType.Remove, "11100538792");
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Unfollow Playlist
        /// </summary>
        [TestMethod]
        public async Task Test_SetUnfollow_Remove_Playlist()
        {
            var status = await _client.SetFollowAsync(FollowType.Playlist, SetType.Remove, "1vCkoiwwFp37FP0NodPtF6");
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Change a Playlist's Details
        /// </summary>
        [TestMethod]
        public async Task Test_SetPlaylist()
        {
            var name = "SDK Test - Set Playlist";
            var status = await _client.SetPlaylistAsync(new SetPlaylistRequest()
            {
                PlaylistId = "4IjU9z3V5KLlIHV2rTx0LD",
                Name = name,
                Description = "Set Playlist",
                IsCollaborative = false,
                IsPublic = false
            });
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Start/Resume a User's Playback (Track)
        /// </summary>
        [TestMethod]
        public async Task Test_SetPlaylistItem_Track()
        {
            var status = await _client.SetPlaylistItemAsync("4IjU9z3V5KLlIHV2rTx0LD", PlayItemType.Track, "71yL5d5FeZCYd7M9UzBtkM");
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Reorder a Playlist's Items
        /// </summary>
        [TestMethod]
        public async Task Test_SetPlaylistOrder()
        {
            var status = await _client.SetPlaylistItemOrderAsync("6ZFXOH0nDfyZt6ZRjTO9aA", 1, 0);
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Upload a Custom Playlist Cover Image
        /// </summary>
        [TestMethod]
        public async Task Test_SetPlaylistImage()
        {
            var jpegFileBytes = GetResourceBytes("playlist-image.jpg");
            var status = await _client.SetPlaylistImageAsync("4IjU9z3V5KLlIHV2rTx0LD", jpegFileBytes);
            Assert.IsTrue(status.Success);
        }
        #endregion Set Methods

        #region Toggle Methods
        /// <summary>
        /// Save Albums for Current User / Remove Albums for Current User
        /// </summary>
        [TestMethod]
        public async Task ToggleSaved_Album()
        {
            var result = await _client.ToggleSavedAsync(SavedType.Album, "44msshHeN6irJ1md7GVSlU");
            Assert.IsTrue(result.IsSuccess);

            var toggle = await _client.ToggleSavedAsync(SavedType.Album, "44msshHeN6irJ1md7GVSlU");
            Assert.IsTrue(toggle.IsSuccess);
        }

        /// <summary>
        /// Save Shows for Current User / Remove User's Saved Shows
        /// </summary>
        [TestMethod]
        public async Task ToggleSaved_Show()
        {
            var result = await _client.ToggleSavedAsync(SavedType.Show, "3VeCyXeFa4ex441AKbq9Xg");
            Assert.IsTrue(result.IsSuccess);

            var toggle = await _client.ToggleSavedAsync(SavedType.Show, "3VeCyXeFa4ex441AKbq9Xg");
            Assert.IsTrue(toggle.IsSuccess);
        }

        /// <summary>
        /// Save Tracks for User / Remove User's Saved Tracks
        /// </summary>
        [TestMethod]
        public async Task ToggleSaved_Track()
        {
            var result = await _client.ToggleSavedAsync(SavedType.Track, "7nDtTcOHASldPDHd1V2pCZ");
            Assert.IsTrue(result.IsSuccess);

            var toggle = await _client.ToggleSavedAsync(SavedType.Track, "7nDtTcOHASldPDHd1V2pCZ");
            Assert.IsTrue(toggle.IsSuccess);
        }
        #endregion Toggle Methods

        #region Add Methods
        /// <summary>
        /// Start/Resume a User's Playback (Track)
        /// </summary>
        [TestMethod]
        public async Task Test_AddUserPlayback_Track()
        {
            var status = await _client.AddUserPlaybackAsync(PlaybackStartType.Track, "5YdibPcnANMEMZ2NtG840v");
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Start/Resume a User's Playback (Episode)
        /// </summary>
        [TestMethod]
        public async Task Test_AddUserPlayback_Episode()
        {
            var status = await _client.AddUserPlaybackAsync(PlaybackStartType.Episode, "79hCFrLsRSD7VlDYXcrCVt");
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Start/Resume a User's Playback (Album)
        /// </summary>
        [TestMethod]
        public async Task Test_AddUserPlayback_Album()
        {
            var status = await _client.AddUserPlaybackAsync(
                playbackStartType: PlaybackStartType.Album,
                id: "3lwu4qs7RJEBRfsDL7aUwu",
                offsetId: "2ruX9C1r6qOuS40I5OW8ys",
                deviceId: "bf96d33aaf040a13148d874f1be15b1fea54ba33");
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Start/Resume a User's Playback (Artist)
        /// </summary>
        [TestMethod]
        public async Task Test_AddUserPlayback_Artist()
        {
            var status = await _client.AddUserPlaybackAsync(PlaybackStartType.Artist, "2wY79sveU1sp5g7SokKOiI");
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Start/Resume a User's Playback (Playlist)
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Test_AddUserPlayback_Playlist()
        {
            var status = await _client.AddUserPlaybackAsync(PlaybackStartType.Playlist, "37i9dQZF1DWSXBu5naYCM9");
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Start/Resume a User's Playback (Show)
        /// </summary>
        [TestMethod]
        public async Task Test_AddUserPlayback_Show()
        {
            var status = await _client.AddUserPlaybackAsync(
                playbackStartType: PlaybackStartType.Show,
                id: "5tz9eGgXtNHmq3WVD3EwYx",
                offsetId: "1zFJ5TqfqaCZgmAZAOuMGb",
                deviceId: "bf96d33aaf040a13148d874f1be15b1fea54ba33");
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Add an item to the end of the user's current playback queue (Track)
        /// </summary>
        [TestMethod]
        public async Task Test_AddUserPlaybackQueue_Track()
        {
            var status = await _client.AddUserPlaybackQueueAsync(PlayItemType.Track, "3gYveYzeG2u9I7dDhTfBsJ");
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Add an item to the end of the user's current playback queue (Episode)
        /// </summary>
        [TestMethod]
        public async Task Test_AddUserPlaybackQueue_Episode()
        {
            var status = await _client.AddUserPlaybackQueueAsync(PlayItemType.Episode, "6EbtlqXrvhCBic2TpeaalK");
            Assert.IsTrue(status.Success);
        }

        /// <summary>
        /// Create a Playlist
        /// </summary>
        [TestMethod]
        public async Task Test_AddPlaylist()
        {
            var name = "SDK Test - Add Playlist";
            var playlist = await _client.AddPlaylistAsync(new AddPlaylistRequest()
            {
                UserId = "doa31nixtl3kmy7uf8ov88sy0",
                Name = name,
                Description = "Add Playlist",
                IsCollaborative = false,
                IsPublic = false
            });
            Assert.IsNotNull(playlist);
            Assert.AreEqual(playlist.Name, name);
        }

        /// <summary>
        /// Add Items to a Playlist (Track)
        /// </summary>
        [TestMethod]
        public async Task Test_AddPlaylistItem_Track()
        {
            var snapshot = await _client.AddPlaylistItemAsync("4IjU9z3V5KLlIHV2rTx0LD",
                PlayItemType.Track, "2zzdnRWE3z6QP3FoVlnWHO", 0);
            Assert.IsNotNull(snapshot);
        }

        /// <summary>
        /// Add Items to a Playlist (Episode)
        /// </summary>
        [TestMethod]
        public async Task Test_AddPlaylistItem_Episode()
        {
            var snapshot = await _client.AddPlaylistItemAsync("4IjU9z3V5KLlIHV2rTx0LD",
                PlayItemType.Episode, "58fkjlMPXPokrOMpMHNdyv", 0);
            Assert.IsNotNull(snapshot);
        }
        #endregion Add Methods

        #region Remove Methods
        /// <summary>
        /// Remove Items from a Playlist
        /// </summary>
        [TestMethod]
        public async Task Test_RemovePlaylistItem_Track()
        {
            var snapshot = await _client.RemovePlaylistItemAsync("4IjU9z3V5KLlIHV2rTx0LD",
                PlayItemType.Track, "2zzdnRWE3z6QP3FoVlnWHO", new List<int> { 1 });
            Assert.IsNotNull(snapshot);
        }
        #endregion Remove Methods
    }
}
