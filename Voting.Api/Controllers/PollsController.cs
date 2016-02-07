using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            _votingContext = votingContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Poll>> Get()
        {
            return await _votingContext.Polls.Include(x => x.VoteOptions).ToListAsync();
        }

        [HttpGet("Active")]
        public async Task<Poll> GetActive()
        {
            return await _votingContext.Polls
                        .Include(x => x.VoteOptions)
                        .FirstOrDefaultAsync(x => x.Active);
        }

        [HttpGet("{id}")]
        public async Task<Poll> Get(string id)
        {
            return await _votingContext.Polls
                        .Include(x => x.VoteOptions)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task Post([FromBody]Poll poll)
        {
            _votingContext.Add(poll);
            await _votingContext.SaveChangesAsync();
        }

        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody]Poll poll)
        {
            var existingPoll = await _votingContext.Polls.FirstOrDefaultAsync(x => x.Id == id);
            _votingContext.Remove(existingPoll);
            _votingContext.Add(poll);
            await _votingContext.SaveChangesAsync();
        }

        [HttpPut("{id}/Vote")]
        public async Task Vote(string id, [FromBody]Vote vote)
        {
            var voteOption = await _votingContext
                                  .VoteOptions
                                  .FirstOrDefaultAsync(x => x.Id == vote.VoteOption);

            ++voteOption.Votes;
            await _votingContext.SaveChangesAsync();
        }

        [HttpPut("{id}/Activate")]
        public async Task Activate(string id)
        {
            var existingPoll = await _votingContext.Polls.FirstOrDefaultAsync(x => x.Id == id);
            await _votingContext.Polls.ForEachAsync(x => x.Deactivate());
            existingPoll.Activate();
            await _votingContext.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            var poll = await _votingContext.Polls.FirstOrDefaultAsync(x => x.Id == id);
            _votingContext.Remove(poll);
            await _votingContext.SaveChangesAsync();
        }
    }
}
