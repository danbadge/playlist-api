using System.Collections.Generic;

namespace PlaylistApi.Tests.ApiWrapper.Schema
{
    public class Playlist
    {
        public string Id { get; set; }

        public List<Track> Tracks { get; set; }

	    public string Name { get; set; }
    }
}