using System.Configuration;
using PlaylistApi.Tests.ApiWrapper.Schema;

namespace PlaylistApi.Tests.ApiWrapper
{
    public class QueueTrackBuilder
    {
        private string _trackId;
        private string _playlistId;
	    private readonly string _playlistApiUri;
	    private readonly RestRequestWrapper _restRequestWrapper;
	    private readonly QueueTrackRequest _queueTrackRequest;

	    public QueueTrackBuilder()
        {
            _playlistApiUri = ConfigurationManager.AppSettings["PlaylistApiUri"];
	        _restRequestWrapper = new RestRequestWrapper();
		    _queueTrackRequest = new QueueTrackRequest();
        }

        public QueueTrackBuilder AddTrackId(string trackId)
        {
            _trackId = trackId;
            return this;
        }

	    public QueueTrackBuilder AddTrackName(string trackName)
	    {
		    _queueTrackRequest.trackName = trackName;
		    return this;
	    }

	    public QueueTrackBuilder AddArtistName(string artistName)
	    {
			_queueTrackRequest.artistName = artistName;
			return this;
	    }

	    public QueueTrackBuilder AddImageUri(string imageUri)
		{
			_queueTrackRequest.imageUri = imageUri;
			return this;
		}

	    public QueueTrackBuilder ToPlaylist(string playlistId)
	    {
		    _playlistId = playlistId;
		    return this;
	    }

	    public Track Please()
        {
            var uri = string.Format(_playlistApiUri + "/playlist/{0}/track/{1}", _playlistId, _trackId);
		    return _restRequestWrapper.PostRequest<Track>(_queueTrackRequest, uri);
        }
    }

	public class QueueTrackRequest : IRequestBody
	{
		public string imageUri { get; set; }

		public string artistName { get; set; }

		public string trackName { get; set; }
	}
}