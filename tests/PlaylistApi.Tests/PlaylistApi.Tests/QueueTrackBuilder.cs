using System.Configuration;
using RestSharp;

namespace PlaylistApi.Tests
{
    public class QueueTrackBuilder
    {
        private string _trackId;
        private string _playlistId;
        private readonly string _playlistApiUri;

        public QueueTrackBuilder()
        {
            _playlistApiUri = ConfigurationManager.AppSettings["PlaylistApiUri"];
        }

        public QueueTrackBuilder AddTrack(string trackId)
        {
            _trackId = trackId;
            return this;
        }

        public QueueTrackBuilder ToPlaylist(string playlistId)
        {
            _playlistId = playlistId;
            return this;
        }

        public Track Please()
        {
            var uri = string.Format(_playlistApiUri + "/playlist/{0}/queue/{1}", _playlistId, _trackId);
            var client = new RestClient(uri);
            var request = new RestRequest();
            var response = client.ExecuteAsPost<Track>(request, "POST");
            return response.Data;
        }
    }
}