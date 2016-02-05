using System;

namespace Voting.Model
{
    public class VoteOption
    {
        public VoteOption()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}
