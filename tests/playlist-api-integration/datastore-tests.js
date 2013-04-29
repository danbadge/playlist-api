var datastore = require('../.././store');

exports.datastoreTest = {
    Given_I_add_an_object_then_it_can_be_retrieve_it: function (test) {
        var count = datastore.count();
        var objectToAdd = { 'key': 'value5' };
        datastore.set('hello', objectToAdd);

        var objectRetrieved = datastore.get('hello');

        test.equal(objectRetrieved, objectToAdd);
        test.done();
    },

    Given_I_add_several_objects_then_the_count_should_increase: function (test) {
        var count = datastore.count();
        datastore.set('hello1', { 'key': 'value' });
        datastore.set('hello2', { 'key': 'value' });

        test.equal(count + 2, datastore.count(), 'count is ' + datastore.count());
        test.done();
    }
};