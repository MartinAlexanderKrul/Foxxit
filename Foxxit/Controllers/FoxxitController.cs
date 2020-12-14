using System.Threading.Tasks;
using Foxxit.Models.ViewModels;
using Foxxit.Services;
using Microsoft.AspNetCore.Mvc;

namespace Foxxit.Controllers
{
    public class FoxxitController : Controller
    {
        private readonly SubRedditService subRedditService;

        public FoxxitController(SubRedditService subRedditService)
        {
            this.subRedditService = subRedditService;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            return View("index");
        }

        [HttpGet("subreddit")]
        public async Task<IActionResult> SubReddit(long subRedId)
        {
            var subReddit = await subRedditService.GetByIdAsync(subRedId);
            var viewModel = new SubRedditViewModel() { SubReddit = subReddit };
            return View(viewModel);
        }
    }
}