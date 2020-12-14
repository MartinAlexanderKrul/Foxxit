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
        public FoxxitController(UserManager<User> userManager, SignInManager<User> signInManager, PostService postService)
            : base(userManager, signInManager)
        {
            this.postService = postService;
        }

        private readonly PostService postService;

        [HttpGet("index")]
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var model = new MainPageViewModel();
            return await Task.Run(() => View("Index", model));
        }

        [HttpGet("paginationTest")]
        public async Task<IActionResult> PaginationTest(int? pageNum)
        {
            var posts = await postService.GetAllAsync();
            int pageSize = 10;

            return View(await PaginatedList<Post>.CreateAsync(posts, pageNum ?? 1, pageSize));
        }
    }
}