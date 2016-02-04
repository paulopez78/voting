using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

using voting.admin.ViewModels;

namespace voting.admin.Controllers
{
    public class PollController : Controller
    {
        public IActionResult Index()
        {
            var model = new List<PollViewModel>(){
              new PollViewModel
              {
                Id = 1,
                Name = "Language",
                Description = "Your favourite language"
              }
            };

            // rest api call
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = new PollViewModel
            {
                Id = 1,
                Name = "Language",
                Description = "Your favourite language"
            };
            // rest api call
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public void Create([FromBody] PollViewModel poll)
        {

        }

        [HttpPost]
        public void Remove(int id)
        {

        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
