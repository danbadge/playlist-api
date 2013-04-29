# playlist-api

Lightweight Playlisting API built using Node JS and Express.

Uses https://github.com/felixge/node-dirty as in memory store.

## Endpoints

###POST /playlist/create
\nBODY
``` javascript
{
"name": "My first playlist"
}
```

RESPONSE
``` javascript
{
"id": "1234",
"name": "My first playlist",
"tracks": {}
}
```

###POST /playlist/1234/queue/5678
RESPONSE
``` javascript
{
"id": "5678"
}
```

###GET /playlist/1234
RESPONSE
``` javascript
{
"id": "1234",
"name": "My first playlist",
"tracks": { "id": "5678" }
}
```

