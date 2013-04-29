var dirty = require('dirty');
var db = dirty('playlist.db');

exports.count = function () {
    return db.length;
};

exports.get = function (key) {
    return db.get(key);
};

exports.set = function (key, playlist) {
    return db.set(key, playlist);
};