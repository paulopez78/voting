using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc;
using voting.api.model;

namespace voting.api.controllers
{
    [Route("[controller]")]
    public class PollsController
    {
        private readonly VotingContext _votingContext;

        public PollsController(VotingContext votingContext)
        {
            this._votingContext = votingContext;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Poll> Get()
        {
            return this._votingContext.Polls.Include(x => x.VoteOptions);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Poll Get(int id)
        {
            return this._votingContext.Polls
                          .Include(x => x.VoteOptions)
                          .FirstOrDefault(x => x.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
