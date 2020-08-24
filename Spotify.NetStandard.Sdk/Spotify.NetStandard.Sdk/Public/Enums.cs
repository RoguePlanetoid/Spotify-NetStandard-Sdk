namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Authentication Token Type
    /// </summary>
    public enum AuthenticationTokenType : byte
    {
        /// <summary>
        /// Access Token
        /// </summary>
        Access,
        /// <summary>
        /// User Token
        /// </summary>
        User
    }

    /// <summary>
    /// Authentication Flow Type
    /// </summary>
    public enum AuthenticationFlowType : byte
    {
        /// <summary>
        /// Authorisation Code Flow
        /// </summary>
        AuthorisationCode,
        /// <summary>
        ///  Authorization Code Flow With Proof Key For Code Exchange (PKCE)
        /// </summary>
        AuthorisationCodeWithProofKeyForCodeExchange,
        /// <summary>
        /// Client Credentials Flow
        /// </summary>
        ClientCredentials,
        /// <summary>
        /// Implicit Grant Flow
        /// </summary>
        ImplicitGrant
    }

    /// <summary>
    /// Navigation Type
    /// </summary>
    public enum NavigationType : byte
    {
        /// <summary>
        /// Href
        /// </summary>
        Href = 0,
        /// <summary>
        /// Navigate Back
        /// </summary>
        Back = 1,
        /// <summary>
        /// Navigate Next
        /// </summary>
        Next = 2
    }

    /// <summary>
    /// User Top Time Range Type
    /// </summary>
    public enum UserTopTimeRangeType : byte
    {
        /// <summary>
        /// Calculated from several years of data and including all new data as it becomes available
        /// </summary>
        LongTerm,
        /// <summary>
        /// Approximately last 6 months
        /// </summary>
        MediumTerm,
        /// <summary>
        /// Approximately last 4 weeks
        /// </summary>
        ShortTerm
    }

    /// <summary>
    /// Artist Type
    /// </summary>
    public enum ArtistType : byte
    {
        /// <summary>
        /// Favourite Artists
        /// </summary>
        Favourite,
        /// <summary>
        /// Multiple Artists
        /// </summary>
        Multiple,
        /// <summary>
        /// Search for Artist
        /// </summary>
        Search,
        /// <summary>
        /// Related Artists
        /// </summary>
        Related,
        /// <summary>
        /// User's Followed Artists
        /// </summary>
        UserFollowed,
        /// <summary>
        /// User's Top Artists
        /// </summary>
        UserTop
    }

    /// <summary>
    /// Album Type
    /// </summary>
    public enum AlbumType : byte
    {
        /// <summary>
        /// Favourite Albums
        /// </summary>
        Favourite,
        /// <summary>
        /// Multiple Albums
        /// </summary>
        Multiple,
        /// <summary>
        /// Search for Album
        /// </summary>
        Search,
        /// <summary>
        /// New Releases
        /// </summary>
        NewReleases,
        /// <summary>
        /// Artist Albums
        /// </summary>
        Artist,
        /// <summary>
        /// User's Saved Albums
        /// </summary>
        UserSaved
    }

    /// <summary>
    /// Track Type
    /// </summary>
    public enum TrackType : byte
    {
        /// <summary>
        /// Favourite Tracks
        /// </summary>
        Favourite,
        /// <summary>
        /// Multiple Tracks
        /// </summary>
        Multiple,
        /// <summary>
        /// Search for Track
        /// </summary>
        Search,
        /// <summary>
        /// Get Recommendations
        /// </summary>
        Recommended,
        /// <summary>
        /// Album Tracks
        /// </summary>
        Album,
        /// <summary>
        /// Artist Top Tracks
        /// </summary>
        Artist,
        /// <summary>
        /// User's Recently Played Tracks
        /// </summary>
        UserRecentlyPlayed,
        /// <summary>
        /// User's Saved Tracks
        /// </summary>
        UserSaved,
        /// <summary>
        /// User's Top Tracks
        /// </summary>
        UserTop
    }

    /// <summary>
    /// Playlist Type
    /// </summary>
    public enum PlaylistType : byte
    {
        /// <summary>
        /// Search for Playlist
        /// </summary>
        Search,
        /// <summary>
        /// Featured Playlists
        /// </summary>
        Featured,
        /// <summary>
        /// Category Playlists
        /// </summary>
        CategoryPlaylist,
        /// <summary>
        /// User's Playlists
        /// </summary>
        User,
        /// <summary>
        /// User Addable Playlists
        /// </summary>
        UserAddable
    }

    /// <summary>
    /// Episode Type
    /// </summary>
    public enum EpisodeType : byte
    {
        /// <summary>
        /// Favourite Episodes
        /// </summary>
        Favourite,
        /// <summary>
        /// Multiple Episodes
        /// </summary>
        Multiple,
        /// <summary>
        /// Search for Episode
        /// </summary>
        Search,
        /// <summary>
        /// Get a Show's Episodes
        /// </summary>
        Show
    }

    /// <summary>
    /// Show Type
    /// </summary>
    public enum ShowType : byte
    {
        /// <summary>
        /// Favourite Shows
        /// </summary>
        Favourite,
        /// <summary>
        /// Multiple Shows
        /// </summary>
        Multiple,
        /// <summary>
        /// Search for a Show
        /// </summary>
        Search,
        /// <summary>
        /// User's Saved Shows
        /// </summary>
        UserSaved
    }

    /// <summary>
    /// Playback Type
    /// </summary>
    public enum PlaybackType : byte
    {
        /// <summary>
        /// Transfer a User's Playback
        /// </summary>
        Device,
        /// <summary>
        /// Skip User’s Playback To Next Track
        /// </summary>
        Next,
        /// <summary>
        /// Skip User’s Playback To Previous Track
        /// </summary>
        Previous,
        /// <summary>
        /// Seek To Position In Currently Playing Track
        /// </summary>
        Seek,
        /// <summary>
        /// Pause a User's Playback
        /// </summary>
        Pause,
        /// <summary>
        /// Resume a User's Playback
        /// </summary>
        Resume,
        /// <summary>
        /// Set Volume For User's Playback
        /// </summary>
        Volume,
        /// <summary>
        /// Set Repeat Mode On User’s Playback as Track
        /// </summary>
        RepeatTrack,
        /// <summary>
        /// Set Repeat Mode On User’s Playback as Context
        /// </summary>
        RepeatContext,
        /// <summary>
        /// Set Repeat Mode On User’s Playback as Off
        /// </summary>
        RepeatOff,
        /// <summary>
        /// Toggle Shuffle For User’s Playback as On
        /// </summary>
        ShuffleOn,
        /// <summary>
        /// Toggle Shuffle For User’s Playback as Off
        /// </summary>
        ShuffleOff
    }

    /// <summary>
    /// Playback Start Type
    /// </summary>
    public enum PlaybackStartType : byte
    {
        /// <summary>
        /// Track
        /// </summary>
        Track,
        /// <summary>
        /// Episode
        /// </summary>
        Episode,
        /// <summary>
        /// Album
        /// </summary>
        Album,
        /// <summary>
        /// Artist
        /// </summary>
        Artist,
        /// <summary>
        /// Playlist
        /// </summary>
        Playlist,
        /// <summary>
        /// Show
        /// </summary>
        Show
    }

    /// <summary>
    /// Play Item Type
    /// </summary>
    public enum PlayItemType : byte
    {
        /// <summary>
        /// Track
        /// </summary>
        Track,
        /// <summary>
        /// Episode
        /// </summary>
        Episode
    }

    /// <summary>
    /// Saved Type
    /// </summary>
    public enum SavedType : byte
    {
        /// <summary>
        /// Album
        /// </summary>
        Album,
        /// <summary>
        /// Track
        /// </summary>
        Track,
        /// <summary>
        /// Show
        /// </summary>
        Show
    }

    /// <summary>
    /// Follow Type
    /// </summary>
    public enum FollowType : byte
    {
        /// <summary>
        /// Artist
        /// </summary>
        Artist,
        /// <summary>
        /// User
        /// </summary>
        User,
        /// <summary>
        /// Playlist
        /// </summary>
        Playlist
    }

    /// <summary>
    /// Set Type
    /// </summary>
    public enum SetType : byte
    {
        /// <summary>
        /// Add
        /// </summary>
        Add,
        /// <summary>
        /// Remove
        /// </summary>
        Remove
    }

    /// <summary>
    /// Favourite Type
    /// </summary>
    public enum FavouriteType : byte
    {
        /// <summary>
        /// Favourite Albums
        /// </summary>
        Album,
        /// <summary>
        /// Favourite Artists
        /// </summary>
        Artist,
        /// <summary>
        /// Favourite Tracks
        /// </summary>
        Track,
        /// <summary>
        /// Favourite Shows
        /// </summary>
        Show,
        /// <summary>
        /// Favourite Episodes
        /// </summary>
        Episode
    }

    /// <summary>
    /// Toggle Type
    /// </summary>
    public enum ToggleType : byte
    {
        /// <summary>
        /// Favourites
        /// </summary>
        Favourites,
        /// <summary>
        /// Follow
        /// </summary>
        Follow,
        /// <summary>
        /// Saved
        /// </summary>
        Saved
    }
}
