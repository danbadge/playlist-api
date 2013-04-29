# playlist-api

Lightweight Playlisting API built using Node JS and Express.

Uses https://github.com/felixge/node-dirty as in memory store.

## Endpoints

### Create Playlist
Request
```bash
POST /playlist/create
Body:
{ "name": "My first playlist" }
```

Response
``` bash
{
	"id": "1234",
	"name": "My first playlist",
	"tracks": {}
}
```

### Add Track to Playlist
Request
```bash
POST /playlist/:id/queue/:trackId
````
Response
``` bash
{ "id": "5678" }
```

### Get Playlist
Request
```bash
GET /playlist/1234
````
Response
``` bash
{
	"id": "1234",
	"name": "My first playlist",
	"tracks": { "id": "5678" }
}
```

