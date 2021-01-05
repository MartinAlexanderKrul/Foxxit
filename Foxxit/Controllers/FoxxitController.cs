using System.Linq;
using System.Threading.Tasks;
using Foxxit.Attributes.RoleServices;
using Foxxit.Models.DTO;
using Foxxit.Models.Entities;
using Foxxit.Models.ViewModels;
using Foxxit.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Foxxit.Controllers
{
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
            var model = new MainPageViewModel()
            {
                CurrentUser = await GetActiveUserAsync(),
                Posts = await PostService.GetAllAsync(),
                SubReddits = await SubRedditService.GetAllAsync(),
            };

            return View("Index", model);
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

            return View("Filter", model);
        }

        [HttpGet("paginationSample")]
        public async Task<IActionResult> PaginationSample(int? pageNum)
        {
            var posts = await PostService.GetAllAsync();

            return View(await PaginatedList<Post>.CreateAsync(posts, pageNum ?? 1, PageSize));
        }

        [HttpGet("subreddit/new")]
        public IActionResult CreateSubreddit()
        {
            var model = new SubRedditViewModel();
            return View("Subreddit", model);
        }

        [HttpPost("subreddit/new")]
        public async Task<IActionResult> CreateSubreddit(SubRedditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            var list = await SubRedditService.GetAllAsync();
            SubReddit existingSubreddit = list.FirstOrDefault(s => s.Name.Equals(model.Name));
            if (existingSubreddit is null)
            {
                var currentUser = await GetActiveUserAsync();
                var subreddit = new SubReddit(model.Name, model.About, currentUser.Id);
                await SubRedditService.AddAsync(subreddit);
                await SubRedditService.SaveAsync();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Subreddit is already existing!");
            }

            return View("Index");
        }

        //[AuthorizedRoles(Enums.UserRole.Admin)]
        [HttpGet("subreddit/approve")]
        public async Task<IActionResult> ApproveSubreddit()
        {
            var model = new MainPageViewModel()
            {
                SubReddits = await SubRedditService.GetAllIncludeUser()
            };

            return View("SubredditsToApprove", model);
        }
        //[AuthorizedRoles(Enums.UserRole.Admin)]
        [HttpPost("subreddit/approve")]
        public async Task<IActionResult> ApproveSubreddit(long id, bool isApproved)
        {
            var subRedditToChange = await SubRedditService.GetByIdAsync(id);
            subRedditToChange.IsApproved = isApproved;
            SubRedditService.Update(subRedditToChange);
            await SubRedditService.SaveAsync();

            return RedirectToAction("ApproveSubreddit");
        }

        [HttpGet("")]
        public IActionResult Login()
        {
            return Redirect("Account/Login");
        }
    }
}