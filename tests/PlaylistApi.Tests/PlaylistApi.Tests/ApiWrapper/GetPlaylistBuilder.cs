using System.Configuration;
using PlaylistApi.Tests.ApiWrapper.Schema;
using RestSharp;

namespace PlaylistApi.Tests.ApiWrapper
{
    public class GetPlaylistBuilder
    {
        private string _playlistId;
        private readonly string _playlistApiUri;
	    private readonly RestRequestWrapper _restRequestWrapper;

	    public GetPlaylistBuilder()
        {
            _playlistApiUri = ConfigurationManager.AppSettings["PlaylistApiUri"];
			_restRequestWrapper = new RestRequestWrapper();
        }

        public GetPlaylistBuilder WithPlaylist(string playlistId)
        {
            _playlistId = playlistId;
            return this;
        }

        public Playlist Please()
        {
            var uri = string.Format(_playlistApiUri + "/playlist/{0}", _playlistId);
			return _restRequestWrapper.GetRequest<Playlist>(uri);
        }
    }
}