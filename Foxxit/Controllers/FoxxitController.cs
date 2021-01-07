using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Attributes.RoleServices;
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

        [HttpGet("")]
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var currentUser = await GetActiveUserAsync();
            var subReddits = await SubRedditService.GetAllAsync();
            var posts = await PostService.GetAllAsync();
            var model = new MainPageViewModel()
            {
                CurrentUser = currentUser,
                Posts = posts,
                SubReddits = subReddits,
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

        [HttpGet("subreddit")]
        public async Task<IActionResult> SubReddit(long subRedditId)
        {
            var currentUser = await GetActiveUserAsync();
            var currentSubReddit = await SubRedditService.GetByIdAsync(subRedditId);
            var subReddits = await SubRedditService.GetAllAsync();

            var model = new MainPageViewModel()
            {
                CurrentUser = currentUser,
                CurrentSubReddit = currentSubReddit,
                SubReddits = subReddits,
            };

            return View("SubReddit", model);
        }

        [HttpGet("subreddit/new")]
        public async Task<IActionResult> CreateSubreddit()
        {
            var model = new MainPageViewModel()
            {
                CurrentUser = await GetActiveUserAsync(),
                SubReddits = await SubRedditService.GetAllIncludeUser()
            };

            return View("CreateSubreddit", model);
        }

        [HttpPost("subreddit/new")]
        public async Task<IActionResult> CreateSubreddit(string name, string about)
        {
            var list = await SubRedditService.GetAllAsync();
            if (!list.Any(s => s.Name.Equals(name)))
            {
                var currentUser = await GetActiveUserAsync();
                var subreddit = new SubReddit(name, about, currentUser.Id);
                await SubRedditService.AddAsync(subreddit);
                await SubRedditService.SaveAsync();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "SubReddit with this name already exists.");
            }

            return View("Index");
        }

        // [AuthorizedRoles(Enums.UserRole.Admin)]
        [HttpGet("subreddit/approve")]
        public async Task<IActionResult> ApproveSubreddit()
        {
            var model = new MainPageViewModel()
            {
                CurrentUser = await GetActiveUserAsync(),
                SubReddits = await SubRedditService.GetAllIncludeUser()
            };

            return View("SubredditsToApprove", model);
        }

        // [AuthorizedRoles(Enums.UserRole.Admin)]
        [HttpPost("subreddit/approve")]
        public async Task<IActionResult> ApproveSubreddit(long id, bool isApproved)
        {
            var subRedditToChange = await SubRedditService.GetByIdAsync(id);
            subRedditToChange.IsApproved = isApproved;
            SubRedditService.Update(subRedditToChange);
            await SubRedditService.SaveAsync();

            return RedirectToAction("ApproveSubreddit");
        }

        [HttpGet("/Post/New")]
        public async Task<IActionResult> NewPost(int subRedditId)
        {
            var currentUser = await GetActiveUserAsync();
            var subReddits = await SubRedditService.GetAllAsync();
            var currentSubReddit = await SubRedditService.GetByIdAsync(subRedditId);

            var model = new MainPageViewModel()
            {
                CurrentUser = currentUser,
                SubReddits = subReddits,
                CurrentSubReddit = currentSubReddit
            };

            return View("CreatePost", model);
        }

        [HttpPost("/Post/Create")]
        public async Task<IActionResult> CreatePost(string title, string url, string image, string text, long subRedditId)
        {
            var user = await GetActiveUserAsync();
            var post = new Post(title, url, image, text, subRedditId) { User = user };

            await PostService.AddAsync(post);
            await PostService.SaveAsync();

            return RedirectToAction("ViewPost", post.Id);
        }

        [HttpGet("/Post/{postId}")]
        public async Task<IActionResult> ViewPost(long postId)
        {
            var currentUser = await GetActiveUserAsync();
            var post = await PostService.GetByIdAsync(postId);

            var postViewModel = new PostViewModel()
            {
                CurrentUser = currentUser,
                Post = post
            };
            var posts = await PostService.GetAllAsync();
            var subReddits = await SubRedditService.GetAllAsync();

            var model = new MainPageViewModel()
            {
                CurrentUser = currentUser,
                Posts = posts,
                SubReddits = subReddits,
                PostViewModel = postViewModel,
            };

            return View("Post", model);
        }

        [HttpGet("loadComments/")]
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