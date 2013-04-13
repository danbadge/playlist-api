exports.status = function (request, response) {
    response.header('Content-Type', 'text/plain')
    response.status(200).send('OK')
};