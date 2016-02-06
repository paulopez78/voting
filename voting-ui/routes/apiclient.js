var http = require("http");

var port = process.env.API_PORT_5000_TCP_PORT || "5000"
var url = process.env.API_PORT_5000_TCP_ADDR || "localhost"

var api = {
    getPolls: function(cb){
      var options = {
        host: url,
        port: port,
        path: '/polls/',
        method: 'GET'
      };

      http.request(options, function(res) {
        res.setEncoding('utf8');
        res.on('data', function (chunk) {
          cb(JSON.parse(chunk))
        });
      }).end();
    },

    vote: function(cb){
      var options = {
        host: url,
        port: port,
        path: '/vote/{id}',
        method: 'POST'
      };      
    }
}

module.exports = api;
