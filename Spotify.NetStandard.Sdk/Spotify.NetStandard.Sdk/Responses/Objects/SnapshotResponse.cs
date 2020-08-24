namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Snapshot Response
    /// </summary>
    public class SnapshotResponse : StatusResponse
    {
        /// <summary>
        /// Can be used to identify playlist version in future requests
        /// </summary>
        public string SnapshotId { get; set; }
    }
}
