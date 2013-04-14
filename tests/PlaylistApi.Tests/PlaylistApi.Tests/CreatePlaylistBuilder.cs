using System.Configuration;
using RestSharp;

namespace PlaylistApi.Tests
{
    public class CreatePlaylistBuilder
    {
        private readonly string _createPlaylistUri;

        public CreatePlaylistBuilder()
        {
            var playlistApiUri = ConfigurationManager.AppSettings["PlaylistApiUri"];
            _createPlaylistUri = playlistApiUri + "/create";
        }
        
        public Playlist Please()
        {
            var client = new RestClient(_createPlaylistUri);
            var request = new RestRequest();
            var playlistRequest = new PlaylistRequest
                {
                    Owner = "Daniel",
                    Name = "Super Cool Playlist"
                };
            request.AddBody(playlistRequest);
            var response = client.ExecuteAsPost<Playlist>(request, "POST");
            return response.Data;
        }
    }

    public class PlaylistRequest
    {
        public string Owner { get; set; }

        public string Name { get; set; }
    }
}