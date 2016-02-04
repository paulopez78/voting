using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace voting.api.model
{
    public static class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<VotingContext>();

            context.AddRange(
              new Poll
              {
                  Id = 1,
                  Name = "Language",
                  Description = "Programming language",
                  VoteOptions = new List<VoteOption>()
                  {
                        new VoteOption
                        {
                          Id = 1,
                          Name = "C#"
                        },
                        new VoteOption
                        {
                          Id = 2,
                          Name = "JS"
                        }
                  }
              },
              new Poll
              {
                  Id = 2,
                  Name = "Profile",
                  Description = "IT skills profile",
                  VoteOptions = new List<VoteOption>()
                  {
                        new VoteOption
                        {
                          Id = 3,
                          Name = "Dev"
                        },
                        new VoteOption
                        {
                          Id = 4,
                          Name = "Ops"
                        }
                  }
              }
            );

            context.SaveChanges();
        }
    }
}
