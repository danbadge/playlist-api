using System;
using System.Collections.Generic;
using System.Linq;
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
		private readonly List<string> _playlistIds = new List<string>();

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

		[Given(@"I create a playlist")]
		[When(@"I create a playlist")]
		public void GivenICreateAPlaylist()
		{
			_playlistBuilder = new CreatePlaylistBuilder();
			_playlist = _playlistBuilder.Please();
			_playlistIds.Add(_playlist.Id);
		}

		[Then(@"the id has increased")]
		public void ThenTheIdHasIncreased()
		{
			Assert.That(_playlist.Id, Is.GreaterThan(_playlistIds.First()));
		}
    }
}
