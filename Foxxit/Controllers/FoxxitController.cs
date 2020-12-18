using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Models.ViewModels;
using Foxxit.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Foxxit.Controllers
{
    public class FoxxitController : MainController
    {
        public FoxxitController(UserManager<User> userManager, SignInManager<User> signInManager, ISearchService searchService, IPostService postService, ISubRedditService subRedditService)
            : base(userManager, signInManager)
        {
            SearchService = searchService;
            PostService = postService;
            SubRedditService = subRedditService;
        }

        public ISearchService SearchService { get; set; }
        public IPostService PostService { get; set; }
        public ISubRedditService SubRedditService { get; set; }

        [HttpGet("index")]
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var model = new MainPageViewModel();
            return await Task.Run(() => View("Index", model));
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(string category, string keyword)
        {
            var model = new MainPageViewModel()
            {
                CurrentUser = await GetActiveUserAsync(),
                Posts = await PostService.GetAllAsync(),
                SubReddits = await SubRedditService.GetAllAsync(),
                SearchReturnModel = SearchService.Search(category, keyword),
            };

            return await Task.Run(() => View("Filter", model));
        }

        [HttpGet("subreddit/new")]
        public async Task<IActionResult> CreateSubreddit()
        {
            var model = new SubRedditViewModel();
            return await Task.Run(() => View("Subreddit", model));
        }

        [HttpPost("subreddit/new")]
        public async Task<IActionResult> CreateSubreddit(SubRedditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                // Dodelat check jestli je v systemu
                // V CONSTRUCTORU VRATIT ZPET model.User.Id jak bude fungovat
                
                var subreddit = new SubReddit(model.Name, model.About, 1);
                SubRedditService.Add(subreddit);
                SubRedditService.Save();
                //ModelState.AddModelError(string.Empty, "Subreddit is already existing!");
            }
            return View("Subreddit", model);
        }

        [HttpGet("subreddit/approve")]
        public async Task<IActionResult> ApproveSubreddits()
        {
            var model = SubRedditService.GetUnApproved();
            return await Task.Run(() => View("SubredditsToApprove", model));
        }
    }
}