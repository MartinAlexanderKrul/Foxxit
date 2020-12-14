using Foxxit.Models.Entities;
using Foxxit.Models.ViewModels;
using Foxxit.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Foxxit.Controllers
{
    public class FoxxitController : MainController
    {
        public FoxxitController(UserManager<User> userManager, SignInManager<User> signInManager, SubRedditService subRedditService)
            : base(userManager, signInManager)
        {
            this.subRedditService = subRedditService;
        }

        private readonly SubRedditService subRedditService;

        [HttpGet("index")]
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var model = new MainPageViewModel();
            return await Task.Run(() => View("Index", model));
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