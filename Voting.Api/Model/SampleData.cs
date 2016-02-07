using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Voting.Model;

namespace Voting.Api.Model
{
    public static class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<VotingContext>();

            context.AddRange(
              new Poll
              {
                  Name = "Language",
                  Description = "Programming language",
                  Active = true,
                  VoteOptions = new List<VoteOption>()
                  {
                        new VoteOption
                        {
                          Name = "C#"
                        },
                        new VoteOption
                        {
                          Name = "JS"
                        }
                  }
              },
              new Poll
              {
                  Name = "Profile",
                  Description = "IT skills profile",
                  Active = false,
                  VoteOptions = new List<VoteOption>()
                  {
                        new VoteOption
                        {
                          Name = "Dev"
                        },
                        new VoteOption
                        {
                          Name = "Ops"
                        }
                  }
              }
            );

            context.SaveChanges();
        }
    }
}
