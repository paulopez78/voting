using System.Collections.Generic;

namespace voting.api.model
{
    public class Poll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<VoteOption> VoteOptions { get; set; }
    }
}
