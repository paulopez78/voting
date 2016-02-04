using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voting.Model;

namespace Voting.Admin.Services
{
    public interface IVotingService
    {
        Task<IEnumerable<Poll>> Get();

        Task<Poll> Get(int id);

        Task Remove(int id);

        Task SaveOrUpdate(Poll poll);
    }
}
