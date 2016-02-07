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

        Task<Poll> GetActive();

        Task<Poll> Get(string id);

        Task Remove(string id);

        Task SaveOrUpdate(Poll poll);

        Task Activate(string id);
    }
}
