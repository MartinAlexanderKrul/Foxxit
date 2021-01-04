using System.Collections.Generic;
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
                new Post() { User = user, Id = 2, SubReddit = new SubReddit() { Name = "Green Fox", Id = 5 }, Title = "Green Fox", ImageURL = "https://www.spacesworks.com/wp-content/uploads/2016/06/coding-in-the-classroom.png" },
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
            var user = new User("Nicolsburg", "nicolsburg@hocz.org");
            var subreddits = new List<SubReddit>
            {
                new SubReddit() { Name = "Green Fox", Id = 1 },
                new SubReddit() { Name = "Microtis", Id = 2 },
                new SubReddit() { Name = "Sageeeee", Id = 3 },
                new SubReddit() { Name = "Vulpes", Id = 9 },
            };
            var posts = new List<Post>()
            {
                new Post() { User = user,  Id = 1,  SubReddit = new SubReddit() { Name = "Green Fox", Id = 4 }, Title = "Green Fox", Text = "fwafawfajwfjawifjawkjfkawfnkjawh faw jakwfj kawfjj kawf jkawhf jkawhnfk " },
                new Post() { User = user, Id = 2, SubReddit = new SubReddit() { Name = "Green Fox", Id = 5 }, Title = "Green Fox", ImageURL = "https://www.spacesworks.com/wp-content/uploads/2016/06/coding-in-the-classroom.png" },
            };
            var model = new MainPageViewModel()
            {
                CurrentUser = user,
                SubReddits = subreddits,
                Posts = posts,
                SearchReturnModel = SearchService.Search(category, keyword),
            };

            return await Task.Run(() => View("Filter", model));
        }

        [HttpGet("newPost")]
        public IActionResult Search(SubReddit subReddit)
        {
            var user = new User("Nicolsburg", "nicolsburg@hocz.org");
            var subreddits = new List<SubReddit>
            {
                new SubReddit() { Name = "Green Fox", Id = 1 },
                new SubReddit() { Name = "Microtis", Id = 2 },
                new SubReddit() { Name = "Sageeeee", Id = 3 },
                new SubReddit() { Name = "Vulpes", Id = 9 },
            };
            var posts = new List<Post>()
            {
                new Post() { User = user,  Id = 1,  SubReddit = new SubReddit() { Name = "Green Fox", Id = 4 }, Title = "Green Fox", Text = "fwafawfajwfjawifjawkjfkawfnkjawh faw jakwfj kawfjj kawf jkawhf jkawhnfk " },
                new Post() { User = user, Id = 2, SubReddit = new SubReddit() { Name = "Green Fox", Id = 5 }, Title = "Green Fox", ImageURL = "https://www.spacesworks.com/wp-content/uploads/2016/06/coding-in-the-classroom.png" },
            };
            var model = new MainPageViewModel()
            {
                CurrentUser = user,
                SubReddits = subreddits,
                Posts = posts,
                CurrentSubReddit = subReddit,
            };

            return View("CreatePost", model);
        }
    }
}