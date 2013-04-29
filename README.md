# playlist-api

Lightweight Playlisting API built using Node JS and Express.

Uses https://github.com/felixge/node-dirty as in memory store.

## Endpoints

POST /playlist/create
BODY
``` javascript
{
"name": "My first playlist"
}

RESPONSE
``` javascript
{
"id": "1234",
"name": "My first playlist",
"tracks": [],
}

