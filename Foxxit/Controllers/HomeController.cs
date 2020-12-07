using System.Collections.Generic;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Models.ViewModels;
using Foxxit.Services;
using Microsoft.AspNetCore.Mvc;

namespace Foxxit.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly SubredditService subredditService;
        public HomeController(SubredditService subredditService)
        {
            this.subredditService = subredditService;
        }

        public HomeController()
        {
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            return View("index");
        }

        [HttpGet("subreddit")]
        public async Task<IActionResult> Subreddit(long subredId)
        {
            var subreddit = await subredditService.FindById(subredId);
            var viewModel = new SubredditViewModel() { Subreddit = subreddit };
            return View(viewModel);
        }
    }
}