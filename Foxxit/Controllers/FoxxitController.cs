using System.Collections.Generic;
using System.Threading.Tasks;
using Foxxit.Models.DTO;
using Foxxit.Models.Entities;
using Foxxit.Models.ViewModels;
using Foxxit.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Foxxit.Controllers
{
    [Route("")]
    public class FoxxitController : MainController
    {
        private const int PageSize = 10;

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
        public async Task<IActionResult> Index()
        {
            var currentUser = await GetActiveUserAsync();
            var subReddits = await SubRedditService.GetAllAsync();
            var headerViewModel = new HeaderViewModel()
            {
                CurrentUser = currentUser,
                SubReddits = subReddits
            };
            var model = new MainPageViewModel()
            {
                // CurrentUser = await GetActiveUserAsync(),
                Posts = await PostService.GetAllAsync(),
                SubReddits = await SubRedditService.GetAllAsync(),
                HeaderViewModel = headerViewModel
            };

            return View("Index", model);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(string category, string keyword)
        {
            var model = new MainPageViewModel()
            {
                // CurrentUser = await GetActiveUserAsync(),
                Posts = await PostService.GetAllAsync(),
                SubReddits = await SubRedditService.GetAllAsync(),
                SearchReturnModel = SearchService.Search(category, keyword),
            };

            return View("Filter", model);
        }

        [HttpGet("paginationSample")]
        public async Task<IActionResult> PaginationSample(int? pageNum)
        {
            var posts = await PostService.GetAllAsync();
            return View(await PaginatedList<Post>.CreateAsync(posts, pageNum ?? 1, PageSize));
        }

        [HttpGet("subreddit/{subRedditId}")]
        public async Task<IActionResult> Subreddit([FromRoute] int subRedditId)
        {
            var currentUser = await GetActiveUserAsync();
            var subReddit = await SubRedditService.GetByIdAsync(subRedditId);
            var subReddits = await SubRedditService.GetAllAsync();
            var headerViewModel = new HeaderViewModel()
            {
                CurrentUser = currentUser,
                SubReddits = subReddits
            };
            var model = new SubRedditViewModel()
            {
                User = currentUser,
                SubReddit = subReddit,
                SubReddits = subReddits,
                HeaderViewModel = headerViewModel
            };

            return View(model);
        }
    }
}