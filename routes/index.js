var playlists = require('.././store');

exports.status = function (request, response) {
    response.header('Content-Type', 'text/plain')
    response.status(200).send('OK')
};

exports.playlist = {
    create: function (request, response) {
        var playlistId = 1;
        if (playlists.count() > 0)
            playlistId += playlists.count();

        var newPlaylist = {
            id: playlistId,
            name: request.body.name,
            owner: request.body.owner,
            tracks: new Array()
        };

        playlists.set(playlistId, newPlaylist);

        response.json(newPlaylist);
    },

    show: function (request, response) {
        var playlist = playlists.get(request.params.id);
        if (playlist == undefined)
            throw new Error('Playlist could not be found');

        response.json(playlist);
    },

    queue: function (request, response) {
        var playlist = playlists.get(request.params.id);
        if (playlist == undefined)
            throw new Error('Playlist could not be found');

        var track = {
            id: request.params.trackId
        };

        playlist.tracks.push(track);

        response.json(track);
    }
};