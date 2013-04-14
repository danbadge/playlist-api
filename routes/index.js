exports.status = function (request, response) {
    response.header('Content-Type', 'text/plain')
    response.status(200).send('OK')
};

var lastPlaylistId = 1;

exports.playlist = {
    create: function (request, response) {
        lastPlaylistId++;
        var playlist = {
            name: request.body.name,
            id: lastPlaylistId,
            owner: request.body.owner
        };

        response.json(playlist);
    }
};