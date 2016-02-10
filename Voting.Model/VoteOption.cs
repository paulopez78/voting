using System;

namespace Voting.Model
{
    public class VoteOption
    {
        public VoteOption()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Votes { get; set; }
    }
}
