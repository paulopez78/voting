var express = require('express');
var router = express.Router();
var api = require("./apiclient")

router.get('/', function(req, res, next) {
  api.getPolls(function(polls){
    res.render('index',
    { title: 'Polls',
      model:{
        name: polls[0].Name,
        option1:
        {
          id:polls[0].VoteOptions[0].Id,
          name : polls[0].VoteOptions[0].Name,
          votes: polls[0].VoteOptions[0].Votes
        },
        option2:
        {
          id:polls[0].VoteOptions[1].Id,
          name : polls[0].VoteOptions[1].Name,
          votes : polls[0].VoteOptions[1].Votes
        }
      }
    });
  });
});

module.exports = router;
