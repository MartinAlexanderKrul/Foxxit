using System.Threading.Tasks;
using Foxxit.Models.DTO;
using Foxxit.Models.Entities;
using Foxxit.Models.ViewModels;
using Foxxit.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Foxxit.Controllers
{
    /*[Authorize]*/

    public class FoxxitController : MainController
    {
        private const int PageSize = 10;

        public FoxxitController(UserManager<User> userManager, SignInManager<User> signInManager, ISearchService searchService, IPostService postService, ISubRedditService subRedditService, ICommentService commentService)
            : base(userManager, signInManager)
        {
            SearchService = searchService;
            PostService = postService;
            SubRedditService = subRedditService;
            CommentService = commentService;
        }

        public ISearchService SearchService { get; set; }
        public IPostService PostService { get; set; }
        public ISubRedditService SubRedditService { get; set; }
        public ICommentService CommentService { get; set; }

        [HttpGet("index")]
        [HttpGet("")]
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

        [HttpGet("/Post/New")]
        public async Task<IActionResult> NewPost(int subRedditId)
        {
            var model = new MainPageViewModel()
            {
                CurrentUser = await GetActiveUserAsync(),
                SubReddits = await SubRedditService.GetAllAsync(),
                CurrentSubReddit = await SubRedditService.GetByIdAsync(subRedditId),
            };

            return View("CreatePost", model);
        }

        [HttpPost("/Post/Create")]
        public async Task<IActionResult> CreatePost(string title, string url, string image, string text, int subRedditId)
        {
            var post = new Post(title, url, image, text, subRedditId);

            await PostService.AddAsync(post);
            await PostService.SaveAsync();

            return RedirectToAction("SubReddit", subRedditId);
        }

        [HttpGet("loadComments")]
        public async Task<IActionResult> LoadComments(long postId)
        {
            var model = await PostService.GetByIdAsync(postId);
            return PartialView("_CommentViewPartial", model);
        }

        [HttpGet("addComment")]
        public IActionResult AddComment(string text, long userId, long postId)
        {
            var comment = new Comment(text, userId, postId);
            CommentService.AddAsync(comment);
            CommentService.SaveAsync();

            return RedirectToAction("ViewPost", postId);
        }
    }
}