var express = require('express');
var router = express.Router();
var api = require("./apiclient")

router.get('/', function(req, res, next) {
  api.getPolls(function(polls){
    res.render('index', { title: 'Polls', model: polls[0]});
  });
});

module.exports = router;
