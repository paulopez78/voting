using System;
using System.Collections.Generic;

namespace Voting.Model
{
    public class Poll
    {
        public Poll()
        {
            VoteOptions = new List<VoteOption>();
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<VoteOption> VoteOptions { get; set; }
    }
}
