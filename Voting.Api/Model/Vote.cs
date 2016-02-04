namespace Voting.Api.Model
{
    public class Vote
    {
        public string Id { get; set; }
        public int VoteOption { get; set; }
        public int Poll { get; set; }
    }
}
