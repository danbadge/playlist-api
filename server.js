
/**
 * Module dependencies.
 */

var express = require('express'),
routes = require('./routes');

var app = module.exports = express.createServer();

// Configuration

app.configure(function(){
  app.use(express.bodyParser());
  app.use(express.methodOverride());
  app.use(app.router);
});

app.configure('development', function(){
  app.use(express.errorHandler({ dumpExceptions: true, showStack: true }));
});

app.configure('production', function(){
  app.use(express.errorHandler());
});

// Routes
app.get('/status', routes.status);
app.post('/playlist/create', routes.playlist.create);
app.post('/playlist/:id/track/:trackId', routes.playlist.queue);
app.get('/playlist/:id', routes.playlist.show);

app.listen(process.env.PORT || 5000);
console.log("Express server listening on port %d in %s mode", app.address().port, app.settings.env);
