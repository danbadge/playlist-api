using System.Configuration;
using RestSharp;

namespace PlaylistApi.Tests
{
    public class GetPlaylistBuilder
    {
        private string _playlistId;
        private readonly string _playlistApiUri;

        public GetPlaylistBuilder()
        {
            _playlistApiUri = ConfigurationManager.AppSettings["PlaylistApiUri"];
        }

        public GetPlaylistBuilder WithPlaylist(string playlistId)
        {
            _playlistId = playlistId;
            return this;
        }

        public Playlist Please()
        {
            var uri = string.Format(_playlistApiUri + "/playlist/{0}", _playlistId);
            var client = new RestClient(uri);
            var request = new RestRequest();
            var response = client.Execute<Playlist>(request);
            return response.Data;
        }
    }
}