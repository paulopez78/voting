using Microsoft.Data.Entity;

namespace voting.api.model
{
    public class VotingContext : DbContext
    {
        public DbSet<Poll> Polls { get; set; }

        public VotingContext()
        { 
        }
    }
}
