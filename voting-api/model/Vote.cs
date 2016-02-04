namespace voting.api.model
{
    public class Vote
    {
        public string Id { get; set; }
        public int VoteOption { get; set; }
        public int Poll { get; set; }
    }
}
