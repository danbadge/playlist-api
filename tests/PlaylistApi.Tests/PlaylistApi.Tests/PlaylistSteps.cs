using System;
using System.Globalization;
using System.Linq;
using NUnit.Framework;
using PlaylistApi.Tests.ApiWrapper;
using PlaylistApi.Tests.ApiWrapper.Schema;
using TechTalk.SpecFlow;

namespace PlaylistApi.Tests
{
    [Binding]
    public class PlaylistSteps
    {
        private Playlist _playlist;
	    private string _trackId;
	    private QueueTrackBuilder _queueTrack;
	    private Track _track;

	    [Given(@"I have a empty playlist")]
        public void GivenIHaveAEmptyPlaylist()
        {
            _playlist = new CreatePlaylistBuilder().Please();
            Assert.That(_playlist, Is.Not.Null);
            Assert.That(_playlist.Id, Is.Not.EqualTo("0"));
        }

        [When(@"I add a track to the playlist")]
        public void WhenIAddATrackToThePlaylist()
        {
	        var rand = new Random();
	        _trackId = rand.Next(1, 1000).ToString(CultureInfo.InvariantCulture);

            new QueueTrackBuilder()
				.AddTrackId(_trackId)
                .ToPlaylist(_playlist.Id)
                .Please();
        }
        
        [Then(@"that track should be at the top of my playlist")]
        public void ThenThatTrackShouldBeAtTheTopOfMyPlaylist()
        {
            var playlist = new GetPlaylistBuilder()
                .WithPlaylist(_playlist.Id)
                .Please();

			Assert.That(playlist.Tracks.First().Id, Is.EqualTo(_trackId));
        }

	    [Then(@"the last track I added should be at the bottom of the playlist")]
	    public void ThenTheLastTrackIAddedShouldBeAtTheBottomOfThePlaylist()
	    {
		    var playlist = new GetPlaylistBuilder()
			    .WithPlaylist(_playlist.Id)
			    .Please();

		    Assert.That(playlist.Tracks.Last().Id, Is.EqualTo(_trackId));
	    }

		[Given(@"I want to add a new track")]
		public void GivenIWantToAddANewTrack()
		{
			var rand = new Random();
			_trackId = rand.Next(1, 1000).ToString(CultureInfo.InvariantCulture);

			_queueTrack = new QueueTrackBuilder()
				.AddTrackId(_trackId)
				.ToPlaylist(_playlist.Id);
		}

		[Given(@"the track is (.*) by (.*)")]
		public void GivenTheTrackIs(string trackName, string artistName)
		{
			_queueTrack.AddTrackName(trackName)
				.AddArtistName(artistName);
		}

		[Given(@"the image url is located at (.*)")]
		public void GivenIHaveAnImageUrlLocatedAt(string imageUri)
		{
			_queueTrack.AddImageUri(imageUri);
		}

		[When(@"I add this track to the playlist")]
		public void WhenIAddThisTrackToThePlaylist()
		{
			_track = _queueTrack.Please();
		}

	    [Then(@"the track is (.*) by (.*)")]
	    public void ThenTheTrackIs(string trackName, string artistName)
	    {
		    Assert.That(_track.TrackName, Is.EqualTo(trackName));
		    Assert.That(_track.TrackName, Is.EqualTo(trackName));
	    }

	    [Then(@"the image url is located at (.*)")]
		public void ThenTheImageUrlIsLocatedAt(string imageUri)
		{
			Assert.That(_track.ImageUri, Is.EqualTo(imageUri));
		}

    }
}
