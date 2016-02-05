using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc;
using Voting.Model;
using Voting.Api.Model;

namespace Voting.Api.Controllers
{
    [Route("[controller]")]
    public class PollsController
    {
        private readonly VotingContext _votingContext;

        public PollsController(VotingContext votingContext)
        {
            this._votingContext = votingContext;
        }

        [HttpGet]
        public IEnumerable<Poll> Get()
        {
            return this._votingContext.Polls.Include(x => x.VoteOptions);
        }

        [HttpGet("{id}")]
        public Poll Get(string id)
        {
            return this._votingContext.Polls.Include(x => x.VoteOptions).FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public void Post([FromBody]Poll poll)
        {
            _votingContext.Add(poll);
            _votingContext.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Poll poll)
        {
            var existingPoll = this._votingContext.Polls.FirstOrDefault(x => x.Id == id);
            _votingContext.Remove(existingPoll);
            _votingContext.Add(poll);
            _votingContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var poll = this._votingContext.Polls.FirstOrDefault(x => x.Id == id);
            _votingContext.Remove(poll);
            _votingContext.SaveChanges();
        }
    }
}
