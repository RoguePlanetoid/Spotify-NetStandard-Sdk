namespace Spotify.NetStandard.Sdk.Internal
{
    /// <summary>
    /// Extension Methods for Scope Class to allow fluent additions of scopes for the API
    /// </summary>
    internal static class AuthenticationScopeExtensions
    {
        /// <summary>
        /// Extension method to add all scopes with "read" in their scope string
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static AuthenticationScopeRequest AddReadAllAccess(this AuthenticationScopeRequest scope)
        {
            scope.PlaylistReadCollaborative = true;
            scope.PlaylistReadPrivate = true;
            scope.ConnectReadCurrentlyPlaying = true;
            scope.ConnectReadPlaybackState = true;
            scope.ListeningTopRead = true;
            scope.PlaybackPositionRead = true;
            scope.ListeningRecentlyPlayed = true;
            scope.UserReadEmail = true;
            scope.UserReadPrivate = true;
            scope.FollowRead = true;
            scope.LibraryRead = true;
            return scope;
        }

        /// <summary>
        /// Extension method to add all scopes with "modify" in their scope string
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static AuthenticationScopeRequest AddModifyAllAccess(this AuthenticationScopeRequest scope)
        {
            scope.PlaylistModifyPrivate = true;
            scope.PlaylistModifyPublic = true;
            scope.ConnectModifyPlaybackState = true;
            scope.FollowModify = true;
            scope.LibraryModify = true;
            return scope;
        }

        /// <summary>
        /// Adds all scopes to a scope within the Playlist section of the defined Scopes
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static AuthenticationScopeRequest AddPlaylistAll(this AuthenticationScopeRequest scope)
        {
            scope.PlaylistReadPrivate = true;
            scope.PlaylistModifyPrivate = true;
            scope.PlaylistModifyPublic = true;
            scope.PlaylistReadCollaborative = true;
            return scope;
        }

        /// <summary>
        /// Adds all scopes to a scope within the Spotify Connect section of the defined Scopes
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static AuthenticationScopeRequest AddSpotifyConnectAll(this AuthenticationScopeRequest scope)
        {
            scope.ConnectModifyPlaybackState = true;
            scope.ConnectReadCurrentlyPlaying = true;
            scope.ConnectReadPlaybackState = true;
            return scope;
        }

        /// <summary>
        /// Adds all scopes to a scope within the Listening History section of the defined Scopes
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static AuthenticationScopeRequest AddListeningHistoryAll(this AuthenticationScopeRequest scope)
        {
            scope.ListeningTopRead = true;
            scope.PlaybackPositionRead = true;
            scope.ListeningRecentlyPlayed = true;
            return scope;
        }

        /// <summary>
        /// Adds all scopes to a scope within the Playback section of the defined Scopes
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static AuthenticationScopeRequest AddPlaybackAll(this AuthenticationScopeRequest scope)
        {
            scope.PlaybackAppRemoteControl = true;
            scope.PlaybackStreaming = true;
            return scope;
        }

        /// <summary>
        /// Adds all scopes to a scope within the Images section of the defined Scopes
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static AuthenticationScopeRequest AddImageAll(this AuthenticationScopeRequest scope)
        {
            scope.ImageUserGeneratedContentUpload = true;
            return scope;
        }

        /// <summary>
        /// Adds all scopes to a scope within the Users section of the defined Scopes
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static AuthenticationScopeRequest AddUsersAll(this AuthenticationScopeRequest scope)
        {
            scope.UserReadEmail = true;
            scope.UserReadPrivate = true;
            return scope;
        }

        /// <summary>
        /// Adds all scopes to a scope within the Follow section of the defined Scopes
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static AuthenticationScopeRequest AddFollowAll(this AuthenticationScopeRequest scope)
        {
            scope.FollowRead = true;
            scope.FollowModify = true;

            return scope;
        }

        /// <summary>
        /// Adds all scopes to a scope within the Library section of the defined Scopes
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static AuthenticationScopeRequest AddLibraryAll(this AuthenticationScopeRequest scope)
        {
            scope.LibraryModify = true;
            scope.LibraryRead = true;

            return scope;
        }
    }
}
