var dirty = require('dirty');
var db = dirty('playlist.db');

exports.count = function () {
    var count = 0;
    db.forEach(function (key, value) {
        count++;
    });
    return count;
};

exports.get = function (key) {
    return db.get(key);
};

exports.set = function (key, playlist) {
    return db.set(key, playlist);
};