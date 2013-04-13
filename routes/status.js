exports.status = function (request, response) {
    res.header('Content-Type', 'text/plain');
    res.status(200).send('OK');
};