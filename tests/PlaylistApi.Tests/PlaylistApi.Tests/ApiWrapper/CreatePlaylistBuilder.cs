using System.Configuration;
using PlaylistApi.Tests.ApiWrapper.Schema;

namespace PlaylistApi.Tests.ApiWrapper
{
	public class CreatePlaylistBuilder
    {
        private readonly string _createPlaylistUri;
	    private readonly RestRequestWrapper _restRequestWrapper;
		private string _name;

		public CreatePlaylistBuilder()
        {
            var playlistApiUri = ConfigurationManager.AppSettings["PlaylistApiUri"];
            _createPlaylistUri = playlistApiUri + "/playlist/create";
			_restRequestWrapper = new RestRequestWrapper();
        }

		public CreatePlaylistBuilder WithAName(string playlistName)
		{
			_name = playlistName;
			return this;
		}
        
        public Playlist Please()
        {
	        var playlistRequest = new PlaylistRequest
                {
                    owner = "Daniel",
                    name = _name
                };
	        return _restRequestWrapper.PostRequest<Playlist>(playlistRequest, _createPlaylistUri);
        }
    }
}