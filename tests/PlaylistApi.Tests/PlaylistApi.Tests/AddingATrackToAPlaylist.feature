Feature: AddingATrackToAPlaylist
	As a fan of music
	I want to add a song to my playlist
	So that I can listen to it now

Scenario: Adding a track to an empty playlist
	Given I have a empty playlist
	When I add a track to the playlist
	Then that track should be at the top of my playlist

Scenario: The last track added always appears at the bottom of the playlist
	Given I have a empty playlist
	When I add a track to the playlist
	And I add a track to the playlist
	And I add a track to the playlist
	And I add a track to the playlist
	Then the last track I added should be at the bottom of the playlist
	
Scenario: Adding a track to a playlist then return all the necessary data
	Given I have a empty playlist
	And I want to add a new track
	And the track is Reckoner by Radiohead
	And the image url is located at http://cdn.7static.com/static/img/sleeveart/00/001/888/0000188863_500.jpg
	When I add this track to the playlist
	Then the track is Reckoner by Radiohead
	And the image url is located at http://cdn.7static.com/static/img/sleeveart/00/001/888/0000188863_500.jpg