using Foxxit.Models.Entities;
using Foxxit.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Foxxit.Controllers
{
    public class FoxxitController : Controller
    {
        private readonly UserService userService;
        private readonly PostService postService;

        public FoxxitController(UserService userService, PostService postService)
        {
            this.userService = userService;
            this.postService = postService;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            return View("index");
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