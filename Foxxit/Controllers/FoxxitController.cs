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
            var user = new User("Nicolsburg", "nicolsburg@hocz.org");

            var subreddits = new List<SubReddit>
            {
                new SubReddit() { Name = "Green Fox", Id = 1 },
                new SubReddit() { Name = "Microtis", Id = 2 },
                new SubReddit() { Name = "Sageeeee", Id = 3 },
                new SubReddit() { Name = "Vulpes", Id = 9 },
            };

            var subComments = new List<Comment>()
            {
                new Comment()
            {
                    User = user,
                    Text = "This is the first SUBcomment of all comments.",
            },
                new Comment()
                {
                    User = user,
                    Text = "This is the second one. SUB!",
                },
            };

            var comments = new List<Comment>()
            {
                new Comment()
            {
                    User = user,
                    Text = "This is the first comment of all comments.",
            },
                new Comment()
                {
                    Comments = subComments,
                    User = user,
                    Text = "This is the second comment. This is the second comment. This is the second comment. This is the second comment. This is the second comment. This is the second comment. This is the second comment. This is the second comment.",
                },
            };

            var posts = new List<Post>()
            {
                new Post() { Comments = comments, User = user,  Id = 1,  SubReddit = new SubReddit() { Name = "Green Fox", Id = 4 }, Title = "Green Fox", Text = "fwafawfajwfjawifjawkjfkawfnkjawh faw jakwfj kawfjj kawf jkawhf jkawhnfk " },
                new Post() { Comments = comments,  User = user, Id = 2, SubReddit = new SubReddit() { Name = "Green Fox", Id = 5 }, Title = "Green Fox", ImageURL = "https://www.spacesworks.com/wp-content/uploads/2016/06/coding-in-the-classroom.png" },
            };

            var model = new MainPageViewModel()
            {
                CurrentUser = user,
                SubReddits = subreddits,
                Posts = posts,
            };

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
                // CurrentUser = await GetActiveUserAsync(),
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

            return RedirectToAction("ViewSubReddit", subRedditId); // waiting for the correct endpoint
        }

        [HttpGet("loadComments")]
        public async Task<IActionResult> LoadComments(long postId)
        {
            var user = new User("Nicolsburg", "nicolsburg@hocz.org");

            var subComments = new List<Comment>()
            {
                new Comment()
            {
                    User = user,
                    Text = "This is the first SUBcomment of all comments.",
            },
                new Comment()
                {
                    User = user,
                    Text = "This is the second one. SUB!",
                },
            };

            var comments = new List<Comment>()
            {
                new Comment()
            {
                    User = user,
                    Text = "This is the first comment of all comments.",
            },
                new Comment()
                {
                    Comments = subComments,
                    User = user,
                    Text = "This is the second comment. This is the second comment. This is the second comment. This is the second comment. This is the second comment. This is the second comment. This is the second comment. This is the second comment.",
                },
            };
            var model = new Post() { Comments = comments, User = user, Id = 1, SubReddit = new SubReddit() { Name = "Green Fox", Id = 4 }, Title = "Green Fox", Text = "fwafawfajwfjawifjawkjfkawfnkjawh faw jakwfj kawfjj kawf jkawhf jkawhnfk " };

            return PartialView("_CommentViewPartial", model);
        }

        [HttpGet("newComment")]
        public async Task<IActionResult> NewComment(long? postId, long? originalCommentId)
        {
            var user = await GetActiveUserAsync();
            var model = new CreatingCommentViewModel(postId, originalCommentId, user);

            return PartialView("_AddCommentViewPartial", model);
        }

        [HttpGet("addComment")]
        public IActionResult AddComment(string text, long userId, long? originalCommentId, long? postId)
        {
            var comment = new Comment(text, userId, originalCommentId, postId);
            CommentService.AddAsync(comment);
            CommentService.SaveAsync();

            return RedirectToAction("index"); // TODO: REDIRECT AND SHOW ORIGINAL POST instead of index
        }
    }
}