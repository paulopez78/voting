var express = require('express');
var router = express.Router();
var api = require("./apiclient")

router.get('/', function(req, res, next) {

  var port = process.env.API_PORT_5000_TCP_PORT || "5000"
  var url = process.env.API_PORT_5000_TCP_ADDR || "localhost"
  api.getPolls(url, port, function(polls){
    res.render('index', { title: 'Polls', model: polls});
  });
});

module.exports = router;
