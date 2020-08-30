namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Actions Response
    /// </summary>
    public class ActionsResponse
    {
        #region Response Properties
        /// <summary>
        /// Update the user interface based on which playback actions are disallowed within the current context
        /// </summary>
        public DisallowsResponse Disallows { get; set; }
        #endregion Response Properties

        #region Extended Properties
        /// <summary>
        /// Update the user interface based on which playback actions are allowed within the current context
        /// </summary>
        public AllowsResponse Allows { get; set; }
        #endregion Extended Properties
    }
}
