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

        [HttpGet("loadComments")]
        public async Task<IActionResult> LoadComments(long postId)
        {
            var model = await PostService.GetByIdAsync(postId);

            return PartialView("_CommentViewPartial", model);
        }

        [HttpGet("newComment")]
        public async Task<IActionResult> NewComment(long? postId, long? originalCommentId)
        {
            var user = await GetActiveUserAsync();
            var model = new CreatingCommentViewModel(postId, originalCommentId, user);

            return PartialView("_AddCommnentViewPartial", model);
        }

        [HttpGet("addComment")]
        public IActionResult AddComment(string text, long userId, long? originalCommentId, long? postId)
        {
            var comment = new Comment(text, userId, originalCommentId, postId);

            return RedirectToAction("index"); // TODO: REDIRECT AND SHOW ORIGINAL POST instead of index
        }
    }
}