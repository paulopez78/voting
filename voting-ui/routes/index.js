var express = require('express');
var router = express.Router();
var api = require("./apiclient")

router.get('/', function(req, res, next) {
  api.getActive(function(active){
    res.render('index',
    { title: 'Polls',
      model:{
        name: active.Name,
        option1:
        {
          id: active.VoteOptions[0].Id,
          pollid: active.Id,
          name : active.VoteOptions[0].Name,
          votes: active.VoteOptions[0].Votes
        },
        option2:
        {
          id:active.VoteOptions[1].Id,
          pollid: active.Id,
          name : active.VoteOptions[1].Name,
          votes : active.VoteOptions[1].Votes
        }
      }
    });
  });
});

module.exports = router;
