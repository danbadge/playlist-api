# playlist-api

Lightweight Playlisting API built using Node JS and Express.

Uses https://github.com/felixge/node-dirty as in memory store.

## Endpoints

### Create Playlist
```bash
POST /playlist/create
Body:
{ "name": "My first playlist" }
```

RESPONSE
``` javascript
{
	"id": "1234",
	"name": "My first playlist",
	"tracks": {}
}
```

### Add track to playlist
request
```bash
POST /playlist/:id/queue/:trackId
````
Response
``` javascript
{ "id": "5678" }
```

###
Request
```bash
GET /playlist/1234
````
Response
``` javascript
{
	"id": "1234",
	"name": "My first playlist",
	"tracks": { "id": "5678" }
}
```

