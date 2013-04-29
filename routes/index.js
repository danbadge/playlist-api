exports.status = function (request, response) {
    response.header('Content-Type', 'text/plain')
    response.status(200).send('OK')
};

var playlists = new Array();

exports.playlist = {
    create: function (request, response) {
        var playlistId = 1;
        if (playlists.length > 0)
            playlistId += playlists.length;

        var newPlaylist = {
            name: request.body.name,
            id: playlistId,
            owner: request.body.owner,
            tracks: new Array()
        };

        playlists.push(newPlaylist);

        response.json(newPlaylist);
    },

    show: function (request, response) {
        var playlist = playlists[request.params.id - 1];
        if (playlist == undefined)
            throw new Error('Playlist could not be found');

        response.json(playlist);
    },

    queue: function (request, response) {
        var playlist = playlists[request.params.id - 1];
        if (playlist == undefined)
            throw new Error('Playlist could not be found');

        var track = {
            id: request.params.trackId
        };

        playlist.tracks.push(track);

        response.json(track);
    }
};