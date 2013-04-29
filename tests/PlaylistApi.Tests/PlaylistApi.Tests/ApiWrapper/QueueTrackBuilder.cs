using System.Configuration;
using PlaylistApi.Tests.ApiWrapper.Schema;
using RestSharp;

namespace PlaylistApi.Tests.ApiWrapper
{
    public class QueueTrackBuilder
    {
        private string _trackId;
        private string _playlistId;
        private readonly string _playlistApiUri;
	    private readonly RestRequestWrapper _restRequestWrapper;

	    public QueueTrackBuilder()
        {
            _playlistApiUri = ConfigurationManager.AppSettings["PlaylistApiUri"];
	        _restRequestWrapper = new RestRequestWrapper();
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
	        return _restRequestWrapper.PostRequest<Track>(uri);
        }
    }
}