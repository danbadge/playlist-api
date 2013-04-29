using System;
using NUnit.Framework;
using PlaylistApi.Tests.ApiWrapper;
using PlaylistApi.Tests.ApiWrapper.Schema;
using TechTalk.SpecFlow;

namespace PlaylistApi.Tests
{
    [Binding]
    public class CreatePlaylistSteps
    {
	    private CreatePlaylistBuilder _playlistBuilder;
	    private Playlist _playlist;
	    private string _playlistName;

	    [Given(@"I want to create a playlist")]
        public void GivenIWantToCreateAPlaylist()
	    {
		    _playlistBuilder = new CreatePlaylistBuilder();
	    }

	    [Given(@"I name the playlist (.*)")]
        public void GivenINameThePlaylist(string playlistName)
	    {
		    _playlistName = playlistName;
			_playlistBuilder.WithAName(playlistName);
	    }

	    [When(@"I create my playlist")]
        public void WhenICreateMyPlaylist()
        {
	        _playlist = _playlistBuilder.Please();
        }

	    [Then(@"it returns the correct name")]
        public void ThenItReturnsTheCorrectName()
	    {
		    Assert.That(_playlist.Name, Is.EqualTo(_playlistName));
	    }
    }
}
