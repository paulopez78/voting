var http = require("http");

var port = process.env.API_PORT_5000_TCP_PORT || "5000"
var url = process.env.API_PORT_5000_TCP_ADDR || "localhost"

var api = {
    getActive: function(cb){
      var options = {
        host: url,
        port: port,
        path: '/polls/active',
        method: 'GET'
      };

      http.request(options, function(res) {
        res.setEncoding('utf8');
        res.on('data', function (chunk) {
          cb(JSON.parse(chunk))
        });
      }).end();
    },

    vote: function(option, cb){
      var options = {
          hostname: url,
            port: port,
            path: '/polls/' + option.pollid + '/vote',
            method: 'PUT',
            headers: {'Content-Type': 'application/json'}
          };

      console.log(options)
      var req = http.request(options, function(res) {
        res.setEncoding('utf8');
        res.on('data', function (data) {
        })
        res.on('end', function () {
          cb();
        })
      });

      req.write(JSON.stringify({VoteOption:option.id}));
      req.end();
    }
  }

module.exports = api;
