using System;
using System.Collections.Generic;

namespace Voting.Model
{
    public class Poll
    {
        public Poll()
        {
            VoteOptions = new List<VoteOption>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public List<VoteOption> VoteOptions { get; set; }

        public void Activate()
        {
            this.Active = true;
        }

        public void Deactivate()
        {
            this.Active = false;
        }

    }
}
