Feature: AddingATrackToAnEmptyPlaylist
	As a fan of music
	I want to add a song to my playlist
	So that I can listen to it now

Scenario: Add a track to an empty playlist
	Given I have a empty playlist
	When I add a track to the playlist
	Then that track should be at the top of my playlist
