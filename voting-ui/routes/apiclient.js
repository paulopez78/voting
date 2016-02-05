var http = require("http");
var api = {
    getPolls: function(url, port, cb){
      console.log(url);
      var options = {
        host: url,
        port: port,
        path: '/polls',
        method: 'GET'
      };

      http.request(options, function(res) {
        console.log('STATUS: ' + res.statusCode);
        console.log('HEADERS: ' + JSON.stringify(res.headers));
        res.setEncoding('utf8');
        res.on('data', function (chunk) {
          console.log('BODY: ' + chunk);
          cb(JSON.parse(chunk))
        });
      }).end();
    },

    vote: function(url, cb){

    }
}

module.exports = api;
