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
            var comments = new List<Comment>() { new Comment() { Comments = new List<Comment>() { new Comment() { User = user, Text = "Goooodie Goooodie Goooodie GoooodieGoooodie Goooodie GoooodieGoooodieGoooodie Goooodie GoGoooodieooodieG oooodieGo ooodieGoooodieGoooodieGoooodi eGoooodieGoooodie", OriginalCommentId = 1 } }, User = user, Text = "Hello, how are you doing today?", PostId = 1 }, new Comment() { User = user, Text = "GOODBYE", PostId = 1 }, new Comment() { User = user, Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", PostId = 1 } };
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
    }
}