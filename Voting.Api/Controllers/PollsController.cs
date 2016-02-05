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

        [HttpGet("{id}")]
        public async Task<Poll> Get(string id)
        {
            return await _votingContext.Polls
                        .Include(x => x.VoteOptions)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public void Post([FromBody]Poll poll)
        {
            _votingContext.Add(poll);
            _votingContext.SaveChanges();
        }

        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody]Poll poll)
        {
            var existingPoll = await _votingContext.Polls.FirstOrDefaultAsync(x => x.Id == id);
            _votingContext.Remove(existingPoll);
            _votingContext.Add(poll);
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
