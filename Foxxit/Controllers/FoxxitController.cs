using System.Threading.Tasks;
using Foxxit.Models.ViewModels;
using Foxxit.Services;
using Microsoft.AspNetCore.Mvc;

namespace Foxxit.Controllers
{
    public class FoxxitController : Controller
    {
        private readonly SubRedditService subredditService;

        public FoxxitController(SubRedditService subredditService)
        {
            this.subredditService = subredditService;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            return View("index");
        }

        [HttpGet("subreddit")]
        public async Task<IActionResult> Subreddit(long subredId)
        {
            var subreddit = await subredditService.GetByIdAsync(subredId);
            var viewModel = new SubredditViewModel() { Subreddit = subreddit };
            return View(viewModel);
        }
    }
}