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
    public class VoteController
    {
      private readonly VotingContext _votingContext;

        public VoteController(VotingContext votingContext)
        {
            _votingContext = votingContext;
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]Vote vote)
        {
            var voteOption = await _votingContext
                                  .VoteOptions
                                  .FirstOrDefaultAsync(x => x.Id == vote.VoteOption);

            ++voteOption.Votes;
            await _votingContext.SaveChangesAsync();
        }
    }
}
