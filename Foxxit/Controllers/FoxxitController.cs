using System.Collections.Generic;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Foxxit.Controllers
{
    public class FoxxitController : MainController
    {
        public FoxxitController(UserManager<User> userManager, SignInManager<User> signInManager)
            : base(userManager, signInManager)
        {
        }

        [HttpGet("index")]
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var user = new User("Nicolsburg");
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
            };
            return await Task.Run(() => View("Index", model));
        }
    }
}