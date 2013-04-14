using System.Collections.Generic;

namespace PlaylistApi.Tests
{
    public class Playlist
    {
        public string Id { get; set; }

        public IList<Track> Tracks { get; set; }
    }
}