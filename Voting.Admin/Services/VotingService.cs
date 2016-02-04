using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Voting.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.OptionsModel;

namespace Voting.Admin.Services
{
    public class VotingService : IVotingService
    {
        private readonly VotingApiOptions _apiOptions;
        private readonly ILogger<VotingService> _logger;
        public VotingService(IOptions<VotingApiOptions> apiOptions, ILogger<VotingService> logger)
        {
            this._apiOptions = apiOptions.Value;
            this._logger = logger;
        }

        public async Task<IEnumerable<Poll>> Get()
        {
            var json = await GetPoll();
            return JsonConvert.DeserializeObject<IEnumerable<Poll>>(json);
        }

        public async Task<Poll> Get(int id)
        {
            var json = await GetPoll  (id);
            return JsonConvert.DeserializeObject<Poll>(json);
        }

        public async Task Remove(int id)
        {
            await Task.FromResult(true);
        }

        public async Task SaveOrUpdate(Poll poll)
        {
            await Create(poll);
        }

        private async Task<string> GetPoll(int? id = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiOptions.Url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var request = id.HasValue ? $"/polls/{id.Value}" : "/polls";
                _logger.LogInformation($"{_apiOptions.Url}{request}");
                var response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        private async Task Create(Poll poll)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(poll);
                client.BaseAddress = new Uri(_apiOptions.Url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var request = "/polls";
                _logger.LogInformation($"{_apiOptions.Url}{request}");
                _logger.LogInformation($"{json}");
                var response = await client.PostAsync(request,
                                                        new StringContent(json,
                                                        System.Text.Encoding.UTF8,"application/json"));

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception();
                }
            }
        }
    }
}
