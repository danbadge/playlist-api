using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace PlaylistApi.Tests
{
    [Binding]
    public class PlaylistSteps
    {
        private Playlist _playlist;
        private const string TrackId = "23684223";

        [Given(@"I have a empty playlist")]
        public void GivenIHaveAEmptyPlaylist()
        {
            _playlist = new CreatePlaylistBuilder().Please();
            Assert.That(_playlist, Is.Not.Null);
            Assert.That(_playlist.Id, Is.GreaterThan(0));
        }

        [When(@"I add a track to the playlist")]
        public void WhenIAddATrackToThePlaylist()
        {
            new QueueTrackBuilder()
                .AddTrack(TrackId)
                .ToPlaylist(_playlist.Id)
                .Please();
        }
        
        [Then(@"that track should be at the top of my playlist")]
        public void ThenThatTrackShouldBeAtTheTopOfMyPlaylist()
        {
            var playlist = new GetPlaylistBuilder()
                .WithPlaylist(_playlist.Id)
                .Please();

            Assert.That(playlist.Tracks.First().Id, Is.EqualTo(TrackId));
        }
    }
}
