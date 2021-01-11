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
    [Authorize]
    public class FoxxitController : MainController
    {
        private const int PageSize = 10;

        public FoxxitController(IUserService userService, UserManager<User> userManager, SignInManager<User> signInManager, ISearchService searchService, IPostService postService, ISubRedditService subRedditService, ICommentService commentService)
            : base(userManager, signInManager)
        {
            SearchService = searchService;
            PostService = postService;
            SubRedditService = subRedditService;
            CommentService = commentService;
            UserService = userService;
        }

        public ISearchService SearchService { get; set; }
        public IPostService PostService { get; set; }
        public ISubRedditService SubRedditService { get; set; }
        public ICommentService CommentService { get; set; }
        public IUserService UserService { get; set; }

        [HttpGet("")]
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var currentUser = await GetActiveUserAsync();
            var subReddits = await SubRedditService.GetAllIncludeUser();
            var posts = await PostService.GetAllIncludeCommentsAsync();
            var model = new MainPageViewModel()
            {
                CurrentUser = currentUser,
                Posts = posts.OrderByDescending(post => post.CreatedAt).ToList(), // TODO: Instead of OrderBy use Sort Method
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
                Posts = await PostService.GetAllIncludeCommentsAsync(),
                SubReddits = await SubRedditService.GetAllIncludeUser(),
                SearchReturnModel = SearchService.Search(category, keyword),
            };

            return View("Filter", model);
        }

        [HttpGet("paginationSample")]
        public async Task<IActionResult> PaginationSample(int? pageNum)
        {
            var posts = await PostService.GetAllIncludeCommentsAsync();
            return View(await PaginatedList<Post>.CreateAsync(posts, pageNum ?? 1, PageSize));
        }

        [HttpGet("subreddit")]
        public async Task<IActionResult> SubReddit(long subRedditId)
        {
            var currentUser = await GetActiveUserAsync();
            var currentSubReddit = SubRedditService.GetbyIdIncludeUser(subRedditId);
            var subReddits = await SubRedditService.GetAllIncludeUser();

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
            var subReddits = await SubRedditService.GetAllIncludeUser();
            var currentSubReddit = SubRedditService.GetbyIdIncludeUser(subRedditId);

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
            var subReddit = await SubRedditService.GetByIdAsync(subRedditId);
            var post = new Post(title, text, url, subReddit, user);

            await PostService.AddAsync(post);
            await PostService.SaveAsync();

            return Redirect($"/Post/{post.Id}");
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
            var posts = await PostService.GetAllIncludeCommentsAsync();
            var subReddits = await SubRedditService.GetAllIncludeUser();

            var model = new MainPageViewModel()
            {
                CurrentUser = currentUser,
                Posts = posts,
                SubReddits = subReddits,
                PostViewModel = postViewModel,
            };

            return View("Post", model);
        }

        [HttpGet("loadComments")]
        public async Task<IActionResult> LoadComments(long postId)
        {
            var model = await PostService.GetByIdAsync(postId);
            return PartialView("_CommentViewPartial", model);
        }

        [HttpPost("addComment")]
        public async Task<IActionResult> AddComment(string text, long postId)
        {
            var user = await GetActiveUserAsync();
            var post = await PostService.GetByIdAsync(postId);

            var comment = new Comment(text, user, post);

            await CommentService.AddAsync(comment);
            await CommentService.SaveAsync();

            return Redirect($"Post/{postId}");
        }

        [HttpGet("SubReddit/Join")]
        public async Task<IActionResult> Join(long subRedditId)
        {
            var user = await GetActiveUserAsync();
            var subReddit = await SubRedditService.GetByIdAsync(subRedditId);

            subReddit.Members.Add(user);
            SubRedditService.Update(subReddit);
            await SubRedditService.SaveAsync();

            await UserService.UpdateUsersSubReddits(user, subReddit);

            return Redirect($"/SubReddit?subRedditId={subRedditId}");
        }

        [HttpGet("SubReddit/Unfollow")]
        public async Task<IActionResult> Unfollow(long subRedditId)
        {
            var user = await GetActiveUserAsync();
            var subReddit = await SubRedditService.GetByIdAsync(subRedditId);
            subReddit.Members.Remove(user);
            SubRedditService.Update(subReddit);
            await SubRedditService.SaveAsync();

            return Redirect($"/SubReddit?subRedditId={subRedditId}");
        }
    }
}