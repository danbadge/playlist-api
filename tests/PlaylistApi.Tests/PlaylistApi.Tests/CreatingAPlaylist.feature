Feature: CreatingAPlaylist
	
Scenario: Creating multiple playlists generates unique identifiers
	Given I create a playlist
	When I create a playlist
	Then the id has increased

Scenario: Creating a playlist with a name
	Given I want to create a playlist 
	And I name the playlist Daniel Super Cool Playlist
	When I create my playlist
	Then it returns the correct name
