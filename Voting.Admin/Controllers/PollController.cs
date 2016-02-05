using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;

using Voting.Model;
using Voting.Admin.Services;

namespace Voting.Admin.Controllers
{
    public class PollController : Controller
    {
        private readonly IVotingService _votingService;
        public PollController(IVotingService votingservice)
        {
            _votingService = votingservice;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _votingService.Get();
            return View(model);
        }

        public async Task<IActionResult> Details(string id)
        {
            var model = await _votingService.Get(id);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Poll poll)
        {
            await _votingService.SaveOrUpdate(poll);
            return RedirectToAction(nameof(PollController.Index));
        }

        [HttpPost]
        public async Task<IActionResult> Remove(string id)
        {
            await _votingService.Remove(id);
            return RedirectToAction(nameof(PollController.Index));
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
